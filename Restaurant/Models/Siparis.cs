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
    
    public partial class Siparis
    {
        public Siparis()
        {
            this.siparismenü = new HashSet<siparismenü>();
        }
    
        public int siparisId { get; set; }
        public Nullable<int> AscıId { get; set; }
        public int GarsonId { get; set; }
        public int MasaId { get; set; }
        public System.DateTime Tarih { get; set; }
        public string SpDurum { get; set; }
        public int Yetki { get; set; }
        public string Aciklama { get; set; }
        public System.DateTime YenilemeTarih { get; set; }
        public int TpFiyat { get; set; }
    
        public virtual Masa Masa { get; set; }
        public virtual Personel Personel { get; set; }
        public virtual Personel Personel1 { get; set; }
        public virtual ICollection<siparismenü> siparismenü { get; set; }
    }
}
