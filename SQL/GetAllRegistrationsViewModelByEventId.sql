GO
-- Returns all events in the database
CREATE OR ALTER PROCEDURE usp_GetAllRegistrationsViewModelByEventId
@EventID INT
AS
BEGIN

	SELECT * FROM Registrations r
	LEFT JOIN Person p ON r.PersonID = p.PersonID
	LEFT JOIN Events e ON r.EventID = e.EventID
	WHERE r.EventID = @EventID

END