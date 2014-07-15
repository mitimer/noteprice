using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using noteprice.Bl.Dto;

namespace noteprice.Web.Models
{
    public class PriceEditModel : PriceBaseModel
    {
       
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
    }
}