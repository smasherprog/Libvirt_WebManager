using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
using System.Linq;

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
            var ds = h.virConnectListAllDomains(Libvirt.virConnectListAllDomainsFlags.VIR_DEFAULT);
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

        [HttpGet]
        public ActionResult _Partial_Migrate(string host, string domain)
        {
            var vm = new Models.Domain_Migrate_Down();
            vm.Domain_Migrate = new Models.Domain_Migrate_VM { Host = host, Parent = domain, Persist_On_Dst = true };
            vm.Hosts = Libvirt_WebManager.Service.VM_Manager.Instance.Hosts.Where(a => a.ToLower() != host.ToLower()).Select(b => new SelectListItem { Text = b, Value = b }).ToList();

            return PartialView(vm);
        }


        [HttpPost]
        public ActionResult _Partial_Migrate(Models.Domain_Migrate_VM Domain_Migrate)
        {
            if (ModelState.IsValid)
            {
                using (var d = GetHost(Domain_Migrate.Host).virDomainLookupByName(Domain_Migrate.Parent))
                {

                    var options = Libvirt.virDomainMigrateFlags.VIR_MIGRATE_NON_SHARED_DISK | Libvirt.virDomainMigrateFlags.VIR_MIGRATE_TUNNELLED | Libvirt.virDomainMigrateFlags.VIR_MIGRATE_PEER2PEER;
                    Libvirt.virDomainState state;
                    int reason = 0;
                    d.virDomainGetState(out state, out reason);
                    if (state == Libvirt.virDomainState.VIR_DOMAIN_RUNNING) options |= Libvirt.virDomainMigrateFlags.VIR_MIGRATE_LIVE;
                    else options |= Libvirt.virDomainMigrateFlags.VIR_MIGRATE_OFFLINE;
                    if (Domain_Migrate.Persist_On_Dst) options |= Libvirt.virDomainMigrateFlags.VIR_MIGRATE_PERSIST_DEST;
                    if (Domain_Migrate.Delete_On_Src) options |= Libvirt.virDomainMigrateFlags.VIR_MIGRATE_UNDEFINE_SOURCE;
                    var success = d.virDomainMigrateToURI(GenerateURIFromHostname(Domain_Migrate.Dst_Domain), options);

                    Debug.WriteLine("got here");

                }
            }
            var vm = new Models.Domain_Migrate_Down();
            vm.Domain_Migrate = Domain_Migrate;
            vm.Hosts = Libvirt_WebManager.Service.VM_Manager.Instance.Hosts.Where(a => a.ToLower() != Domain_Migrate.Host.ToLower()).Select(b => new SelectListItem { Text = b, Value = b }).ToList();

            return PartialView(vm);
        }
        [HttpPost]
        public ActionResult _Partial_AutoStart(string host, string domain, bool autostart)
        {
            var h = GetHost(host);
            var d = h.virDomainLookupByName(domain);
            AddToAutomaticDisposal(d);
            if (autostart) d.virDomainSetAutostart(1);
            else d.virDomainSetAutostart(0);
            return PartialView("_Partial_TableRowDetails", new Libvirt_WebManager.Areas.Domain.Models.Domain_Down { Host = host, Parent = host, Domain = d });
        }
    }
}
