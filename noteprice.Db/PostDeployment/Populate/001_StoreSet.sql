-- ==== populate StoreSet =========

declare @t table
(
	[Id] int not null primary key,
	[Name] nvarchar(300) not null,
	[IsActive] bit null
);
--
insert into @t([Id], [Name], [IsActive])
values
(1, 'DIXI',1),
(2, 'MAGNIT',1),
(3, 'Pyterochka',1),
(4, 'SPAR',1),
(5, 'BILLA',1),
(101, 'TBOY-DOKTOR',1),
(102, 'LADUSHKA',1),
(103, 'SPAR-APTEKA',1),
(1000, 'Indie',1)

merge into [dbo].[StoreSet] as [target]
using @t as [source] on [target].[Id] = [source].[Id]
when matched then
	update set [target].[Name] = [source].[Name]
	,[target].[IsActive] = [source].[IsActive]
		
when not matched by target then
	insert ([Id], [Name], [IsActive])
	values ([source].[Id],[source].[Name], [source].[IsActive]);
go