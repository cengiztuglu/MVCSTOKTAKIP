//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCSTOKTAKIP.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations; //validationlar i?in kullan?lan k?t?phane
    
    public partial class TBLKATEGORILER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLKATEGORILER()
        {
            this.TBLURUNLER = new HashSet<TBLURUNLER>();
        }
    
        public int KATEGORIID { get; set; }
        [Required(ErrorMessage ="Kategori Ad?n? Bo? B?rakmay?n?z")]//db i?ine bo? karakter eklwmwmwk i?in kulland?m
        public string KATEGORIAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLURUNLER> TBLURUNLER { get; set; }
    }
}
