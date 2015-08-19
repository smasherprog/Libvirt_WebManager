using System.Diagnostics;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Network.Controllers
{
    public class ListingController : Libvirt_WebManager.Controllers.CommonController
    {
        public ActionResult _Partial_MainContent(string host)
        {
            var h = GetHost(host);
            Libvirt.CS_Objects.Network[] ds;
            h.virConnectListAllNetworks(out ds, Libvirt.virConnectListAllNetworksFlags.VIR_DEFAULT);
            AddToAutomaticDisposal(ds);
            return PartialView(new Libvirt_WebManager.Areas.Network.Models.Network_List_Down { Host = host, Parent = host, Networks = ds });
        }

        [HttpPost]
        public ActionResult _Partial_Start(string host, string network)
        {
            var n = GetHost(host).virNetworkLookupByName(network);
            AddToAutomaticDisposal(n);
            n.virNetworkCreate();
            return PartialView("_Partial_TableRowDetails", new Libvirt_WebManager.Areas.Network.Models.Network_Down { Host = host, Parent = host, Network = n });
        }
        [HttpPost]
        public ActionResult _Partial_Disable(string host, string network)
        {
            var n = GetHost(host).virNetworkLookupByName(network);
            AddToAutomaticDisposal(n);
            n.virNetworkDestroy();
            return PartialView("_Partial_TableRowDetails", new Libvirt_WebManager.Areas.Network.Models.Network_Down { Host = host, Parent = host, Network = n });
        }


        [HttpPost]
        public ActionResult _Partial_AutoStart(string host, string network, bool autostart)
        {
            var n = GetHost(host).virNetworkLookupByName(network);
            AddToAutomaticDisposal(n);
            if (autostart) n.virNetworkSetAutostart(1);
            else n.virNetworkSetAutostart(0);
            return PartialView("_Partial_TableRowDetails", new Libvirt_WebManager.Areas.Network.Models.Network_Down { Host = host, Parent = host, Network = n });
        }
        [HttpPost]
        public ActionResult _Partial_Delete(string host, string network)
        {
            var n = GetHost(host).virNetworkLookupByName(network);
            AddToAutomaticDisposal(n);
            n.virNetworkDestroy();
            n.virNetworkUndefine();
            return Content("");
        }
    }
}
