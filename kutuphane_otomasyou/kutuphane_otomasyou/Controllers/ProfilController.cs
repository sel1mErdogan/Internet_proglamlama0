using kutuphane_otomasyou.Models;
using kutuphane_otomasyou.Models.table;
using kutuphane_otomasyou.Models.table.kisiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kutuphane_otomasyou.Controllers
{
    public class ProfilController : GirisController
    {
        // GET: Profil
        [Authorize]
        public ActionResult Profil()
        {
            return View();

        }
        [Authorize]
        public ActionResult ProfilGuncelle( kisi güncelle)
        {
            var new_isim = Session["isim"] as string;
            


            if (string.IsNullOrEmpty(new_isim))
            {
                ViewBag.rdd = "İsim boş";
                return View();
            }

            if (güncelle == null)
            {
                ViewBag.rww = "Güncelleme verisi boş";
                return View();
            }

            databaseContextcs db = new databaseContextcs();
            kisi kisi = db.kisitablosu.FirstOrDefault(x => x.ad == new_isim);

            if (kisi == null)
            {
                ViewBag.add = "Kişi bulunamadı";
                return View();
            }

        
            kisi.ad = güncelle.ad;
            kisi.soyad = güncelle.soyad;
            kisi.email = güncelle.email;
            kisi.sifre = güncelle.sifre;

         
            if (!ModelState.IsValid)
            {
                ViewBag.add = "Geçersiz veri";
                return View();
            }

            db.SaveChanges();

           
            ViewBag.add = "Güncelleme başarılı";

            return RedirectToAction("Giris", "Giris");
        }
    }
}