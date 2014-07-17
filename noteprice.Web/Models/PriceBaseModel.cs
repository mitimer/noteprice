using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using noteprice.Bl.Dto;

namespace noteprice.Web.Models
{
    public class PriceBaseModel
    {
        public void Init(PriceDto dto)
        {
            Text = dto.Text;
            
            ValueStr = dto.ValueStr;
            WeightStr = dto.WeightStr;
            StoreId = dto.StoreId;
        }
        
        public int StoreId { get; set; }

        [Required]
        [Display(Name = "Text")]
        public string Text { get; set; }

        [Required]
        [Display(Name = "Value")]
        public string ValueStr { get; set; }

        [Display(Name = "Weight")]
        public string WeightStr { get; set; }

        [Required]
        [Display(Name = "Store")]
        public string StoreIdStr { get; set; }

        public DateTime? Date { get; set; }

        public PriceDto GetDto()
        {
            //TODO: Parse in controller with more powerful logic
            return new PriceDto
            {
                Text = this.Text,
                ValueStr = this.ValueStr,
                WeightStr = this.WeightStr,
                StoreId = int.Parse(this.StoreIdStr),
            };
        }
    }
}