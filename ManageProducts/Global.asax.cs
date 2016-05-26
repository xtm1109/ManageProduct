using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ManageProducts
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // For hit counter
            Application["TotalUser"] = 0;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        
        protected void Session_Start() {
            Application.Lock();
            // Whenever there is a new session, increase counter
            Application["TotalUser"] = (int)Application["TotalUser"] + 1;
            Application.UnLock();
        }
    }
}
