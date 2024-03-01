GO
-- Returns all events in the database
CREATE OR ALTER PROCEDURE usp_GetAllEvents
AS
BEGIN

	SELECT * FROM Events

END