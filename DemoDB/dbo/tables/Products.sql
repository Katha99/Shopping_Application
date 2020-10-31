CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Titel] NVARCHAR(50) NULL, 
    [Price] FLOAT NULL, 
    [Photo] NVARCHAR(50) NULL, 
    [Content] NVARCHAR(MAX) NULL, 
    [Author] NVARCHAR(50) NULL
)
