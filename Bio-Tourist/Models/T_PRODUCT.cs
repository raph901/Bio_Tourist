namespace Bio_Tourist.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class T_PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_PRODUCT()
        {
            this.T_AD = new HashSet<T_AD>();
        }
    
        public int ID_PRODUCT { get; set; }

        [DisplayName("Catégories")]
        public string CATEGORIE_PRODUCT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_AD> T_AD { get; set; }
    }
}
