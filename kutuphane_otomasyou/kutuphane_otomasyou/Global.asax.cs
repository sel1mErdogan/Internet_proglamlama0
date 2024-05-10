using kutuphane_otomasyou.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace kutuphane_otomasyou
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            using(databaseContextcs db = new databaseContextcs())
            {
                db.Database.CreateIfNotExists();


            }
         

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
