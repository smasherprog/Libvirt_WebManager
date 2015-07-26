using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.CS_Objects
{
    public class Interface : IDisposable
    {
        private virInterfacePtr _virInterfacePtr;
        public bool IsValid { get { return _virInterfacePtr.Pointer != IntPtr.Zero; } }
        public Interface(virInterfacePtr ptr)
        {
            _virInterfacePtr = ptr;
        }
        public int virInterfaceCreate()
        {
            return API.virInterfaceCreate(_virInterfacePtr);
        }

        public int virInterfaceDestroy()
        {
            return API.virInterfaceDestroy(_virInterfacePtr);
        }
        public string virInterfaceGetMACString()
        {
            return API.virInterfaceGetMACString(_virInterfacePtr);
        }
        public string virInterfaceGetName()
        {
            return API.virInterfaceGetName(_virInterfacePtr);
        }
        public string virInterfaceGetXMLDesc(virInterfaceXMLFlags flags)
        {
            return API.virInterfaceGetXMLDesc(_virInterfacePtr, flags);
        }
        public int virInterfaceIsActive()
        {
            return API.virInterfaceIsActive(_virInterfacePtr);
        }

        public int virInterfaceUndefine()
        {
            return API.virInterfaceUndefine(_virInterfacePtr);
        }
        public void Dispose()
        {
            _virInterfacePtr.Dispose();
        }

    }
}
