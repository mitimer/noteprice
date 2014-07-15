using System;
using System.Linq.Expressions;
using noteprice.Bl.DataModel;

namespace noteprice.Bl.Dto
{
    public class PriceDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public decimal Value { get; set; }
        public int SotreId { get; set; }
        public decimal? Weight { get; set; }
        public DateTime? Date { get; set; }
        
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StroeLocation { get; set; }
        public int? StoreSetId { get; set; }
        public string StoreSetName { get; set; }
        
        public int? GoodsTypeId { get; set; }
        public int? GoodsId { get; set; }

        public static Expression<Func<vwPriceStore,PriceDto>> SelectException = o=> new PriceDto
        {
            Id = o.PriceId,
            Text = o.PriceText,
            StoreId = o.StoreId.Value,
            StoreName = o.StoreName,
            StroeLocation = o.StroeLocation,
            StoreSetId = o.StoreSetId,
            StoreSetName = o.StoreSetName
        };
    }
}