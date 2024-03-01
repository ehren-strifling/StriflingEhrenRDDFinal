GO
-- Adds an Event to the database
CREATE OR ALTER PROCEDURE usp_DeletePerson
@PersonID INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			DELETE Registrations
			WHERE PersonID = @PersonID;
			DELETE Person
			WHERE PersonID = @PersonID;
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF(@@TRANCOUNT > 0)
			ROLLBACK TRANSACTION
	END CATCH
END