GO
-- Returns all events in the database
CREATE OR ALTER PROCEDURE usp_GetAllRegistrationsViewModel
AS
BEGIN

	SELECT * FROM Registrations r
	LEFT JOIN Person p ON r.PersonID = p.PersonID
	LEFT JOIN Events e ON r.EventID = e.EventID

END