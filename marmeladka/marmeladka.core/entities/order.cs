//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace marmeladka.core.entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order()
        {
            this.action_order = new HashSet<action_order>();
        }
    
        public System.Guid id { get; set; }
        public System.DateTime order_time { get; set; }
        public System.Guid userId { get; set; }
        public Nullable<decimal> order_price { get; set; }
        public Nullable<int> OrderWeight { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<action_order> action_order { get; set; }
        public virtual user user { get; set; }
    }
}
