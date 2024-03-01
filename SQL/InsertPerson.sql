GO
-- Adds a Person to the database
CREATE OR ALTER PROCEDURE usp_InsertPerson
@FirstName NVARCHAR(50),
@LastName NVARCHAR(50),
@EmailAddress VARCHAR(100)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO Person(FirstName, LastName, EmailAddress)
			VALUES (@FirstName, @LastName, @EmailAddress)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF(@@TRANCOUNT > 0)
			ROLLBACK TRANSACTION
	END CATCH
END