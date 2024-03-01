GO
-- Adds an Event to the database
CREATE OR ALTER PROCEDURE usp_UpdateEvents
@EventID INT,
@EventName NVARCHAR(100),
@EventDescription TEXT,
@StartTime DATETIME,
@EndTime DATETIME
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE Events
			Set EventName = @EventName, EventDescription = @EventDescription, StartTime = @StartTime, EndTime = @EndTime
			WHERE EventID = @EventID;
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF(@@TRANCOUNT > 0)
			ROLLBACK TRANSACTION
	END CATCH
END