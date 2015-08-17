using System.Diagnostics;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Network.Controllers
{
    public class CreateController : Libvirt_WebManager.Controllers.CommonController
    {
   
        [HttpGet]
        public ActionResult _Partial_Create(string host)
        {
            var vm = new Models.Create_Network_Down();
            vm.Host = host;
            vm.Parent = host;
            return PartialView(vm);
        }
        [HttpPost]
        public ActionResult _Partial_Create(Models.Create_Network_Down vm)
        {
            return PartialView("~/Areas/Network/Views/Edit/_Partial_Edit.cshtml", vm);
        }
    }
}
