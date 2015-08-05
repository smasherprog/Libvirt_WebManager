using System;
using System.Web.Mvc;

namespace Libvirt_WebManager.Controllers
{
    public class DomainController : CommonController
    {
        private Service.Domain_Service _Domain_Service;
        public DomainController()
        {
            _Domain_Service = new Service.Domain_Service(new Libvirt_WebManager.Models.Validator(ModelState));
        }
        [HttpGet]
        public ActionResult _Partial_NewDomain(string host)
        {
            return View(GetDomainDown(host));
        }
        [HttpPost]
        public ActionResult _Partial_NewDomain(Libvirt_WebManager.ViewModels.Domain.New_Domain_VM domain)
        {
            if (ModelState.IsValid)
            {
                _Domain_Service.CreateDomain(domain);
            }
            var d = GetDomainDown(domain.Host);
            d.Domain = domain;
            return View(d);
        }
        public ActionResult _Partial_Domain_Listing_MainContent(string host)
        {
            var h = GetHost(host);
            Libvirt.CS_Objects.Domain[] ds;
            h.virConnectListAllDomains(out ds, Libvirt.virConnectListAllDomainsFlags.VIR_DEFAULT);
            AddToAutomaticDisposal(ds);
            return PartialView(new ViewModels.Domain.Domain_List_Down { Host = host, Parent = host, Domains = ds });
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
            return PartialView("_Partial_Domain_TableRowDetails", new Libvirt_WebManager.ViewModels.Domain.Domain_Down { Host = host, Parent = host, Domain = d });
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
            return PartialView("_Partial_Domain_TableRowDetails", new Libvirt_WebManager.ViewModels.Domain.Domain_Down { Host = host, Parent = host, Domain = d });
        }
        private ViewModels.Domain.New_Domain_Down_VM GetDomainDown(string host)
        {
            var h = GetHost(host);
            Libvirt._virNodeInfo i;
            h.virNodeGetInfo(out i);
            var vm = new Libvirt_WebManager.ViewModels.Domain.New_Domain_Down_VM();
            vm.Domain = new ViewModels.Domain.New_Domain_VM();
            vm.Host = h;
            vm.Domain.Cpus = 1;
            vm.Domain.Ram = Math.Min(512, i.memory / 1024);
            vm.Domain.Host = host;
            return vm;
        }
        public ActionResult _Partial_OS_PoolVolume_Selector(ViewModels.Domain.BasePoolVolume_Selector pselector)
        {
            Libvirt.CS_Objects.Storage_Pool[] pools;
            var h = GetHost(pselector.Host);
            h.virConnectListAllStoragePools(out pools, Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_DEFAULT);
            AddToAutomaticDisposal(pools);
            var vm = Utilities.AutoMapper.Mapper<ViewModels.Domain.PoolVolume_Selector_Down>.Map(pselector);
            vm.Pools = pools;
            return PartialView(vm);
        }

        public ActionResult _Partial_OS_Volume_Selector(ViewModels.Domain.BasePoolVolume_Selector pselector)
        {
            var h = GetHost(pselector.Host);
            var p = h.virStoragePoolLookupByName(pselector.Parent);
            AddToAutomaticDisposal(p);
            var vm = Utilities.AutoMapper.Mapper<ViewModels.Domain.PoolVolume_Selector>.Map(pselector);

            Libvirt.CS_Objects.Storage_Volume[] vols;
            p.virStoragePoolListAllVolumes(out vols);
            AddToAutomaticDisposal(vols);
            vm.Volumes = vols;

            return PartialView(vm);
        }

    }
}
