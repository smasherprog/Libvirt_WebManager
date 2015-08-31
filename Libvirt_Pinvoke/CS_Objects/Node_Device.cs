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
        public bool IsValid { get { return !_virNodeDevicePtr.IsInvalid; } }
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
        public Libvirt.Models.Concrete.Node.Device virNodeDeviceGetXMLDesc()
        {
            var root = System.Xml.Linq.XDocument.Parse(API.virNodeDeviceGetXMLDesc(_virNodeDevicePtr)).Root;
            var t = root.Element("capability");
            if (t != null)
            {
                var attr = t.Attribute("type");
                if (attr != null)
                {
                    var nodetype = (Libvirt.Models.Concrete.Node.Device.Node_Types)Enum.Parse(typeof(Libvirt.Models.Concrete.Node.Device.Node_Types), attr.Value);
                    if (nodetype == Models.Concrete.Node.Device.Node_Types.storage)
                    {
                        var ret = new Libvirt.Models.Concrete.Node.Storage();
                        ret.From_XML(root);
                        return ret;
                    }
                }
            }
            throw new NotImplementedException("Other Node types have not been implemented yet. Use API.virNodeDeviceGetXMLDesc  to get raw string");

        }
        public int virNodeDeviceListCaps(out string[] names, int maxnames)
        {
            return API.virNodeDeviceListCaps(_virNodeDevicePtr, out names, maxnames);
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
