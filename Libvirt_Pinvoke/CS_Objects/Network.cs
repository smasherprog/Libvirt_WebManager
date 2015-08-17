using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.CS_Objects
{
    public class Network : IDisposable
    {
        private virNetworkPtr _virNetworkPtr;
        public bool IsValid { get { return _virNetworkPtr.Pointer != IntPtr.Zero; } }
        public Network(virNetworkPtr ptr)
        {
            _virNetworkPtr = ptr;
        }
        public int virNetworkCreate()
        {
            return API.virNetworkCreate(_virNetworkPtr);
        }

        public int virNetworkDestroy()
        {
            return API.virNetworkDestroy(_virNetworkPtr);
        }
        public int virNetworkGetAutostart(ref int autostart)
        {
            return API.virNetworkGetAutostart(_virNetworkPtr, ref autostart);
        }
        public string virNetworkGetBridgeName()
        {
            return API.virNetworkGetBridgeName(_virNetworkPtr);
        }
        public int virNetworkGetDHCPLeases(string mac, out _virNetworkDHCPLease[] leases)
        {
            return API.virNetworkGetDHCPLeases(_virNetworkPtr, mac, out leases);
        }
        public string virNetworkGetName()
        {
            return API.virNetworkGetName(_virNetworkPtr);
        }
        public int virNetworkGetUUID(out byte[] uuid)
        {
            return API.virNetworkGetUUID(_virNetworkPtr, out uuid);
        }
        public int virNetworkGetUUIDString(out string uuid)
        {
            return API.virNetworkGetUUIDString(_virNetworkPtr, out uuid);
        }
        public Libvirt.Models.Concrete.Network virNetworkGetXMLDesc(virNetworkXMLFlags flags)
        {
            var ret = new Models.Concrete.Network();
            var xmldesc = API.virNetworkGetXMLDesc(_virNetworkPtr, flags);
            ret.From_XML(System.Xml.Linq.XDocument.Parse(xmldesc).Root);
            return ret;
        }
        public int virNetworkIsActive()
        {
            return API.virNetworkIsActive(_virNetworkPtr);
        }
        public int virNetworkIsPersistent()
        {
            return API.virNetworkIsPersistent(_virNetworkPtr);
        }
        public int virNetworkRef()
        {
            return API.virNetworkRef(_virNetworkPtr);
        }
        public int virNetworkSetAutostart(int autostart)
        {
            return API.virNetworkSetAutostart(_virNetworkPtr, autostart);
        }
        public int virNetworkUndefine()
        {
            return API.virNetworkUndefine(_virNetworkPtr);
        }
        public int virNetworkUpdate(virNetworkUpdateCommand command, virNetworkUpdateSection section, int parentIndex, string xml, virNetworkUpdateFlags flags)
        {
            return API.virNetworkUpdate(_virNetworkPtr, command, section, parentIndex, xml, flags);
        }
        public static Libvirt.virNetworkPtr GetPtr(Network p)
        {
            return p._virNetworkPtr;
        }
        public void Dispose()
        {
            _virNetworkPtr.Dispose();
        }

    }
}
