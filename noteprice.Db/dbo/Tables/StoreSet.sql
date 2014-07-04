CREATE TABLE [dbo].[StoreSet] (
    [Id]     INT            NOT NULL,
    [Name]   NVARCHAR (300) NOT NULL,
    [SortId] INT            NULL,
    CONSTRAINT [PK_StoreSet] PRIMARY KEY CLUSTERED ([Id] ASC)
);

