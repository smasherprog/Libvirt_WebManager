using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libvirt_WebManager.Controllers
{
    public class HostController : CommonController
    {
        public ActionResult _Partial_HostInfo_maincontent(string host)
        {
            return PartialView(GetHost(host));
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
                if (Libvirt_WebManager.Service.VM_Manager.Instance.virConnectOpen(obj.host_or_ip)) return CloseDialog("AddHost('" + obj.host_or_ip + "');");
            }
            return PartialView(obj);
        }
        public ActionResult _Partial_GetHosts_TreeView()
        {
            return PartialView(Libvirt_WebManager.Service.VM_Manager.Instance.Connections);
        }
        public ActionResult _Partial_GetHostChildren_TreeView(string host)
        {
            ViewBag.HostName = host;
            return PartialView(GetHost(host));
        }
    }
}
