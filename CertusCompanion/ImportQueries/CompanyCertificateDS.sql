USE CertusDB
;

SELECT			DISTINCT CC.CompanyCertificateID
				, CC.Name
				, CC.IdentityField
				, CL.ClientID
				, CO.CompanyID

FROM			CompanyCertificate CC
LEFT JOIN		Company CO on CC.CompanyID = CO.CompanyID
LEFT JOIN		Client CL on CO.ClientID = CL.ClientID


