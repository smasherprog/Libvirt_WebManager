using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
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
   
        public ActionResult _Partial_OS_PoolVolume_Selector(ViewModels.Domain.PoolVolume_Selector_VM vm)
        {
            Libvirt.CS_Objects.Storage_Pool[] pools = new Libvirt.CS_Objects.Storage_Pool[0];
            var h = GetHost(vm.Host);
            h.virConnectListAllStoragePools(out pools, Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_ACTIVE);
            AddToAutomaticDisposal(pools);
            return PartialView(new ViewModels.Domain.PoolVolume_Selector_VM_Down { Pools = pools, Selector =vm}  );
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
    }
}
