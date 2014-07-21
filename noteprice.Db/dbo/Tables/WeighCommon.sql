CREATE TABLE [dbo].[WeighCommon]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [Name] NVARCHAR(150) NOT NULL, 
    [Value] DECIMAL(10, 4) NOT NULL, 
    [IsActive] BIT NULL, 
    [SortId] INT NULL, 
    CONSTRAINT [PK_WeighCommon] PRIMARY KEY ([Id])
)
