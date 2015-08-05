using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libvirt_WebManager.Controllers
{
    public class NoVNCController : CommonController
    {
        public ActionResult _Partial_Console(string host, string domain)
        {
            return PartialView(new ViewModels.NoVNC.ConnectionInfo { Host = host, Path = "websockify", Password = "", Port = "5700" } );
        }
    }
}