using System;
using System.Linq.Expressions;
using noteprice.Bl.DataModel;

namespace noteprice.Bl.Dto
{
    public class StoreDto
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }
        public int? StoreSetId { get; set; }
        public string StoreSetName { get; set; }

        public static Expression<Func<vwStoreStoreSet,StoreDto>> SelectExpression = o=> new StoreDto
        {
            StoreId = o.StoreId,
            StoreName = o.StoreName,
            StoreLocation = o.StoreLocation,
            StoreSetId = o.StoreSetId,
            StoreSetName = o.StoreSetName,
        };
    }
}