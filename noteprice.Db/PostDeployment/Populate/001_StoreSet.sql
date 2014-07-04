﻿-- ==== populate StoreSet =========

declare @t table
(
	[Id] int not null primary key,
	[Name] nvarchar(300) not null
);
--
insert into @t([Id], [Name])
values
(1, 'Dixi'),
(2, 'Magnit'),
(3, '5-ka'),
(4, 'Spar')

merge into [dbo].[StoreSet] as [target]
using @t as [source] on [target].[Id] = [source].[Id]
when matched then
	update set [target].[Name] = [source].[Name]
		
when not matched by target then
	insert ([Id], [Name])
	values ([source].[Id],[source].[Name]);
go