USE CertusDB -- analyst information
;

SELECT		SU.SystemUserID
			, SU.DefaultClientID as ClientID
			, SU.LastName + ', ' + SU.FirstName as 'Name'
FROM		dbo.SystemUser SU
;