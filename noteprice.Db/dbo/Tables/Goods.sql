CREATE TABLE [dbo].[Goods] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (250) NOT NULL,
    [GoodsTypeId] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Goods_GoodsType] FOREIGN KEY ([GoodsTypeId]) REFERENCES [dbo].[GoodsType] ([Id])
);

