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
    
    public partial class basket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public basket()
        {
            this.basketDetails = new HashSet<basketDetail>();
        }
    
        public int basketID { get; set; }
        public Nullable<int> clientID { get; set; }
        public Nullable<System.DateTime> basketDateTime { get; set; }
    
        public virtual client client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<basketDetail> basketDetails { get; set; }
    }
}