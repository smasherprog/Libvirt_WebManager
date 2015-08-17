using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt_WebManager.Service.Interface
{
    public abstract class IService
    {
        protected Libvirt.Models.Interface.IValdiator _Validator {get; set;}
        public IService(Libvirt.Models.Interface.IValdiator v) { _Validator = v; }
      
    }
}
