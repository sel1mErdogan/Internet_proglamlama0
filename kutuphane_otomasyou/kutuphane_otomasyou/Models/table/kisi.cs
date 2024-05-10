using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using kutuphane_otomasyou.Models.table;
using kutuphane_otomasyou.Controllers;
using kutuphane_otomasyou.Models.table.kitaplar;

namespace kutuphane_otomasyou.Models.table.kisiler
{
    [Table("kisi")]
    public class kisi
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity) ]
        public int Id { get; set; }


        [ StringLength(30), Required]
        public string ad { get; set; }


        [StringLength(30), Required]
        public string soyad { get; set; }


        [StringLength(50), Required]
        public string sifre { get; set; }


        [StringLength(50), Required]
        public string email { get; set; }

        public virtual List<Kitap>  kitaplar { get; set; }
       

    }
}