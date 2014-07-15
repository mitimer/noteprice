using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using noteprice.Bl.Dto;

namespace noteprice.Web.Models
{
    public class PriceAddModel : PriceBaseModel
    {
        public PriceAddModel(List<StoreDto> storesList) : base(storesList)
        {
        }

        public PriceAddModel(PriceDto dto, List<StoreDto> storesList) : base(dto, storesList)
        {
        }
    }
}