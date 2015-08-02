using Libvirt_Pinvoke.CS_Objects.Extensions;

namespace Libvirt_WebManager.Service
{
    public class Storage_Service : Interface.IService
    {
        public Storage_Service(Libvirt.Models.Interface.IValdiator v) : base(v) { }

        public void CreateVolume(ViewModels.Storage.Storage_Volume v, System.Web.HttpPostedFileBase File)
        {
            var volume = Utilities.AutoMapper.Mapper<Libvirt.Models.Concrete.Storage_Volume>.Map(v);
            if (volume.Volume_Type == Libvirt.Models.Concrete.Storage_Volume.Volume_Types.iso)
            {
                volume.Memory_Units = Libvirt.Models.Concrete.Memory_Allocation.UnitTypes.B;
                volume.capacity = volume.allocation = File.ContentLength;
            } else {
                volume.Memory_Units = Libvirt.Models.Concrete.Memory_Allocation.UnitTypes.GiB;
            }
            var h = GetHost(v.Host);
            if (!_Validator.IsValid()) return;
            using (var p = h.virStoragePoolLookupByName(v.Parent))
            {
                var t = new Libvirt.Service.Concrete.Storage_Volume_Validator();
                t.Validate(_Validator, volume, p);
                if (_Validator.IsValid())
                {
                    using (var storagevol = p.virStorageVolCreateXML(volume, Libvirt.virStorageVolCreateFlags.VIR_DEFAULT))
                    {
                        if (storagevol.IsValid)
                        {
                            if (volume.Volume_Type == Libvirt.Models.Concrete.Storage_Volume.Volume_Types.iso)
                            {
                                storagevol.Upload(h, File.InputStream);
                            }
                        }
                        else
                        {
                            _Validator.AddError("Storage Pool", "Storage Pool not valid");
                        }
                    }
                }
            }
        }

        public void CreatePool_Dir(ViewModels.Storage.Dir_Pool pool)
        {
            var h = GetHost(pool._Storage_Pool.Host);
            if (!_Validator.IsValid()) return;

            var p = new Libvirt.Models.Concrete.Storage_Pool();
            p.name = pool._Storage_Pool.name;
            var d = new Libvirt.Models.Concrete.Storage_Pool_Dir();
            p.Storage_Pool_Item = d;
            d.target_path = pool.path;
            using (var storagepool = h.virStoragePoolDefineXML(p))
            {
                var suc = storagepool.virStoragePoolBuild(Libvirt.virStoragePoolBuildFlags.VIR_STORAGE_POOL_BUILD_NEW);
                if (storagepool.virStoragePoolCreate() == 0)
                {//succesfully created the pool
                    if (pool.AutoStart) storagepool.virStoragePoolSetAutostart(1);
                }
            }

        }
    }
}