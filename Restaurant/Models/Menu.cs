//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurant.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Menu
    {
        public Menu()
        {
            this.siparismenü = new HashSet<siparismenü>();
        }
    
        public int TürId { get; set; }
        public string TürAdi { get; set; }
        public int Genelid { get; set; }
        public int Fiyat { get; set; }
        public int Aktif { get; set; }
        public string UyeResimAdi { get; set; }
        public Nullable<int> Sure { get; set; }
    
        public virtual GenelMenu GenelMenu { get; set; }
        public virtual ICollection<siparismenü> siparismenü { get; set; }
    }
}
