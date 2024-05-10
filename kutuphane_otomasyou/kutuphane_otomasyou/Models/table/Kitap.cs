using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using kutuphane_otomasyou.Models.table.kisiler;

namespace kutuphane_otomasyou.Models.table.kitaplar
{
    [Table("Kitap")]
    public class Kitap
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [StringLength(50), Required]
        public string kitap_adi { get; set; }


        [StringLength(50), Required]
        public string yazar { get; set; }


        [StringLength(30), Required]
        public string turu { get; set; }



        [StringLength(300), Required]
        public string ozet { get; set; }


        [Required]
        public int sayfa_sayisi { get; set; }



        [StringLength(500), Required]
        public string resimi { get; set; }

        [Required]
        public int yili { get; set; }

        public virtual List<kisi>  kisier { get; set; }


    }
}