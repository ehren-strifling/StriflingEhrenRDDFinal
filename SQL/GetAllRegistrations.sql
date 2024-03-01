GO
-- Returns all events in the database
CREATE OR ALTER PROCEDURE usp_GetAllRegistrations
AS
BEGIN

	SELECT * FROM Registrations

END