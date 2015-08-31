using System.Diagnostics;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Network.Controllers
{
    public class TreeListingController : Libvirt_WebManager.Controllers.CommonController
    {
        public ActionResult _Partial_Index(string host)
        {
            var h = GetHost(host);
            var ds = h.virConnectListAllNetworks(Libvirt.virConnectListAllNetworksFlags.VIR_DEFAULT);
            AddToAutomaticDisposal(ds);
            return PartialView(new Models.Network_List_Down { Host = host, Parent = host, Networks = ds } );
        }

    }
}
