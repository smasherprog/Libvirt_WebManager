using Libvirt.Models.Interface;
using Libvirt.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Service.Concrete
{
    public class Storage_Pool_Validator : IService_Validator<Models.Concrete.Storage_Pool, CS_Objects.Host>
    {
        public void Validate(IValdiator v, Models.Concrete.Storage_Pool obj, CS_Objects.Host obj2)
        {
            using (var pool = obj2.virStoragePoolLookupByName(obj.name))
            {
                if (pool.IsValid)
                {
                    v.AddError("name", "A pool with that name already exists, try another!");
                    return;
                }
            }
        }

    }
}
