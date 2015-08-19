using System.Diagnostics;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Network.Controllers
{
    public class CreateController : Libvirt_WebManager.Controllers.CommonController
    {
        private Service.Network_Service _Service;
        public CreateController()
        {
            _Service = new Service.Network_Service(new Libvirt_WebManager.Models.Validator(ModelState));
        }
        [HttpGet]
        public ActionResult _Partial_Create(string host)
        {
            var vm = new Models.Create_Network_Down();
            vm.Host = host;
            vm.Parent = host;
            vm.Configuration = new Models.Create_Network_Configuration();
            vm.Outbound = new Models.Create_Network_QOS();
            vm.Inbound = new Models.Create_Network_QOS();

            return PartialView(vm);
        }
        [HttpPost]
        public ActionResult _Partial_Create(Models.Create_Network_Down vm)
        {
            if (ModelState.IsValid) _Service.Create(vm);
            return PartialView("~/Areas/Network/Views/Edit/_Partial_Edit.cshtml", vm);
        }
    }
}
