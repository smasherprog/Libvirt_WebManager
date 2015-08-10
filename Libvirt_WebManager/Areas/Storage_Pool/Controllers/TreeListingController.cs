using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Storage_Pool.Controllers
{
    public class TreeListingController : Libvirt_WebManager.Controllers.CommonController
    {
        private Service.Storage_Service _Storage_Service;
        public TreeListingController()
        {
            _Storage_Service = new Service.Storage_Service(new Libvirt_WebManager.Models.Validator(ModelState));
        }

        public ActionResult _Partial_Index(string host)
        {
            var vm = new Libvirt_WebManager.Areas.Storage_Pool.Models.Storage_Pool_TreeViewDown();
            var h = GetHost(host);
            Libvirt.CS_Objects.Storage_Pool[] p;
            h.virConnectListAllStoragePools(out p, Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_DEFAULT);
            AddToAutomaticDisposal(p);
            vm.Pools = p;
            vm.Host = host;
            return PartialView(vm);
        }
        public ActionResult _Partial_GetVolumes(string host, string pool)
        {
            var vm = new Models.Storage_Volume_TreeViewDown();
            var h = GetHost(host);
            vm.Host = host;
            vm.Parent = pool;
            using (var p = AddToAutomaticDisposal(h.virStoragePoolLookupByName(pool)))
            {
                Libvirt.CS_Objects.Storage_Volume[] volumes;
                p.virStoragePoolListAllVolumes(out volumes);
                AddToAutomaticDisposal(volumes);
                vm.Volumes = volumes;
            }
            return PartialView(vm);
        }

    }
}
