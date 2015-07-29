using Libvirt.Models.Interface;
using Libvirt.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Service.Concrete
{
    public class Storage_Volume_Validator : IService_Validator<Models.Concrete.Storage_Volume, CS_Objects.Storage_Pool>
    {
        public void Validate(IValdiator v, Models.Concrete.Storage_Volume obj, CS_Objects.Storage_Pool obj2)
        {
            CS_Objects.Storage_Volume[] vols;
            if (obj2.virStoragePoolListAllVolumes(out vols) > -1)
            {
                if(vols.Any(a=>a.virStorageVolGetName().ToLower() == obj.name.ToLower()))
                {
                    v.AddError("name", "A volume with that name already exists, try another!");
                }

            }
            foreach (var item in vols) item.Dispose();
        }
    }
}
