//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace noteprice.Bl.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwPriceStore
    {
        public int PriceId { get; set; }
        public bool PriceIsActive { get; set; }
        public string PriceText { get; set; }
        public string PriceValueStr { get; set; }
        public string PriceWeightStr { get; set; }
        public System.DateTime PriceDateCreated { get; set; }
        public Nullable<decimal> PriceValue { get; set; }
        public Nullable<decimal> PriceWeight { get; set; }
        public Nullable<decimal> PriceNormalValue { get; set; }
        public Nullable<bool> PriceIsPromo { get; set; }
        public Nullable<int> StoreId { get; set; }
        public string StoreName { get; set; }
        public string StroeLocation { get; set; }
        public Nullable<int> StoreSetId { get; set; }
        public string StoreSetName { get; set; }
    }
}
