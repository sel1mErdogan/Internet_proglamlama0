using kutuphane_otomasyou.Models;
using kutuphane_otomasyou.Models.table.kisiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace kutuphane_otomasyou.Controllers
{
    public class GirisController : Controller
    {
        // GET: Giris
        public ActionResult kayit_ol()
        {
            return View();
        }
        [HttpPost]
        public ActionResult kayit_ol(kisi yeniKisi)
        {
            databaseContextcs db = new databaseContextcs();
            db.kisitablosu.Add(yeniKisi);
            int sonuc = db.SaveChanges();


            var kullanici_id = db.kisitablosu.FirstOrDefault(x => x.ad == yeniKisi.ad);
            string ad = yeniKisi.ad;
            string email = yeniKisi.email;
            int kullanici_id2 = yeniKisi.Id;




            if (sonuc > 0)
            {
                Session["gizli"] = null;
                Session["isim"] = ad;
                Session["email"] = email;
                Session["id"] = kullanici_id2;
                ViewBag.sonuc = "https://localhost:44366/Home/Home";
                ViewBag.durum = "success";
                FormsAuthentication.SetAuthCookie(yeniKisi.ad, false);

            }
            else
            {

                ViewBag.sonuc = "kayit basarisiz";
                ViewBag.durum = "danger";


            }

            return RedirectToAction("Home", "Home");
        }


        public ActionResult Giris(string username, string password)
        {

            databaseContextcs db = new databaseContextcs();



            var kullanici_dogrulama = db.kisitablosu.FirstOrDefault(x => x.ad == username && x.sifre == password);
            var Admin_dogrulama = db.Admintablosu.FirstOrDefault(x => x.ad == username && x.sifre == password);

            if (Admin_dogrulama != null)
            {

                if (username == Admin_dogrulama.ad && password == Admin_dogrulama.sifre)
                {
                    Session["isim"] = Admin_dogrulama.ad;
                    Session["email"] = Admin_dogrulama.email;

                    FormsAuthentication.SetAuthCookie(Admin_dogrulama.ad, false);
                    Session["gizli"] = "true";


                    return RedirectToAction("Home", "Home");

                }
                return View();
            }
            else if (kullanici_dogrulama != null)
            {
                Session["gizli"] = null;
                FormsAuthentication.SetAuthCookie(kullanici_dogrulama.ad, false);
                int kullanici_id = kullanici_dogrulama.Id;
                Session["id"] = kullanici_id;
                Session["gizli"] = null;
                Session["isim"] = kullanici_dogrulama.ad;
                Session["email"] = kullanici_dogrulama.email;

                return RedirectToAction("Home", "Home");


            }

            else if (username != null && password != null)
            {



                TempData["sifre"] = true;


                return View();


            }
            // Kullanıcı adı ve şifreyi kontrol et

            else
            {

                TempData["yanlis"] = "Kullanıcı adı veya şifre hatalı.";

                // Başarısız giriş

                return View();
            }

            //else if(Authenticate(username, password))
            //{

            //        // Doğrulama başarılıysa, kullanıcıyı ana sayfaya yönlendir
            //     return RedirectToAction("Index", "Home");
            //}




        }
        public ActionResult cikis(string deger)
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Giris", "Giris");
        }

    }
}