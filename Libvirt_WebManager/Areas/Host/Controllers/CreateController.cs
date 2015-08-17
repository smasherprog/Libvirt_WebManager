using System.Diagnostics;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Host.Controllers
{
    public class CreateController : Libvirt_WebManager.Controllers.CommonController
    {
   
        [HttpGet]
        public ActionResult _Partial_Create()
        {
            return PartialView(new Libvirt_WebManager.Areas.Host.Models.virConnectOpen());
        }
        [HttpPost]
        public ActionResult _Partial_Create(Libvirt_WebManager.Areas.Host.Models.virConnectOpen obj)
        {
            if (ModelState.IsValid)
            {
                if (Libvirt_WebManager.Service.VM_Manager.Instance.virConnectOpen(obj.host_or_ip)!=null) return CloseDialog();
            }
            return PartialView(obj);
        }
    }
}
