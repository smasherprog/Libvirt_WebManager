using Libvirt_Pinvoke.CS_Objects.Extensions;

namespace Libvirt_WebManager.Service
{
    public class Domain_Service : Interface.IService
    {
        public Domain_Service(Libvirt.Models.Interface.IValdiator v) : base(v) { }

        public void CreateDomain(ViewModels.Storage.Storage_Volume v)
        {
            var volume = Utilities.AutoMapper.Mapper<Libvirt.Models.Concrete.Storage_Volume>.Map(v);
            var h = GetHost(v.Host);
            if (!_Validator.IsValid()) return;
            using (var p = h.virStoragePoolLookupByName(v.Parent))
            {
                volume.Memory_Units = Libvirt.Models.Concrete.Memory_Allocation.UnitTypes.GB;
                var t = new Libvirt.Service.Concrete.Storage_Volume_Validator();
                t.Validate(_Validator, volume, p);
                if (_Validator.IsValid())
                {
                    using (var storagevol = p.virStorageVolCreateXML(volume, Libvirt.virStorageVolCreateFlags.VIR_DEFAULT))
                    {
                       
                    }
                }
            }
        }

    }
}