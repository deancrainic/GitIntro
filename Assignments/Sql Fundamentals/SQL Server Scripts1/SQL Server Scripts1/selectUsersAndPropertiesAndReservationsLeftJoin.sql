SELECT u.FirstName,
	u.LastName,
	u.Email,
	p.Name,
	p.Address,
	r.TotalPrice
FROM dbo.Users AS u
	LEFT JOIN dbo.Properties AS p
		ON u.ID = p.ID
	LEFT JOIN dbo.Reservations AS r
		ON p.Owner = r.Owner
ORDER BY LastName