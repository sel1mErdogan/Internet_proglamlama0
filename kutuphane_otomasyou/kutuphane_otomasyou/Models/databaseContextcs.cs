using kutuphane_otomasyou.Models.table;
using kutuphane_otomasyou.Models.table.kisiler;
using kutuphane_otomasyou.Models.table.kitaplar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace kutuphane_otomasyou.Models
{
    public class databaseContextcs:DbContext
    {

        public DbSet<kisi> kisitablosu {  get; set; }
        public DbSet<Admin> Admintablosu { get; set; }
        public DbSet<CezaliKisiler> CezaliKisilertablosu { get; set; }
        public DbSet<Kitap>kitaptablosu { get; set; }
        public DbSet<AlinanKitaplar> AlinanKitapTaplosu { get; set; }


    }
}