CREATE TABLE [dbo].[Boeking]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Date] DATETIME NOT NULL, 
    [CustomerId] INT NOT NULL, 
    [totalPrice] DECIMAL(18, 2) NOT NULL, 
    [Discount] DECIMAL(18, 2) NULL, 
    CONSTRAINT [FK_Boeking_ToCustomer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id])
)
