BEGIN TRY
	BEGIN TRANSACTION
		UPDATE Users
		SET LastName = 'Morgan'
		Where ID = 3

		UPDATE Reservations
		SET CheckoutDate = '2022-05-01'
		WHERE ID = 7

		UPDATE Properties
		SET Description = NULL
		WHERE Owner = 4

		DELETE FROM Reservations
		WHERE Owner = 4

		DELETE FROM Properties
		WHERE Owner = 4
	COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH