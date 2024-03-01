GO
-- Adds an Event to the database
CREATE OR ALTER PROCEDURE usp_GetOrCreatePerson
@FirstName NVARCHAR(50),
@LastName NVARCHAR(50),
@EmailAddress VARCHAR(100)
AS
BEGIN
IF NOT EXISTS (SELECT * FROM Person p WHERE p.FirstName = @FirstName AND p.LastName = @LastName AND p.EmailAddress = @EmailAddress) 
	BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			EXEC usp_InsertPerson @FirstName, @LastName, @EmailAddress
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF(@@TRANCOUNT > 0)
			ROLLBACK TRANSACTION
	END CATCH
	END
	SELECT p.PersonID FROM Person p WHERE p.FirstName = @FirstName AND p.LastName = @LastName AND p.EmailAddress = @EmailAddress
END


EXEC usp_GetOrCreatePerson 'NotEhren', 'Strifling', 'ehrenstrifling@student.mitt.ca'
EXEC usp_GetOrCreatePerson 'Ehren', 'Strifling', 'ehrenstrifling@student.mitt.ca'