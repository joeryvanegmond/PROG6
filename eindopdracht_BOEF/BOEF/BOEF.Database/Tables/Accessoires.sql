CREATE TABLE [dbo].[Accessoires]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Price] DECIMAL(18, 2) NOT NULL,
    [IdBeest] INT NOT NULL,
    [Image] INT NULL, 
    CONSTRAINT [FK_Accessoires_ToBeest] FOREIGN KEY ([IdBeest]) REFERENCES Beest([Id]),
    CONSTRAINT [FK_Accessoire_ToImage] FOREIGN KEY ([Image]) REFERENCES AccessoireImage([Id])
    
)
