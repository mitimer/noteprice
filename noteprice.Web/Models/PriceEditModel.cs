using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using noteprice.Bl.Dto;

namespace noteprice.Web.Models
{
    public class PriceEditModel : PriceBaseModel
    {
        public PriceEditModel(List<StoreDto> storesList) : base(storesList)
        {
        }

        public PriceEditModel(PriceDto dto, List<StoreDto> storesList) : base(dto, storesList)
        {
        }
        
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
    }
}