CREATE TABLE [dbo].[Price] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Text]        NVARCHAR (350)  NOT NULL,
    [Value]       DECIMAL (10, 4) NULL,
    [StoreId]     INT             NOT NULL,
    [Weight]      DECIMAL (10, 4) NULL,
    [GoodsTypeId] INT             NULL,
    [GoodsId]     INT             NULL,
    [ValueStr] NVARCHAR(150) NOT NULL, 
    [WeightStr] NVARCHAR(150) NULL, 
    [IsActive] BIT NULL, 
    [DateCreated] DATETIME NOT NULL, 
    CONSTRAINT [PK_Price] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Price_Goods] FOREIGN KEY ([GoodsId]) REFERENCES [dbo].[Goods] ([Id]),
    CONSTRAINT [FK_Price_GoodsType] FOREIGN KEY ([GoodsTypeId]) REFERENCES [dbo].[GoodsType] ([Id]),
    CONSTRAINT [FK_Price_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([Id])
);

