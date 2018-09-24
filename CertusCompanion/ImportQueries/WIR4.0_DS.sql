USE CertusDB
;

SELECT		TOP 0--<wi>
			DocumentWorkflowItem.DocumentWorkflowItemID
			, ISNULL(CompanyCertificate.Name, '') 
			AS CertificateID
			, REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(LTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(ISNULL(Company.Name, ''), CHAR(13), ''), CHAR(10), ''), CHAR(9), ''), '=', ' ='), '"', ' "')),' =', CHAR(9)), '=', '-'), CHAR(9), ' ='),' "', CHAR(9)), '"', '-'), CHAR(9), ' "')
			AS Vendor
			, DocumentWorkflowItem.CompanyID AS VendorID
			, DocumentWorkflowItem.ClientID
			, CASE
				WHEN DocumentWorkflowItem.DocumentWorkflowStatusID = 2 AND DocumentationAnalyst.SystemUserID IS NOT NULL
					THEN DocumentationAnalyst.LastName + ', '+ DocumentationAnalyst.FirstName
				WHEN DocumentWorkflowItem.DocumentWorkflowStatusID = 3 AND ComplianceAnalyst.SystemUserID IS NOT NULL
					THEN ComplianceAnalyst.LastName + ', ' + ComplianceAnalyst.FirstName
				ELSE '(Unassigned)'
				END AS WorkflowAnalyst
			, CASE
				WHEN DocumentWorkflowItem.DocumentWorkflowStatusID = 2 AND DocumentationAnalyst.SystemUserID IS NOT NULL
					THEN DocumentationAnalyst.SystemUserID
				WHEN DocumentWorkflowItem.DocumentWorkflowStatusID = 3 AND ComplianceAnalyst.SystemUserID IS NOT NULL
					THEN ComplianceAnalyst.SystemUserID
				END AS WorkflowAnalystID
			, CASE
				WHEN Company.AnalystID IS NULL
					THEN '(Unassigned)'
				ELSE CompanyAnalyst.LastName + ', ' + CompanyAnalyst.FirstName
				END AS CompanyAnalyst
			, CASE
				WHEN Company.AnalystID IS NOT NULL
					THEN CompanyAnalyst.SystemUserID
				END AS CompanyAnalystID
			, CAST(DocumentWorkflowItem.EmailDate AS DATETIME) AS EmailDate
			, DocumentWorkflowItem.EmailFromAddress
			, REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(LTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(DocumentWorkflowItem.EmailSubject, CHAR(13), ''), CHAR(10), ''), CHAR(9), ''), '=', ' ='), '"', ' "')),' =', CHAR(9)), '=', '-'), CHAR(9), ' ='),' "', CHAR(9)), '"', '-'), CHAR(9), ' "')
				AS SubjectLine
			, DocumentWorkflowStatus.Description
				AS Status
			, DocumentWorkflowItem.CertusFileID
			, ISNULL(CertusFile.FileName, '')
				AS FileName
			, CertusFile.FileSize
			, ISNULL(CertusFile.FileMime, '')
				AS FileMIME
			, CASE
				WHEN CertusFile.CertusFileID IS NULL
					THEN ''
				ELSE 'https://www.bcscertus.com/handlers/viewfile.ashx?f=' + CAST(CertusFile.CertusFileID AS VARCHAR(MAX))
				END AS FileURL

FROM		DocumentWorkflowItem
				LEFT JOIN CompanyCertificate ON DocumentWorkflowItem.CompanyCertificateID = CompanyCertificate.CompanyCertificateID
				LEFT JOIN Company ON DocumentWorkflowItem.CompanyID = Company.CompanyID
				LEFT JOIN SystemUser DocumentationAnalyst ON DocumentWorkflowItem.DocumentationAnalystID = DocumentationAnalyst.SystemUserID
				LEFT JOIN SystemUser ComplianceAnalyst ON DocumentWorkflowItem.ComplianceAnalystID = ComplianceAnalyst.SystemUserID
				LEFT JOIN SystemUser CompanyAnalyst ON Company.AnalystID = CompanyAnalyst.SystemUserID
				JOIN DocumentWorkflowStatus ON DocumentWorkflowItem.DocumentWorkflowStatusID = DocumentWorkflowStatus.DocumentWorkflowStatusID
				LEFT JOIN CertusFile ON DocumentWorkflowItem.CertusFileID = CertusFile.CertusFileID

WHERE		DocumentWorkflowItem.ClientID = 0--<cl>
			AND DocumentWorkflowStatus.DocumentWorkflowStatusID <= 3--<c1>
			AND DocumentWorkflowStatus.DocumentWorkflowStatusID > 3--<c2>

ORDER BY	DocumentWorkflowItem.DocumentWorkflowItemID desc, DocumentWorkflowItem.EmailDate desc
;