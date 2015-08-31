using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Controllers
{
    public class CreateController : Libvirt_WebManager.Controllers.CommonController
    {
        private Service.Domain_Service _Domain_Service;
        public CreateController()
        {
            _Domain_Service = new Service.Domain_Service(new Libvirt_WebManager.Models.Validator(ModelState));
        }

        [HttpGet]
        public ActionResult _Partial_Create(string host)
        {
            return PartialView(GetDomainDown(host));
        }
        [HttpPost]
        public ActionResult _Partial_Create(Libvirt_WebManager.Areas.Domain.Models.New_Domain_VM domain)
        {
            if (ModelState.IsValid)
            {
                _Domain_Service.QuickCreate(domain);
            }
            if (ModelState.IsValid) return CloseDialog();
            var d = GetDomainDown(domain.Host);
            d.Domain = domain;
            return PartialView(d);
        }
        public ActionResult _Partial_OS_PoolVolume_Selector(Libvirt_WebManager.Areas.Domain.Models.BasePoolVolume_Selector pselector)
        {
            var h = GetHost(pselector.Host);
            var pools = h.virConnectListAllStoragePools( Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_DEFAULT);
            AddToAutomaticDisposal(pools);
            var vm = Utilities.AutoMapper.Mapper<Libvirt_WebManager.Areas.Domain.Models.PoolVolume_Selector_Down>.Map(pselector);
            vm.Pools = pools;
            return PartialView(vm);
        }

        public ActionResult _Partial_OS_Volume_Selector(Libvirt_WebManager.Areas.Domain.Models.BasePoolVolume_Selector pselector)
        {
            var h = GetHost(pselector.Host);
            var p = h.virStoragePoolLookupByName(pselector.Parent);
            AddToAutomaticDisposal(p);
            var vm = Utilities.AutoMapper.Mapper<Libvirt_WebManager.Areas.Domain.Models.PoolVolume_Selector>.Map(pselector);

            Libvirt.CS_Objects.Storage_Volume[] vols;
            p.virStoragePoolListAllVolumes(out vols);
            AddToAutomaticDisposal(vols);
            vm.Volumes = vols;

            return PartialView(vm);
        }
        private Models.New_Domain_Down_VM GetDomainDown(string host)
        {
            var h = GetHost(host);
            Libvirt._virNodeInfo i;
            h.virNodeGetInfo(out i);
            var vm = new Libvirt_WebManager.Areas.Domain.Models.New_Domain_Down_VM();
            vm.Domain = new Libvirt_WebManager.Areas.Domain.Models.New_Domain_VM();
            vm.Host = h;
            vm.Domain.Cpus = 1;
            vm.Domain.Ram = System.Math.Min(512, i.memory / 1024);
            vm.Domain.Host = host;
            return vm;
        }
    }
}