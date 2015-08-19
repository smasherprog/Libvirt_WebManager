using System.Diagnostics;
using System.Web.Mvc;
using System.Linq;

namespace Libvirt_WebManager.Areas.Network.Controllers
{
    public class EditController : Libvirt_WebManager.Controllers.CommonController
    {
        private Service.Network_Service _Service;
        public EditController()
        {
            _Service = new Service.Network_Service(new Libvirt_WebManager.Models.Validator(ModelState));
        }

        [HttpGet]
        public ActionResult _Partial_IndexMainContent(string host, string network)
        {
            var h = GetHost(host);
            var vm = new Models.Create_Network_Down();
            vm.Host = host;
            vm.Parent = network;
            vm.Outbound = new Models.Create_Network_QOS();
            vm.Inbound = new Models.Create_Network_QOS();
            using (var net = h.virNetworkLookupByName(network))
            {
                var xmldesc = net.virNetworkGetXMLDesc(Libvirt.virNetworkXMLFlags.VIR_DEFAULT);
                vm.name = xmldesc.name;
                vm.Forward_Type = xmldesc.Forward_Type;
                vm.ipv6 = xmldesc.ipv6;
                vm.uuid = xmldesc.uuid;
                vm.Configuration = Utilities.AutoMapper.Mapper<Models.Create_Network_Configuration>.Map(xmldesc.Configuration);

                if (xmldesc.QOS.Inbound != null)
                {
                    vm.Inbound_QOS = true;
                    vm.Inbound = Utilities.AutoMapper.Mapper<Models.Create_Network_QOS>.Map(xmldesc.QOS.Inbound);
                }
                if (xmldesc.QOS.Outbound != null)
                {
                    vm.Outbound_QOS = true;
                    vm.Outbound = Utilities.AutoMapper.Mapper<Models.Create_Network_QOS>.Map(xmldesc.QOS.Outbound);
                }
            }
            return PartialView(vm);
        }
        [HttpPost]
        public ActionResult _Partial_IndexMainContent(Models.Create_Network_Down vm)
        {
            if (ModelState.IsValid)
            {
                _Service.Edit(vm);
            }
            return PartialView("_Partial_Edit",vm);
        }
    }
}