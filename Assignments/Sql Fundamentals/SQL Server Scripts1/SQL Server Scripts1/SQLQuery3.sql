SELECT COUNT(Client) AS 'Clients Number', CheckinDate FROM Reservations
GROUP BY CheckinDate
ORDER BY CheckinDate DESC
HAVING GuestsNumber <= 7