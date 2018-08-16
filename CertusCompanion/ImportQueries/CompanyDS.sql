USE CertusDB
;

SELECT		CO.CompanyID
			, CO.ClientID
			, CO.Name as CompanyName

FROM		dbo.Company CO
;