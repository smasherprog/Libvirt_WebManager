using System.Diagnostics;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Host.Controllers
{
    public class ListingController : Libvirt_WebManager.Controllers.CommonController
    {
        public ActionResult _Partial_MainContent(string host)
        {
            var v = PartialView(GetHost(host));
            Debug.WriteLine("got");
            return v;
        }
        public ActionResult _Partial_GetHosts()
        {
            return PartialView(Libvirt_WebManager.Service.VM_Manager.Instance.Hosts);
        }
        public ActionResult _Partial_GetHostChildren(string host)
        {
            ViewBag.HostName = host;
            return PartialView(GetHost(host));
        }
    }
}
