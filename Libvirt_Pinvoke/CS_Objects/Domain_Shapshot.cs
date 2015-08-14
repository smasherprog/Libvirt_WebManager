using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.CS_Objects
{
    public class Domain_Shapshot : IDisposable
    {

        private virDomainSnapshotPtr _virDomainSnapshotPtr;
        public bool IsValid { get { return _virDomainSnapshotPtr.Pointer != IntPtr.Zero; } }
        public Domain_Shapshot(virDomainSnapshotPtr ptr)
        {
            _virDomainSnapshotPtr = ptr;
        }

        public int virDomainRevertToSnapshot(virDomainSnapshotRevertFlags flags)
        {
            return API.virDomainRevertToSnapshot(_virDomainSnapshotPtr, flags);
        }

        public int virDomainSnapshotDelete(virDomainSnapshotDeleteFlags flags)
        {
            return API.virDomainSnapshotDelete(_virDomainSnapshotPtr, flags);
        }
        public string virDomainSnapshotGetName()
        {
            return API.virDomainSnapshotGetName(_virDomainSnapshotPtr);
        }

        public Domain_Shapshot virDomainSnapshotGetParent()
        {
            return new Domain_Shapshot(API.virDomainSnapshotGetParent(_virDomainSnapshotPtr));
        }
        public string virDomainSnapshotGetXMLDesc(virDomainXMLFlags flags)
        {
            return API.virDomainSnapshotGetXMLDesc(_virDomainSnapshotPtr, flags);
        }
        public int virDomainSnapshotHasMetadata()
        {
            return API.virDomainSnapshotHasMetadata(_virDomainSnapshotPtr);
        }
        public int virDomainSnapshotIsCurrent()
        {
            return API.virDomainSnapshotIsCurrent(_virDomainSnapshotPtr);
        }
        public int virDomainSnapshotListAllChildren(out Domain_Shapshot[] snaps, virDomainSnapshotListFlags flags)
        {
            virDomainSnapshotPtr[] items = new virDomainSnapshotPtr[0];
            var ret = API.virDomainSnapshotListAllChildren(_virDomainSnapshotPtr, out items, flags);
            snaps = new Domain_Shapshot[items.Length];
            for (var i = 0; i < items.Length; i++)
                snaps[i] = new Domain_Shapshot(items[i]);
            return ret;
        }


        public int virDomainSnapshotListChildrenNames(out string[] names, int nameslen, virDomainSnapshotListFlags flags)
        {
            return API.virDomainSnapshotListChildrenNames(_virDomainSnapshotPtr, out names, nameslen,  flags);
        }
        public int virDomainSnapshotNumChildren(virDomainSnapshotListFlags flags)
        {
            return API.virDomainSnapshotNumChildren(_virDomainSnapshotPtr, flags);
        }


        public void Dispose()
        {
            _virDomainSnapshotPtr.Dispose();
        }

    }
}
