//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOEF.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Accessoires
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Accessoires()
        {
            this.Boeking = new HashSet<Boeking>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdBeest { get; set; }
        public decimal Price { get; set; }
        public Nullable<int> Image { get; set; }
    
        public virtual Beest Beest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Boeking> Boeking { get; set; }
        public virtual AccessoireImage AccessoireImage { get; set; }
    }
}
