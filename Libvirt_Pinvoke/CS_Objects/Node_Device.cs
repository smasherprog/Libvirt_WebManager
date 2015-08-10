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
        public int virNodeDeviceDestroy()
        {
            return API.virNodeDeviceDestroy(_virNodeDevicePtr);
        }
        public int virNodeDeviceDetachFlags(string driverName)
        {
            return API.virNodeDeviceDetachFlags(_virNodeDevicePtr, driverName);
        }
        public int virNodeDeviceDettach()
        {
            return API.virNodeDeviceDettach(_virNodeDevicePtr);
        }
        public string virNodeDeviceGetName()
        {
            return API.virNodeDeviceGetName(_virNodeDevicePtr);
        }
        public string virNodeDeviceGetParent()
        {
            return API.virNodeDeviceGetParent(_virNodeDevicePtr);
        }
        public string virNodeDeviceGetXMLDesc()
        {
            return API.virNodeDeviceGetXMLDesc(_virNodeDevicePtr);
        }
        public int virNodeDeviceListCaps(out string[] names,int maxnames)
        {
            return API.virNodeDeviceListCaps(_virNodeDevicePtr, out names , maxnames);
        }
        public int virNodeDeviceNumOfCaps()
        {
            return API.virNodeDeviceNumOfCaps(_virNodeDevicePtr);
        }
        public int virNodeDeviceReset()
        {
            return API.virNodeDeviceReset(_virNodeDevicePtr);
        }

        public void Dispose()
        {
            _virNodeDevicePtr.Dispose();
        }

    }
}
