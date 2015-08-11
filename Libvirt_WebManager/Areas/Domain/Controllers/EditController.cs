using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Controllers
{
    public class EditController : Libvirt_WebManager.Controllers.CommonController
    {
        private Service.Domain_Service _Domain_Service;
        public EditController()
        {
            _Domain_Service = new Service.Domain_Service(new Libvirt_WebManager.Models.Validator(ModelState));
        }

        [HttpGet]
        public ActionResult _Partial_Index(string host, string domain)
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult _Partial_Details_MainContent(string host, string domain)
        {
            using(var d = GetHost(host).virDomainLookupByName(domain))
            {
                var vm = new Models.General_Metadata_VM();
                vm.Host = host;
                vm.Parent = domain;

                vm.Machine = d.virDomainGetXMLDesc(Libvirt.virDomainXMLFlags.VIR_DEFAULT);
                return PartialView(vm);
            }
         
        }
        [HttpPost]
        public ActionResult _Partial_Details_MainContent(Models.General_Metadata_VM vm)
        {
            return PartialView();
        }
        
    }
}