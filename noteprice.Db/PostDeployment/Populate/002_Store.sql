-- ==== populate Store =========

declare @t table
(
	[Id] int not null primary key,
	[Name] nvarchar(300) not null,
	[Location] nvarchar(300) null,
	[StoreSetId] int null,
	[IsActive] bit null
);
--
insert into @t([Id], [Name], [Location], [StoreSetId], [IsActive])
values
(1, 'DIXI','Miheeva',1,1),
(2, 'MAGNIT','Perekop',2,1),
(3, 'Pyterochka','Miheeva',3,1),
(4, 'SPAR','Kazanova',4,1),
(5, 'SPAR','Frunze',4,1),
(6, 'Pyterochka','Budennogo',3,1),
(7, 'SPAR','Arsenal',4,1),
(101, 'TBOY-DOKTOR','',101,1),
(102, 'LADUSHKA','',102,1),
(103, 'SPAR-APTEKA','',103,1)

merge into [dbo].[Store] as [target]
using @t as [source] on [target].[Id] = [source].[Id]
when matched then
	update set [target].[Name] = [source].[Name]
	,[target].[Location] = [source].[Location]
	,[target].[StoreSetId] = [source].[StoreSetId]
	,[target].[IsActive] = [source].[IsActive]
		
when not matched by target then
	insert ([Id], [Name], [Location], [StoreSetId], [IsActive])
	values ([source].[Id],[source].[Name],[source].[Location],[source].[StoreSetId],[source].[IsActive]);
go