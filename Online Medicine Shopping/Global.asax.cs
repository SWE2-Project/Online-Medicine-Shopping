using Online_Medicine_Shopping.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Online_Medicine_Shopping.DBContext;

namespace Online_Medicine_Shopping
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           Database.SetInitializer<Online_Medicine_Shopping.DBContext.TemporaryDBContext>(null);
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<Online_Medicine_Shopping.DBContext.TemporaryDBContext, Online_Medicine_Shopping.Migrations.Configuration>("DefaultConnection"));
        }
    }
}
