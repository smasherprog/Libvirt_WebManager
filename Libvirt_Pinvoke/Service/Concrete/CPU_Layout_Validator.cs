using Libvirt.Models.Interface;
using Libvirt.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Service.Concrete
{
    public class CPU_Layout_Validator : IService_Validator<Models.Concrete.CPU_Layout, CS_Objects.Host>
    {
        public void Validate(IValdiator v, Models.Concrete.CPU_Layout obj, CS_Objects.Host obj2)
        {
            Libvirt._virNodeInfo info;
            obj2.virNodeGetInfo(out info);
            if (obj.vCpu_Count > info.cpus)
            {
                v.AddError("vCpu_Count", "Cannot exceed the Maximum Available!");
            }
        }

    }
}
