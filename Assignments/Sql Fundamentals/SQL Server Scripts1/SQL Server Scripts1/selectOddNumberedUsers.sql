SELECT [FirstName] AS 'First name', 
	[Email],
	[ID] AS 'Identification number' FROM Users
WHERE [ID] % 2 > 0