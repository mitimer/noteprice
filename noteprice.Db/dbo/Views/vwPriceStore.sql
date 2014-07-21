CREATE VIEW [dbo].[vwPriceStore]
AS
select 	
	p.Id as PriceId,
	ISNULL(p.[IsActive],0) as PriceIsActive,
	p.[Text] as PriceText,
	p.[ValueStr] as PriceValueStr,
	p.[WeightStr] as PriceWeightStr,
	p.[DateCreated] as PriceDateCreated,
	p.[Value] as PriceValue,
	p.[Weight] as PriceWeight,
	case when p.[Weight]>0 then  p.[Value]/ p.[Weight] else p.[Value] end  as PriceNormalValue, 
	ISNULL(p.[IsPromo],0) as PriceIsPromo, 
	s.[Id] as StoreId,
	s.[Name] as StoreName,
	s.[Location] as StroeLocation,
	s.[StoreSetId] as StoreSetId,
	ss.[Name] as StoreSetName
from [dbo].[Price] p	
	left join 
	[dbo].[Store] s
		on p.[StoreId] = s.Id
		left join 
		[dbo].[StoreSet] ss
			on s.StoreSetId = ss.Id