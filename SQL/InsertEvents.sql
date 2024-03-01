GO
-- Adds an Event to the database
CREATE OR ALTER PROCEDURE usp_InsertEvents
@EventName NVARCHAR(100),
@EventDescription TEXT,
@StartTime DATETIME,
@EndTime DATETIME
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO Events(EventName, EventDescription, StartTime, EndTime)
			VALUES (@EventName, @EventDescription, @StartTime, @EndTime)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF(@@TRANCOUNT > 0)
			ROLLBACK TRANSACTION
	END CATCH
END