//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kladmen
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sklad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sklad()
        {
            this.stroymat = new HashSet<stroymat>();
        }
    
        public int ID { get; set; }
        public string Adress { get; set; }
        public Nullable<int> Type_mat { get; set; }
        public Nullable<double> Dastansion { get; set; }
    
        public virtual Type_mat Type_mat1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stroymat> stroymat { get; set; }
    }
}
