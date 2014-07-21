-- ==== populate WeighCommon =========

declare @t table
(
	[Id] int not null primary key,
	[Name] nvarchar(150) not null,
	[Value] DECIMAL (10, 4) not null,
	[SortId] int null,
	[IsActive] bit null
);
--
insert into @t([Id], [Name], [Value],[SortId], [IsActive])
values
(1, '100',	0.1,	1,	1),
(2, '150',	0.15,	1,	1),
(3, '200',	0.2,	1,	1),
(4, '250',	0.25,	1,	1),
(5, '300',	0.3,	1,	1),
(6, '350',	0.35,	1,	1),
(7, '400',	0.4,	1,	1),
(8, '450',	0.45,	1,	1),
(9, '500',	0.5,	1,	1),
(10,'900',	0.9,	1,	1),
(11,'1',	1,		0,	1),
(12,'2',	2,		1,	1),
(13,'5',	5,		1,	1)

SET IDENTITY_INSERT [dbo].[WeighCommon] ON;

merge into [dbo].[WeighCommon] as [target]
using @t as [source] on [target].[Id] = [source].[Id]
when matched then
	update set [target].[Name] = [source].[Name]
	,[target].[Value] = [source].[Value]
	,[target].[SortId] = [source].[SortId]
	,[target].[IsActive] = [source].[IsActive]
		
when not matched by target then
	insert ([Id], [Name], [Value], [SortId], [IsActive])
	values ([source].[Id],[source].[Name],[source].[Value],[source].[SortId],[source].[IsActive]);

	SET IDENTITY_INSERT [dbo].[WeighCommon] OFF;
go