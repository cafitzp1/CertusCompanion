USE CertusDB;

SELECT			C.ContactID
				, C.Name
				, C.Title
				, C.EmailAddress
				, CO.CompanyID
FROM			Contact C
LEFT JOIN		CompanyContact CC on CC.ContactID = C.ContactID
LEFT JOIN		Company CO on CO.CompanyID = CC.CompanyID
