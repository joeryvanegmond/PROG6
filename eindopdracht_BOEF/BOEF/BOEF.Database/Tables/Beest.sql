CREATE TABLE [dbo].[Beest]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Type] VARCHAR(50) NOT NULL, 
    [Prijs] DECIMAL(18, 2) NOT NULL,
    [Image] INT NULL, 
    CONSTRAINT [FK_Beest_ToType] FOREIGN KEY ([Type]) REFERENCES BeestType([Type]),
    CONSTRAINT [FK_Beest_ToImage] FOREIGN KEY ([Image]) REFERENCES BeestImage([Id])

    
)
