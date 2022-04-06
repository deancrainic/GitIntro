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
		WHERE Owner = 3

		DELETE FROM Reservations
		WHERE Owner = 3

		DELETE FROM Properties
		WHERE Owner = 23
	COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH