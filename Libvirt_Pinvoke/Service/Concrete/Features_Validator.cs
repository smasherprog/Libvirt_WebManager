using Libvirt.Models.Interface;
using Libvirt.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Service.Concrete
{
    public class Features_Validator : IService_Validator<Models.Concrete.Features, CS_Objects.Host>
    {
        public void Validate(IValdiator v, Models.Concrete.Features obj, CS_Objects.Host obj2)
        {

        }

    }
}
