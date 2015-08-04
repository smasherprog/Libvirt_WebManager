using Libvirt.Models.Interface;
using Libvirt.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Service.Concrete
{
    public class Device_Validator : IService_Validator<Models.Concrete.Disk, CS_Objects.Host>
    {
        public void Validate(IValdiator v, Models.Concrete.Disk obj, CS_Objects.Host obj2)
        {
            if (obj.Source.GetType() == typeof(Libvirt.Models.Concrete.Device_Source_Volume))
            {
                var src = obj.Source as Libvirt.Models.Concrete.Device_Source_Volume;
                using (var pool = obj2.virStoragePoolLookupByName(src.pool))
                {
                    if (!pool.IsValid) v.AddError("Device.Source.pool", "Pool is invalid!");
                    using (var volume = pool.virStorageVolLookupByName(src.volume))
                    {
                        if (!volume.IsValid) v.AddError("Device.Source.volume", "Volume is invalid!");
                    }
                }
            }
        }
    }
    public class Device_Collection_Validator : IService_Validator<Libvirt.Models.Concrete.Drive_Collection, CS_Objects.Host>
    {
        public void Validate(IValdiator v, Libvirt.Models.Concrete.Drive_Collection obj, CS_Objects.Host obj2)
        {
            var d = new Device_Validator();
            foreach (var item in obj.Disks)
            {
                if (!v.IsValid()) break;
                d.Validate(v, item, obj2);
            }
        }
    }
}
