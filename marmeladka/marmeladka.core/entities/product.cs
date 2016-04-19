namespace marmeladka.core.entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            this.action_order = new HashSet<action_order>();
        }
    
        public Guid id { get; set; }
        public string name { get; set; }
        public decimal opt_price { get; set; }
        public decimal retail_price { get; set; }
        public Guid categoryId { get; set; }
        public Guid companyId { get; set; }
        public int product_weight { get; set; }
        public byte[] img { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<action_order> action_order { get; set; }
        public virtual category category { get; set; }
        public virtual company company { get; set; }
    }
}
