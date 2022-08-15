CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Phone] NCHAR(15) NOT NULL, 
    [ImagesList] NVARCHAR(MAX) NULL, 
    [BirthDay] DATE NULL, 
    [IsManager] BIT NULL, 
    [DepartmentId] INT NULL
)
