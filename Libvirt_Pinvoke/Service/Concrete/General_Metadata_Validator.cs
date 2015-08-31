using Libvirt.Models.Interface;
using Libvirt.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Service.Concrete
{
    public class General_Metadata_Validator : IService_Validator<Models.Concrete.General_Metadata, CS_Objects.Host>
    {
        public void Validate(IValdiator v, Models.Concrete.General_Metadata obj, CS_Objects.Host obj2)
        {
            using (var d = obj2.virConnectListAllDomains(Libvirt.virConnectListAllDomainsFlags.VIR_DEFAULT))
            {
                if (d.Any(a => a.virDomainGetName() == obj.name))
                {
                    v.AddError("General_Metadata.name", "A VM with that name already exists, try another!");
                }
            }
        }
    }
}
