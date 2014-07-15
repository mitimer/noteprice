using System.Collections.Generic;
using noteprice.Bl.Dto;

namespace noteprice.Web.Models
{
	public class StoresListModel
	{
        public string StoreIdSelected { get; set; }
        public List<StoreDto> StoresList { get; set; }
	}
}