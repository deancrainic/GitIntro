SELECT COUNT(Client) AS 'Clients Number', CheckinDate FROM Reservations
GROUP BY CheckinDate
HAVING (CheckinDate <= '2022-04-25')
ORDER BY CheckinDate DESC