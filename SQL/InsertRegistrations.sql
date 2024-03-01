GO
-- Adds an Event to the database
CREATE OR ALTER PROCEDURE usp_InsertRegistrations
@EventID INT,
@PersonID INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO Registrations(EventID, PersonID, DateRegistered)
			VALUES (@EventID, @PersonID, CURRENT_TIMESTAMP)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF(@@TRANCOUNT > 0)
			ROLLBACK TRANSACTION
	END CATCH
END