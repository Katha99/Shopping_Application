CREATE TABLE [dbo].[Persons]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [EmailAddress] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL
)
