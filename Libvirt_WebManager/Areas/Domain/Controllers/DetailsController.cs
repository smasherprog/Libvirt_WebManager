using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Controllers
{
    public class DetailsController : Libvirt_WebManager.Controllers.CommonController
    {
        private Service.Domain_Service _Domain_Service;
        public DetailsController()
        {
            _Domain_Service = new Service.Domain_Service(new Libvirt_WebManager.Models.Validator(ModelState));
        }

        [HttpGet]
        public ActionResult _Partial_MainContent(string host, string domain)
        {
            var vm = new Models.Domain_Down();
            vm.Domain = GetHost(host).virDomainLookupByName(domain);
            AddToAutomaticDisposal(vm.Domain);
            vm.Host = host;
            vm.Parent = host;
            return PartialView(vm);
        }
        public ActionResult _Partial_Console(string host, string domain)
        {
            var h = GetHost(host);
            using (var d = h.virDomainLookupByName(domain))
            {
                Libvirt.virDomainState state;
                int i = 0;
                d.virDomainGetState(out state, out i);
                var dom = d.virDomainGetXMLDesc(Libvirt.virDomainXMLFlags.VIR_DEFAULT);
                return PartialView(new ViewModels.NoVNC.ConnectionInfo { State = state, Host = host, Path = "websockify", Password = dom.graphics.passwd, Port = dom.graphics.websocket.HasValue ? dom.graphics.websocket.Value.ToString() : "5700" });
            }
        }
    }
}