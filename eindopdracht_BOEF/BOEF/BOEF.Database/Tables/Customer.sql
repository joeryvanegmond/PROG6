CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Firstname] NVARCHAR(50) NOT NULL, 
    [Infix] NCHAR(10) NULL, 
    [Lastname] NVARCHAR(50) NOT NULL, 
    [Adress] NVARCHAR(50) NOT NULL, 
    [Mail] NVARCHAR(50) NOT NULL, 
    [Telephone] INT NULL
)
