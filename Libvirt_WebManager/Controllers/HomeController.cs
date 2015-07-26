using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libvirt_WebManager.Controllers
{
    public class HomeController : CommonController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
 

    }
}
