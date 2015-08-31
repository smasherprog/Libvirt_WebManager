using Libvirt_Pinvoke.CS_Objects.Extensions;
using System.Linq;

namespace Libvirt_WebManager.Service
{
    public class Storage_Service : Interface.IService
    {
        public Storage_Service(Libvirt.Models.Interface.IValdiator v) : base(v) { }

        public void CreateVolume(Libvirt_WebManager.Areas.Storage_Pool.Models.Storage_Volume v)
        {
            var volume = Utilities.AutoMapper.Mapper<Libvirt.Models.Concrete.Storage_Volume>.Map(v);
            var splits = volume.name.Split('.');
            if (splits.Length > 1) volume.name = splits[0];
            if (v.Volume_Type == Libvirt.Models.Concrete.Storage_Volume.Volume_Types.raw) volume.name += ".img";
            else volume.name += "." + v.Volume_Type.ToString();
            volume.Memory_Units = Libvirt.Models.Concrete.Memory_Allocation.UnitTypes.GiB;
          
            var h = Service.VM_Manager.Instance.virConnectOpen(v.Host);
            if (!_Validator.IsValid()) return;
            using (var p = h.virStoragePoolLookupByName(v.Parent))
            {
                var t = new Libvirt.Service.Concrete.Storage_Volume_Validator();
                t.Validate(_Validator, volume, p);
                if (_Validator.IsValid())
                {
                    using (var storagevol = p.virStorageVolCreateXML(volume, Libvirt.virStorageVolCreateFlags.VIR_DEFAULT))
                    {
                        if (!storagevol.IsValid) { 
                            _Validator.AddError("Storage_Volue", "Storage Volume create Failed!");
                        }
                    }
                }
            }
        }

        public void CreatePool(Libvirt_WebManager.Areas.Storage_Pool.Models.Dir_Pool pool)
        {
            var h = Service.VM_Manager.Instance.virConnectOpen(pool.Storage_Pool.Host);
         
            if (!_Validator.IsValid()) return;

            var p = new Libvirt.Models.Concrete.Storage_Pool();
            p.name = pool.Storage_Pool.name;
            var d = new Libvirt.Models.Concrete.Storage_Pool_Dir();
            p.Storage_Pool_Item = d;
            d.target_path = pool.path;
            using (var storagepool = h.virStoragePoolDefineXML(p))
            {
                if (pool.Build) storagepool.virStoragePoolBuild(Libvirt.virStoragePoolBuildFlags.VIR_STORAGE_POOL_BUILD_NEW);
                storagepool.virStoragePoolCreate();
                if (pool.AutoStart) storagepool.virStoragePoolSetAutostart(1);
            }

        }
        public void CreatePool(Libvirt_WebManager.Areas.Storage_Pool.Models.Disk_Pool pool)
        {
            var h = Service.VM_Manager.Instance.virConnectOpen(pool.Storage_Pool.Host);

            if (!_Validator.IsValid()) return;

            var p = new Libvirt.Models.Concrete.Storage_Pool();
            p.name = pool.Storage_Pool.name;
            var d = new Libvirt.Models.Concrete.Storage_Pool_Disk();
            p.Storage_Pool_Item = d;
            d.target_path = "/"+pool.path.Split('/').FirstOrDefault(a => !string.IsNullOrWhiteSpace(a) && a.Length > 1);
            d.device_path = pool.path;

            using (var storagepool = h.virStoragePoolDefineXML(p))
            {
                if(pool.Build) storagepool.virStoragePoolBuild(Libvirt.virStoragePoolBuildFlags.VIR_STORAGE_POOL_BUILD_NEW);
                storagepool.virStoragePoolCreate();
                if (pool.AutoStart) storagepool.virStoragePoolSetAutostart(1);
                
            }
        }

       
    }
}