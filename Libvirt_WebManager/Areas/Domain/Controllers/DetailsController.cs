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
            return PartialView(GetInfo(host, domain));
        }
        public ActionResult Console(string host, string domain)
        {
            return View(GetInfo(host, domain));
        }
        public ActionResult _Partial_Stop(string host, string domain, bool gracefull)
        {
            using (var d = GetHost(host).virDomainLookupByName(domain))
            {
                if (d.IsValid)
                {
                    var state = Libvirt.virDomainState.VIR_DOMAIN_SHUTOFF;
                    int test = 0;
                    d.virDomainGetState(out state, out test);
                    if (state != Libvirt.virDomainState.VIR_DOMAIN_SHUTOFF || state != Libvirt.virDomainState.VIR_DOMAIN_SHUTDOWN)
                    {
                        if (gracefull) d.virDomainShutdown();
                        else d.virDomainDestroy();
                    }
                }
            }
            return PartialView("_Partial_DomainControlOptions", GetInfo(host, domain));
        }
        public ActionResult _Partial_Start(string host, string domain)
        {

            using (var d = GetHost(host).virDomainLookupByName(domain))
            {
                if (d.IsValid)
                {
                    var state = Libvirt.virDomainState.VIR_DOMAIN_SHUTOFF;
                    int test = 0;
                    d.virDomainGetState(out state, out test);
                    if (state == Libvirt.virDomainState.VIR_DOMAIN_SHUTOFF) d.virDomainCreate();
                }
            }
            var info = GetInfo(host, domain);
            if(info.State == Libvirt.virDomainState.VIR_DOMAIN_RUNNING) return PartialView("_Partial_DomainControlOptions_Started", info);
            else return PartialView("_Partial_DomainControlOptions", info);
        }

        private ViewModels.NoVNC.ConnectionInfo GetInfo(string host, string domain)
        {
            var h = GetHost(host);
            using (var d = h.virDomainLookupByName(domain))
            {
                Libvirt.virDomainState state;
                int i = 0;
                d.virDomainGetState(out state, out i);
                var dom = d.virDomainGetXMLDesc(Libvirt.virDomainXMLFlags.VIR_DEFAULT);
                return new ViewModels.NoVNC.ConnectionInfo { Machine = dom, State = state, Host = host, Path = "websockify", Password = dom.graphics.passwd, Port = dom.graphics.websocket.HasValue ? dom.graphics.websocket.Value.ToString() : "5700" };
            }
        }
    }
}