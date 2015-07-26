using Libvirt.Models.Interface;
using Libvirt.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Service.Concrete
{
    public class BIOS_Bootloader_Validator : IService_Validator<Models.Concrete.BIOS_Bootloader, CS_Objects.Host>
    {
        public void Validate(IValdiator v, Models.Concrete.BIOS_Bootloader obj, CS_Objects.Host obj2)
        {

        }
    }
}
