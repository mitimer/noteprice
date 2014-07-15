CREATE VIEW [dbo].[vwPriceStore]
AS
select 	
	p.Id as PriceId,
	p.[Text] as PriceText,
	p.[Value] as PriceValue,
	p.[Weight] as PriceWeight,
	p.[Date] as PriceDate,
	s.Id as StoreId,
	s.Name as StoreName,
	s.Location as StroeLocation,
	s.StoreSetId as StoreSetId,
	ss.Name as StoreSetName
from [dbo].Price p	
	left join 
	[dbo].Store s
		on p.StoreId = s.Id
		left join 
		[dbo].[StoreSet] ss
			on s.StoreSetId = ss.Id