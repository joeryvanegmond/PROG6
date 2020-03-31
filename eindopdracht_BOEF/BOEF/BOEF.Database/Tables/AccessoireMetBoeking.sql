CREATE TABLE [dbo].[AccessoireMetBoeking]
(
	[AccessoireId] INT NOT NULL , 
    [BoekingId] INT NOT NULL,
	primary key (AccessoireId, BoekingId),
	CONSTRAINT [FK_AccessoireMetBoeking_ToBeest] FOREIGN KEY ([AccessoireId]) REFERENCES [Accessoires]([Id]),
    CONSTRAINT [FK_AccessoireMetBoeking_ToBoeking] FOREIGN KEY ([BoekingId]) REFERENCES [Boeking]([Id])
)
