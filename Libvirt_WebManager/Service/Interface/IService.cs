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
        protected Libvirt.CS_Objects.Host GetHost(string hostname)
        {
            Libvirt.CS_Objects.Host t = null;
            if (!VM_Manager.Instance.Connections.TryGetValue(hostname.ToLower(), out t))
            {
                _Validator.AddError("Host Does not Exist", "The host does not exist!");
            }
            return t;
        }
    }
}
