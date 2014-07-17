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
(1, 'DIXI','Miheeva',1),
(2, 'MAGNIT','Perekop',2),
(3, 'Pyterochka','Miheeva',3),
(4, 'SPAR','Kazanova',4),
(5, 'SPAR','Frunze',4),
(6, 'Pyterochka','Budennogo',3),
(7, 'SPAR','Arsenal',4),
(101, 'TBOY-DOKTOR','',101),
(102, 'LADUSHKA','',102),
(103, 'SPAR-APTEKA','',103)

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