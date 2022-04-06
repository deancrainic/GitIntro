SELECT SUM(TotalPrice) AS 'Total money gained by property owners',
	Max(TotalPrice) AS 'Most expensive reservation' FROM Reservations
