CREATE VIEW [dbo].[vwStoreStoreSet]
AS
select 	
	s.Id as StoreId,
	s.Name as StoreName,
	s.Location as StoreLocation,
	s.StoreSetId as StoreSetId,
	ss.Name as StoreSetName,
	ISNULL(s.IsActive,0) as StoreIsActive
from 
	[dbo].Store s
		left join 
		[dbo].[StoreSet] ss
			on s.StoreSetId = ss.Id