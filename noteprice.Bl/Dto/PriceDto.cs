using System;
using System.Linq.Expressions;
using noteprice.Bl.DataModel;

namespace noteprice.Bl.Dto
{
    public class PriceDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Text { get; set; }
        public string ValueStr { get; set; }
        public string WeightStr { get; set; }
        public decimal Value { get; set; }
		public decimal? NormalValue { get; set; }
        public decimal? Weight { get; set; }
        public DateTime DateCreated { get; set; }
        
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StroeLocation { get; set; }
        public int? StoreSetId { get; set; }
        public string StoreSetName { get; set; }
        
        public int? GoodsTypeId { get; set; }
        public int? GoodsId { get; set; }
		public bool? IsPromo { get; set; }

        public static Expression<Func<vwPriceStore,PriceDto>> SelectException = o=> new PriceDto
        {
            Id = o.PriceId,
            IsActive = o.PriceIsActive,
            Text = o.PriceText,
            ValueStr = o.PriceValueStr,
            WeightStr = o.PriceWeightStr,
            Value = o.PriceValue ?? 0,
            Weight = o.PriceWeight,
            DateCreated = o.PriceDateCreated,
            StoreId = o.StoreId.Value,
            StoreName = o.StoreName,
            StroeLocation = o.StroeLocation,
            StoreSetId = o.StoreSetId,
            StoreSetName = o.StoreSetName,
			NormalValue = o.PriceNormalValue,
            IsPromo = o.PriceIsPromo
        };
    }
}