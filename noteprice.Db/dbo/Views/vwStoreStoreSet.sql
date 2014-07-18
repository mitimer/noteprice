
CREATE VIEW [dbo].[vwStoreStoreSet]
AS
select 	
	s.Id as StoreId,
	s.Name as StoreName,
	s.Location as StoreLocation,
	s.StoreSetId as StoreSetId,
	ss.Name as StoreSetName
from 
	[dbo].Store s
		left join 
		[dbo].[StoreSet] ss
			on s.StoreSetId = ss.Id
where s.IsActive = 1