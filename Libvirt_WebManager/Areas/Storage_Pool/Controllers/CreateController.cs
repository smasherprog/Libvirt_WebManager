using System.Diagnostics;
using System.Web.Mvc;
using System.Linq;

namespace Libvirt_WebManager.Areas.Storage_Pool.Controllers
{
    public class CreateController : Libvirt_WebManager.Controllers.CommonController
    {
        private Service.Storage_Service _Storage_Service;
        public CreateController()
        {
            _Storage_Service = new Service.Storage_Service(new Libvirt_WebManager.Models.Validator(ModelState));
        }
        [HttpGet]
        public ActionResult _Partial_CreatePool(string host)
        {
            return PartialView(new Libvirt_WebManager.Areas.Storage_Pool.Models.Storage_Pool { Host = host });
        }
        [HttpPost]
        public ActionResult _Partial_CreatePool(Libvirt_WebManager.Areas.Storage_Pool.Models.Storage_Pool pool)
        {
            if (ModelState.IsValid)
            {
                var t = new Libvirt.Service.Concrete.Storage_Pool_Validator();
                var v = Utilities.AutoMapper.Mapper<Libvirt.Models.Concrete.Storage_Pool>.Map(pool);
                var h = GetHost(pool.Host);
                if (ModelState.IsValid)
                {
                    t.Validate(new Libvirt_WebManager.Models.Validator(ModelState), v, h);
                    if (ModelState.IsValid)
                    {

                        if (pool.pool_type == Libvirt.Models.Interface.IStorage_Pool_Item.Pool_Types.dir)
                        {
                            return PartialView("_Partial_CreateDirPool", new Libvirt_WebManager.Areas.Storage_Pool.Models.Dir_Pool { Storage_Pool = pool });
                        }
                        else if (pool.pool_type == Libvirt.Models.Interface.IStorage_Pool_Item.Pool_Types.disk)
                        {
                            using (var nodes = h.virConnectListAllNodeDevices(Libvirt.virConnectListAllNodeDeviceFlags.VIR_CONNECT_LIST_NODE_DEVICES_CAP_STORAGE))
                            using (var pools = h.virConnectListAllStoragePools(Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_DISK))
                            {
                                var poolsxml = pools.Select(a => a.virStoragePoolGetXMLDesc(Libvirt.virStorageXMLFlags.VIR_DEFAULT)).Select(b => b.Storage_Pool_Item as Libvirt.Models.Concrete.Storage_Pool_Disk);
                                var nodesxml = nodes.Select(a => a.virNodeDeviceGetXMLDesc() as Libvirt.Models.Concrete.Node.Storage)
                                    .Where(a => !a.block.ToLower().Contains("/sda") 
                                    && !a.drive_type.ToLower().Contains("cdrom")
                                    && !poolsxml.Any(b=>b.device_path.ToLower().Contains(a.block.ToLower())));


                                return PartialView("_Partial_CreateDiskPool", new Libvirt_WebManager.Areas.Storage_Pool.Models.Disk_Pool { Storage_Pool = pool, Devices = nodesxml.ToList() });
                            }
                        }
                    }
                }
            }
            return PartialView(pool);
        }
        [HttpPost]
        public ActionResult _Partial_CreateDirPool(Libvirt_WebManager.Areas.Storage_Pool.Models.Dir_Pool pool)
        {
            if (ModelState.IsValid)
            {
                _Storage_Service.CreatePool(pool);
                return CloseDialog();
            }
            return PartialView(pool);
        }
        [HttpPost]
        public ActionResult _Partial_CreateDiskPool(Libvirt_WebManager.Areas.Storage_Pool.Models.Disk_Pool pool)
        {
            if (ModelState.IsValid)
            {
                _Storage_Service.CreatePool(pool);
                return CloseDialog();
            }
            return PartialView(pool);
        }
        [HttpGet]
        public ActionResult _Partial_CreateVolume(string host, string pool)
        {
            return PartialView(GetStorage_Volume_Down(new Models.Storage_Volume { Host = host, Parent = pool }));
        }
        [HttpPost]
        public ActionResult _Partial_CreateVolume(Models.Storage_Volume volume)
        {
            if (ModelState.IsValid) _Storage_Service.CreateVolume(volume);
            if (ModelState.IsValid) return CloseDialog();
            return PartialView(GetStorage_Volume_Down(volume));
        }
        private Models.Storage_Volume_Down GetStorage_Volume_Down(Libvirt_WebManager.Areas.Storage_Pool.Models.Storage_Volume volume)
        {
            var h = GetHost(volume.Host);
            using (var p = h.virStoragePoolLookupByName(volume.Parent))
            {
                var svd = new Models.Storage_Volume_Down();
                svd.Volume = volume;
                if (p.IsValid)
                {
                    Libvirt._virStoragePoolInfo info;
                    p.virStoragePoolGetInfo(out info);
                    svd.PoolInfo = info;
                }
                return svd;
            }
        }

        [HttpGet]
        public ActionResult VolumeUpload(Areas.Storage_Pool.Models.Storage_Volume_Upload d)
        {
            return View(d);
        }
    }
}
