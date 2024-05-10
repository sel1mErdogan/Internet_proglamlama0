using kutuphane_otomasyou.Models.table.kitaplar;
using kutuphane_otomasyou.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kutuphane_otomasyou.Controllers
{
    public class kitaplarController : Controller
    {
        // GET: kitaplar
        [Authorize]
        [HttpGet]
        public ActionResult kitaplar()
        {
            databaseContextcs db = new databaseContextcs();

            List<Kitap> kitaplistesi = db.kitaptablosu.ToList();

            return View(kitaplistesi);
        }
        [Authorize]
        public ActionResult kitapDetaylari()
        {



            return View();
        }
        public ActionResult Aranan_Kitap(string Aranan_Kitap)
        {
            if (Aranan_Kitap != null)
            {
                databaseContextcs db = new databaseContextcs();
                var kitap_arama = db.kitaptablosu.Where(x => x.kitap_adi.Contains(Aranan_Kitap)).FirstOrDefault();
                if (kitap_arama != null)
                {

                    TempData["ArananKitap"] = kitap_arama;
                    return View();
                }
                else
                {
                    kitap_arama = null;
                    return View();
                }
               

            }
            else
            {
               
                return View();
            }
        }
        [Authorize]
        public ActionResult Alinan_Aranan_Kitap(string Aranan_Kitap)
        {
            if (Aranan_Kitap != null)
            {
                databaseContextcs db = new databaseContextcs();
                var kitap_arama = db.AlinanKitapTaplosu.FirstOrDefault(x => x.kitap_adi == Aranan_Kitap);
                if (kitap_arama != null)
                {

                    TempData["ArananKitap"] = kitap_arama;
                    return View();
                }
                else
                {

                    return View();
                }

            }
            else
            {

                return View();
            }
        }




    }
}