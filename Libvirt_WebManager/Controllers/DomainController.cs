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
            Libvirt.CS_Objects.Storage_Pool[] pools = new Libvirt.CS_Objects.Storage_Pool[0];
            var h = GetHost(Host);
            h.virConnectListAllStoragePools(out pools, Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_DEFAULT);
            AddToAutomaticDisposal(pools);
            ViewBag.Host = Host;
            return PartialView(pools);
        }

        public ActionResult _Partial_OS_Volume_Selector(string Host, string pool)
        {
            var h = GetHost(Host);
            var p = h.virStoragePoolLookupByName(pool);
            AddToAutomaticDisposal(p);
            return PartialView(p);
        }

    }
}
