using System.Diagnostics;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Controllers
{
    public class ListingController : Libvirt_WebManager.Controllers.CommonController
    {
        private Service.Domain_Service _Domain_Service;
        public ListingController()
        {
            _Domain_Service = new Service.Domain_Service(new Libvirt_WebManager.Models.Validator(ModelState));
        }
 
        public ActionResult _Partial_MainContent(string host)
        {
            var h = GetHost(host);
            Libvirt.CS_Objects.Domain[] ds;
            h.virConnectListAllDomains(out ds, Libvirt.virConnectListAllDomainsFlags.VIR_DEFAULT);
            AddToAutomaticDisposal(ds);
            return PartialView(new Libvirt_WebManager.Areas.Domain.Models.Domain_List_Down { Host = host, Parent = host, Domains = ds });
        }
        public ActionResult _Partial_Delete(string host, string domain)
        {
            var h = GetHost(host);
            using (var d = h.virDomainLookupByName(domain))
            {
                if (d.IsValid)
                {
                    var state = Libvirt.virDomainState.VIR_DOMAIN_SHUTOFF;
                    int test = 0;
                    d.virDomainGetState(out state, out test);
                    if (state != Libvirt.virDomainState.VIR_DOMAIN_SHUTOFF) d.virDomainDestroy();
                    d.virDomainUndefine();
                }
            }
            return Content("");
        }
        public ActionResult _Partial_Stop(string host, string domain, bool gracefull)
        {
            var h = GetHost(host);
            var d = h.virDomainLookupByName(domain);
            AddToAutomaticDisposal(d);
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
            return PartialView("_Partial_TableRowDetails", new Libvirt_WebManager.Areas.Domain.Models.Domain_Down { Host = host, Parent = host, Domain = d });
        }
        public ActionResult _Partial_Start(string host, string domain)
        {
            var h = GetHost(host);
            var d = h.virDomainLookupByName(domain);
            AddToAutomaticDisposal(d);
            if (d.IsValid)
            {
                var state = Libvirt.virDomainState.VIR_DOMAIN_SHUTOFF;
                int test = 0;
                d.virDomainGetState(out state, out test);
                if (state == Libvirt.virDomainState.VIR_DOMAIN_SHUTOFF) d.virDomainCreate();
            }
            return PartialView("_Partial_TableRowDetails", new Libvirt_WebManager.Areas.Domain.Models.Domain_Down { Host = host, Parent = host, Domain = d });
        }
 


    }
}
