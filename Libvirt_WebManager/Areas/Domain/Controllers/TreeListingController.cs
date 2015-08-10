using System.Diagnostics;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Controllers
{
    public class TreeListingController : Libvirt_WebManager.Controllers.CommonController
    {
        private Service.Domain_Service _Domain_Service;
        public TreeListingController()
        {
            _Domain_Service = new Service.Domain_Service(new Libvirt_WebManager.Models.Validator(ModelState));
        }
        public ActionResult _Partial_Index(string host)
        {
            var vm = new Models.Domain_List_Down();
            Libvirt.CS_Objects.Domain[] ds;
            GetHost(host).virConnectListAllDomains(out ds, Libvirt.virConnectListAllDomainsFlags.VIR_DEFAULT);
            AddToAutomaticDisposal(ds);
            vm.Host = host;
            vm.Parent = host;
            vm.Domains = ds;
            return PartialView(vm);
        }

    }
}
