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
            return PartialView(new ViewModels.Domain.Domain_Down { Host = host, Parent = host, Domains = ds } );
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
        public ActionResult _Partial_OS_PoolVolume_Selector(string Host)
        {
            Libvirt.CS_Objects.Storage_Pool[] pools;
            var h = GetHost(Host);
            h.virConnectListAllStoragePools(out pools, Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_DEFAULT);
            AddToAutomaticDisposal(pools);
            var vm = new ViewModels.Domain.PoolVolume_Selector_Down();
            vm.Pools = pools;
            vm.Host = Host;
            return PartialView(vm);
        }

        public ActionResult _Partial_OS_Volume_Selector(string Host, string pool)
        {
            var h = GetHost(Host);
            var p = h.virStoragePoolLookupByName(pool);
            AddToAutomaticDisposal(p);
            var vm = new Libvirt_WebManager.ViewModels.Domain.PoolVolume_Selector();
            vm.Parent = pool;
            Libvirt.CS_Objects.Storage_Volume[] vols;
            p.virStoragePoolListAllVolumes(out vols);
            AddToAutomaticDisposal(vols);
            vm.Volumes = vols;
            vm.Host = Host;
           
            return PartialView(p);
        }

    }
}
