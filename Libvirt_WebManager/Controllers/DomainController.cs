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
        [HttpGet]
        public ActionResult _Partial_NewDomain(string host)
        {
            return View(GetDomainDown(host));
        }
        [HttpPost]
        public ActionResult _Partial_NewDomain(Libvirt_WebManager.ViewModels.Domain.New_Domain_VM domain)
        {
            var d = GetDomainDown(domain.Host);
            d.Domain = domain;
            return View(d);
        }
        public ActionResult _Partial_PoolVolume_Selector(string host)
        {
            Libvirt.CS_Objects.Storage_Pool[] pools = new Libvirt.CS_Objects.Storage_Pool[0];
            var h = GetHost(host);
            h.virConnectListAllStoragePools(out pools, Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_DEFAULT);
            AddToAutomaticDisposal(pools);
            return PartialView(pools);
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
