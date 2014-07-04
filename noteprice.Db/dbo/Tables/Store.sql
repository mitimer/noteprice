CREATE TABLE [dbo].[Store] (
    [Id]         INT            NOT NULL,
    [Name]       NVARCHAR (300) NOT NULL,
    [Location]   NVARCHAR (400) NULL,
    [StoreSetId] INT            NULL,
    CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Store_StoreSet] FOREIGN KEY ([StoreSetId]) REFERENCES [dbo].[StoreSet] ([Id])
);

