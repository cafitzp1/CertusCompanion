USE CertusDB -- table for connecting locations to certificates
;

SELECT		row_number() OVER (ORDER BY CCL.CompanyCertificateID, CCL.LocationID) AS 'CertificateLocationID'
			, CCL.CompanyCertificateID
			, CCL.LocationID
			, CCL.DateCreated
FROM		CompanyCertificateLocation CCL
;


