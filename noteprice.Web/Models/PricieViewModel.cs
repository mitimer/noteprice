using System;
using System.Linq.Expressions;
using noteprice.Bl.DataModel;
using noteprice.Bl.Dto;

namespace noteprice.Web.Models
{
	public class PricieViewModel
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public string StoreName { get; set; }
		public decimal Value { get; set; }
		public string WeightStr { get; set; }
		public DateTime DateCreated { get; set; }
		public decimal? NormalValue { get; set; }

		public static Expression<Func<PriceDto, PricieViewModel>> SelectException = o => new PricieViewModel
		{
			Id = o.Id,
			Text = o.Text,
			WeightStr = o.WeightStr,
			Value = o.Value,
			DateCreated = o.DateCreated,
			StoreName = o.StoreName,
			NormalValue = o.NormalValue,
		};
	}
}