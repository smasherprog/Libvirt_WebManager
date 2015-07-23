using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libvirt_WebManager.Controllers
{
    public class DomainController : CommonController
    {
        [HttpGet]
        public ActionResult _Partial_NewDomain(string host, string p)
        {
            var d = new Libvirt_WebManager.ViewModels.Domain.New_Domain_Down_VM();
            d.Domain.Host = host;
            return View(d);
        }
        [HttpPost]
        public ActionResult _Partial_NewDomain(Libvirt_WebManager.ViewModels.Domain.New_Domain_VM domain)
        {
            var d = new Libvirt_WebManager.ViewModels.Domain.New_Domain_Down_VM();
            d.Domain = domain;
            return View(d);
        }
    }
}
