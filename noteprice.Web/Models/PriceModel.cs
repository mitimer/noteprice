using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using noteprice.Bl.Dto;

namespace noteprice.Web.Models
{

	public enum PriceEditMode
	{
		Create=0,
		Update=1,
		MakeCopy=2
	}

	public class PriceModel
    {
		public void Init(PriceDto dto, PriceEditMode editMode)
		{
			EditMode = editMode;
			Id = dto.Id;
			Text = dto.Text;
            ValueStr = dto.ValueStr;
            WeightStr = dto.WeightStr;
            StoreId = dto.StoreId;
        }

		public int Id { get; set; }

		public PriceEditMode EditMode { get; set; }

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
                Id = this.Id,
				Text = this.Text,
                ValueStr = this.ValueStr,
                WeightStr = this.WeightStr,
                StoreId = int.Parse(this.StoreIdStr),
            };
        }
    }
}