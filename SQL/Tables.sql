DROP DATABASE EventManagementSystem
CREATE DATABASE EventManagementSystem

DROP TABLE Registrations;
DROP TABLE Events;
DROP TABLE Person;
--DROP TABLE City;

--CREATE TABLE City (
--	CityID INT NOT NULL PRIMARY KEY,
--	Province NVARCHAR(50),
--	City NVARCHAR(50)
--);


CREATE TABLE Person (
	PersonID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	EmailAddress VARCHAR(100)
);

CREATE TABLE Events (
	EventID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	--OrganizerID INT REFERENCES Person(PersonID),
	--CityID INT REFERENCES City(CityID),
	EventName NVARCHAR(100),
	EventDescription TEXT,
	StartTime DATETIME,
	EndTime DATETIME
);

CREATE TABLE Registrations (
	--RegistrationID INT NOT NULL PRIMARY KEY,
	EventID INT NOT NULL REFERENCES Events(EventID),
	PersonID INT NOT NULL REFERENCES Person(PersonID),
	DateRegistered DateTime,
	PRIMARY KEY(EventID, PersonID)
);


EXEC usp_InsertPerson 'Ehren', 'Strifling', 'ehrenstrifling@student.mitt.ca'