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
    
    public partial class Personel
    {
        public Personel()
        {
            this.Siparis = new HashSet<Siparis>();
            this.Siparis1 = new HashSet<Siparis>();
        }
    
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Yetki { get; set; }
        public string Password { get; set; }
        public int Aktiflik { get; set; }
    
        public virtual ICollection<Siparis> Siparis { get; set; }
        public virtual ICollection<Siparis> Siparis1 { get; set; }
    }
}
