using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libvirt_WebManager.Controllers
{
    public class NoVNCController : Controller
    {
        public ActionResult _Partial_Console()
        {
            return PartialView();
        }
    }
}