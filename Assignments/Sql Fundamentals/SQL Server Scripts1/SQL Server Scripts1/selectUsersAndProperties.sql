SELECT u.FirstName,
	u.LastName,
	u.Email,
	p.Name,
	p.Address
FROM dbo.Users AS u
	INNER JOIN dbo.Properties AS p
		ON u.ID = p.ID
ORDER BY LastName