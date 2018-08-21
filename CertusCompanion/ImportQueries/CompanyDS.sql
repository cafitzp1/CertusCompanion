USE CertusDB
;

SELECT		CO.CompanyID
			, CO.ClientID
			, CO.AnalystID
			, CO.Name as CompanyName
			, CO.City
			, State.Name

FROM		dbo.Company CO
LEFT JOIN	State on CO.StateID = State.StateID