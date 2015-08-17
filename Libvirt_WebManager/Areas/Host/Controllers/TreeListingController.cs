using System.Diagnostics;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Host.Controllers
{
    public class TreeListingController : Libvirt_WebManager.Controllers.CommonController
    {
        public ActionResult _Partial_GetHosts()
        {
            return PartialView(Libvirt_WebManager.Service.VM_Manager.Instance.Hosts);
        }
        public ActionResult _Partial_GetHostChildren(string host)
        {
            var h = GetHost(host);
            return PartialView(new Models.GetHostsChildren_ViewModel { Host = h, HostName = host });
        }
    }
}
