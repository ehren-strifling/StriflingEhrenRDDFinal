GO
-- Adds an Event to the database
CREATE OR ALTER PROCEDURE usp_UpdatePerson
@PersonID INT,
@FirstName NVARCHAR(50),
@LastName NVARCHAR(50),
@EmailAddress NVARCHAR(100)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE Person
			Set FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress
			WHERE PersonID = @PersonID;
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF(@@TRANCOUNT > 0)
			ROLLBACK TRANSACTION
	END CATCH
END