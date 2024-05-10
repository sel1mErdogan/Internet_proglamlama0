using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kutuphane_otomasyou.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        [Authorize]
        public ActionResult iletisim()
        {
            return View();
        }
    }
}