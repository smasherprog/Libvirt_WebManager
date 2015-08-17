using System.Diagnostics;
using System.Web.Mvc;
using System.Linq;

namespace Libvirt_WebManager.Areas.Network.Controllers
{
    public class EditController : Libvirt_WebManager.Controllers.CommonController
    {

        public EditController()
        {
    
        }

        [HttpGet]
        public ActionResult _Partial_IndexMainContent(string host, string network)
        {
            var h = GetHost(host);
            var vm = new Models.Create_Network_Down();
            vm.Host = host;
            vm.Parent = network;
            using (var net = h.virNetworkLookupByName(network))
            {
                var xmldesc = net.virNetworkGetXMLDesc(Libvirt.virNetworkXMLFlags.VIR_DEFAULT);
                vm = Utilities.AutoMapper.Mapper<Models.Create_Network_Down>.Map(xmldesc);
                vm.Configuration = Utilities.AutoMapper.Mapper<Models.Create_Network_Configuration>.Map(xmldesc.Configuration);
            }
            return PartialView(vm);
        }
        [HttpPost]
        public ActionResult _Partial_IndexMainContent(Models.Create_Network_Down vm)
        {
       
            return PartialView(vm);
        }
    }
}