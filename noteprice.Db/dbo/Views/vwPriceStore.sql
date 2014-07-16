
CREATE VIEW [dbo].[vwPriceStore]
AS
select 	
	p.Id as PriceId,
	p.[IsActive] as PriceIsActive,
	p.[Text] as PriceText,
	p.[ValueStr] as PriceValueStr,
	p.[WeightStr] as PriceWeightStr,
	p.[DateCreated] as PriceDateCreated,
	p.[Value] as PriceValue,
	p.[Weight] as PriceWeight,
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