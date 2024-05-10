using kutuphane_otomasyou.Models.table.kitaplar;
using kutuphane_otomasyou.Models;
using kutuphane_otomasyou.Models.table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kutuphane_otomasyou.Models.table.kisiler;
using Microsoft.Ajax.Utilities;

namespace kutuphane_otomasyou.Controllers
{
    public class kitaplarimController : Controller
    {
        // GET: kitaplarim
        [Authorize]
        [HttpGet]
        public ActionResult kitaplarim()
        {

            databaseContextcs db = new databaseContextcs();

            List<AlinanKitaplar> alinanKitaplars = db.AlinanKitapTaplosu.ToList();



            return View(alinanKitaplars);
        }

        [Authorize]
        [HttpPost]
        public ActionResult kitaplarim(Kitap yenikitap)
        {
            databaseContextcs db = new databaseContextcs();

            
            


            db.kitaptablosu.Add(yenikitap);
             int sonuc=db.SaveChanges();

            if (sonuc > 0)
            {
                ViewBag.sonuc = "kayit basarili";
                ViewBag.durum = "success";
            }
            else
            {

                ViewBag.sonuc = "kayit basarisiz";
                ViewBag.durum = "danger";


            }

            return View();
        }
       
        public ActionResult oduncAl(string Kitapismi)
        {
            databaseContextcs db = new databaseContextcs();
            string kullanici_ismi = Session["isim"] as string;
            var user = db.kisitablosu.FirstOrDefault(x => x.ad == kullanici_ismi);
            string kullanici_id = Session["id"] as string;

          


            if (Kitapismi != null)
            {
                TempData["alindi"] = "dsafsd";

                var kitapBilgisi = db.kitaptablosu.FirstOrDefault(x => x.kitap_adi == Kitapismi);

                var alinanKitaplar = new AlinanKitaplar
                {
                    kitap_adi = kitapBilgisi.kitap_adi,
                    yazar = kitapBilgisi.yazar,
                    turu = kitapBilgisi.turu,
                    ozet = kitapBilgisi.ozet,
                    resimi = kitapBilgisi.resimi,
                    yili = kitapBilgisi.yili,
                    sayfa_sayisi = kitapBilgisi.sayfa_sayisi,
                    kullanici_ıd = user.Id
                };

                db.AlinanKitapTaplosu.Add(alinanKitaplar);
                db.SaveChanges();

                //List<AlinanKitaplar> alinankisilerlist = db.AlinanKitapTaplosu.ToList();

                //alinankisilerlist.Add(new AlinanKitaplar { kitap_adi = "Yeni Kitap", yazar = "Bilinmiyor", ozet = "19. yüzyıl Fransa'sında yoksulluğu, sevgiyi ve insanın içsel dönüşümünü anlatan epik bir romandır. Başkaldırı, merhamet ve insanın iyiliği üzerine derin bir inceleme sunar.", yili = 1222 ,turu="Roman",resimi="sdasdasd",sayfa_sayisi=12});         

                //int sonuc = db.SaveChanges();

                Kitap kitap = db.kitaptablosu.FirstOrDefault(x => x.kitap_adi == Kitapismi);
                db.kitaptablosu.Remove(kitap);
                db.SaveChanges();
            };

           

            return RedirectToAction("kitaplar", "kitaplar");
        }
      
        public ActionResult kitapDetaylari(string Kitapismi)
        {

            databaseContextcs db = new databaseContextcs();
            var kisi = db.kitaptablosu.FirstOrDefault(x => x.kitap_adi == Kitapismi);


            TempData["yazar"] = kisi.yazar;
            TempData["kitap_adi"] = kisi.kitap_adi;
            TempData["turu"] = kisi.turu;
            TempData["ozet"] = kisi.ozet;
            TempData["resimi"] = kisi.resimi;
            TempData["sayfa_sayisi"] = kisi.sayfa_sayisi;
            TempData["yili"] = kisi.yili;



            return RedirectToAction("kitapDetaylari", "kitaplar",new { Kitapismi = Kitapismi });
        }
        public ActionResult kitapDetaylari2(string Kitapismi)
        {

            databaseContextcs db = new databaseContextcs();
            var kisi = db.AlinanKitapTaplosu.FirstOrDefault(x => x.kitap_adi == Kitapismi);


            TempData["yazar"] = kisi.yazar;
            TempData["kitap_adi"] = kisi.kitap_adi;
            TempData["turu"] = kisi.turu;
            TempData["ozet"] = kisi.ozet;
            TempData["resimi"] = kisi.resimi;
            TempData["sayfa_sayisi"] = kisi.sayfa_sayisi;
            TempData["yili"] = kisi.yili;



            return RedirectToAction("kitapDetaylari", "kitaplar", new { Kitapismi = Kitapismi });
        }

        public ActionResult iadeEt(string Kitapismi)
        {
            if (Kitapismi != null)
            {
                TempData["alindi"] = "dsafsd";
                databaseContextcs db = new databaseContextcs();
                var kitaplar = db.AlinanKitapTaplosu.FirstOrDefault(x => x.kitap_adi == Kitapismi);

                var iade = new Kitap
                {
                    kitap_adi = kitaplar.kitap_adi,
                    yazar = kitaplar.yazar,
                    turu = kitaplar.turu,
                    ozet = kitaplar.ozet,
                    resimi = kitaplar.resimi,
                    yili = kitaplar.yili,
                    sayfa_sayisi = kitaplar.sayfa_sayisi,


                };
                db.kitaptablosu.Add(iade);
               

                AlinanKitaplar kitap = db.AlinanKitapTaplosu.Where(x => x.kitap_adi == Kitapismi).FirstOrDefault();
                db.AlinanKitapTaplosu.Remove(kitap);
                db.SaveChanges();

                //List<AlinanKitaplar> alinankisilerlist = db.AlinanKitapTaplosu.ToList();

                //alinankisilerlist.Add(new AlinanKitaplar { kitap_adi = "Yeni Kitap", yazar = "Bilinmiyor", ozet = "19. yüzyıl Fransa'sında yoksulluğu, sevgiyi ve insanın içsel dönüşümünü anlatan epik bir romandır. Başkaldırı, merhamet ve insanın iyiliği üzerine derin bir inceleme sunar.", yili = 1222 ,turu="Roman",resimi="sdasdasd",sayfa_sayisi=12});         

                //int sonuc = db.SaveChanges();


            };



            return RedirectToAction("kitaplarim", "kitaplarim");
        }
      
    }
}