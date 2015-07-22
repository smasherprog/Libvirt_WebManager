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
        [HttpGet]
        public ActionResult _Partial_Connect_ToHost_Form()
        {
            return PartialView(new Libvirt_WebManager.ViewModels.Host.virConnectOpen());
        }
        [HttpPost]
        public ActionResult _Partial_Connect_ToHost_Form(Libvirt_WebManager.ViewModels.Host.virConnectOpen obj)
        {
            if (ModelState.IsValid)
            {
                if (Libvirt_WebManager.Service.VM_Manager.Instance.virConnectOpen(obj.host_or_ip)) return CloseDialog();
            }
            return PartialView(obj);
        }
        [HttpPost]
        public ActionResult GetHosts(string dir)
        {
            return PartialView("_Partial_HostTree", Libvirt_WebManager.Service.VM_Manager.Instance.GetTreeData(dir));
        }

    }
}
