GO
-- Adds an Event to the database
CREATE OR ALTER PROCEDURE usp_InsertRegistrationsWithPerson
@EventID INT,
@PersonFirstName NVARCHAR(50),
@PersonLastName NVARCHAR(50),
@PersonEmailAddress NVARCHAR(100)
AS
BEGIN
	DECLARE @PersonID INT
	BEGIN TRY
		BEGIN TRANSACTION
			DECLARE @Temp Table (PersonID INT)
			INSERT @Temp EXEC usp_GetOrCreatePerson @PersonFirstName, @PersonLastName, @PersonEmailAddress;
			SET @PersonID = (SELECT MAX(PersonID) FROM @Temp)

			EXEC usp_InsertRegistrations @EventID, @PersonID
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF(@@TRANCOUNT > 0)
			ROLLBACK TRANSACTION
	END CATCH
END

EXEC usp_InsertRegistrationsWithPerson 1, 'Bob', 'Nobody', 'bobnobody@gmail.com'