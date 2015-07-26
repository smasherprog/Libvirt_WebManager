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

            Libvirt.CS_Objects.Domain[] domains;
            if (obj2.virConnectListAllDomains(out domains, Libvirt.virConnectListAllDomainsFlags.VIR_CONNECT_LIST_DOMAINS_PERSISTENT | Libvirt.virConnectListAllDomainsFlags.VIR_CONNECT_LIST_DOMAINS_TRANSIENT) > 0)
            {
                foreach (var item in domains)
                {
                    if (item.virDomainGetName() == obj.name)
                    {
                        v.AddError("General_Metadata.name", "A VM with that name already exists, try another!");
                        break;
                    }
                }
                foreach (var item in domains)
                {
                    item.Dispose();
                }
            }
        }

    }
}
