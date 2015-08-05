using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.CS_Objects
{
    public class Node_Device : IDisposable
    {
        private virNodeDevicePtr _virNodeDevicePtr;
        public bool IsValid { get { return _virNodeDevicePtr.Pointer != IntPtr.Zero; } }
        public Node_Device(virNodeDevicePtr ptr)
        {
            _virNodeDevicePtr = ptr;
        }
        public void Dispose()
        {
            _virNodeDevicePtr.Dispose();
        }

    }
}
