-- ==== populate Store =========

declare @t table
(
	[Id] int not null primary key,
	[Name] nvarchar(300) not null,
	[Location] nvarchar(300) null,
	[StoreSetId] int null
);
--
insert into @t([Id], [Name], [Location], [StoreSetId])
values
(1, 'Dixi','l1',1),
(2, 'Magnit','l2',2),
(3, '5-ka','mih',3),
(4, 'Spar','krasn',4),
(5, 'Spar','frunz',4),
(6, '5-ka','Buden',3),
(7, 'Spar','stadion',4)

merge into [dbo].[Store] as [target]
using @t as [source] on [target].[Id] = [source].[Id]
when matched then
	update set [target].[Name] = [source].[Name]
	,[target].[Location] = [source].[Location]
	,[target].[StoreSetId] = [source].[StoreSetId]
		
when not matched by target then
	insert ([Id], [Name], [Location],[StoreSetId])
	values ([source].[Id],[source].[Name],[source].[Location],[source].[StoreSetId]);
go