using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kutuphane_otomasyou.Models.table;
using kutuphane_otomasyou.Models;
using kutuphane_otomasyou.Models.table.kisiler;
using kutuphane_otomasyou.Models.table.kitaplar;
using System.Reflection;

namespace kutuphane_otomasyou.Controllers
{   
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Home()
        {
          
            databaseContextcs db = new databaseContextcs();

            List<Kitap>kitaplistesi = db.kitaptablosu.ToList();

            return View(kitaplistesi);
        }


       
    }
}