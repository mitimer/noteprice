using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using noteprice.Bl.Dto;

namespace noteprice.Web.Models
{
    public class PriceBaseModel
    {
        public PriceBaseModel(List<StoreDto> storesList)
        {
            StoresList = storesList;
        }

        public PriceBaseModel(PriceDto dto,List<StoreDto> storesList)
        {
            StoresList = storesList;
            Text = dto.Text;
            Value = dto.Value.ToString();
            Weight = dto.Weight.ToString();
            StoreId = dto.StoreId;
        }

        public List<StoreDto> StoresList { get; set; }

        public int StoreId { get; set; }

        [Required]
        [Display(Name = "Text")]
        public string Text { get; set; }

        [Required]
        [Display(Name = "Value")]
        public string Value { get; set; }

        [Display(Name = "Weight")]
        public string Weight { get; set; }

        [Required]
        [Display(Name = "Store")]
        public string StoreIdStr { get; set; }

        public PriceDto GetDto()
        {
            //TODO: Parse in controller with more powerful logic
            return new PriceDto
            {
                Text = this.Text,
                Value = decimal.Parse(this.Value),
                Weight = decimal.Parse(this.Weight),
                StoreId = int.Parse(this.StoreIdStr)
            };
        }
    }
}