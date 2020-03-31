CREATE TABLE [dbo].[BeestMetBoeking]
(
	[BeestId] INT NOT NULL, 
    [BoekingId] INT NOT NULL,
    primary key (BeestId, BoekingId),
    CONSTRAINT [FK_BeestMetBoeking_ToBeest] FOREIGN KEY ([BeestId]) REFERENCES [Beest]([Id]),
    CONSTRAINT [FK_BeestMetBoeking_ToBoeking] FOREIGN KEY ([BoekingId]) REFERENCES [Boeking]([Id])
)
