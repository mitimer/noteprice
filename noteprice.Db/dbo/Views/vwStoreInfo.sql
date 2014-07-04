CREATE VIEW [dbo].[vwStoreInfo]
AS
select 
	s.Id as StoreId,
	s.Name as StoreName,
	s.Location as StoreLocation,
	p.Id as PriceId,
	p.Text as PriceName,
	p.Value as PriceValue
from Store s
left join Price p
	on p.SotreId = s.Id