using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Libvirt_WebManager
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
          
            //start libvirt default background loop. This will check for errors and report them 
            var backgroundloop = new Libvirt.Utilities.Default_EventLoop();
            System.Web.Hosting.HostingEnvironment.QueueBackgroundWorkItem(ctx => backgroundloop.Start(ctx));
        }
    }
}
