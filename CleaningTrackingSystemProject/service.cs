//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CleaningTrackingSystemProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class service
    {
        public int serviceID { get; set; }
        public string serviceName { get; set; }
        public Nullable<int> catID { get; set; }
        public Nullable<decimal> price { get; set; }
    
        public virtual category category { get; set; }
    }
}