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
    
    public partial class Price
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Nullable<decimal> Value { get; set; }
        public int StoreId { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<int> GoodsTypeId { get; set; }
        public Nullable<int> GoodsId { get; set; }
        public string ValueStr { get; set; }
        public string WeightStr { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<bool> IsPromo { get; set; }
    
        public virtual Good Good { get; set; }
        public virtual GoodsType GoodsType { get; set; }
        public virtual Store Store { get; set; }
    }
}
