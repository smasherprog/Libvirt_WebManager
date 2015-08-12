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
        public void Dispose()
        {
            _virDomainSnapshotPtr.Dispose();
        }

    }
}
