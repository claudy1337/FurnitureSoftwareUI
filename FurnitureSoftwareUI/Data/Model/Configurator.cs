//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FurnitureSoftwareUI.Data.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Configurator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Configurator()
        {
            this.Product = new HashSet<Product>();
        }
    
        public int id { get; set; }
        public int idOuter { get; set; }
        public int idInner { get; set; }
        public Nullable<int> Price { get; set; }
    
        public virtual InnerMaterial InnerMaterial { get; set; }
        public virtual OuterMaterial OuterMaterial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}