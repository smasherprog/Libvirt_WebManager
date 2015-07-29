using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.CS_Objects
{
    public class Storage_Volume : IDisposable
    {
        private Libvirt.virStorageVolPtr _Storage_VolumePtr;
        public bool IsValid { get { return _Storage_VolumePtr.Pointer != IntPtr.Zero; } }
        public Storage_Volume(Libvirt.virStorageVolPtr ptr)
        {
            _Storage_VolumePtr = ptr;
        }
        public Storage_Pool virStoragePoolLookupByVolume()
        {
            return new Storage_Pool(API.virStoragePoolLookupByVolume(_Storage_VolumePtr));
        }
        public int virStorageVolDelete()
        {
            return API.virStorageVolDelete(_Storage_VolumePtr);
        }
        public int	virStorageVolDownload(Stream stream, ulong offset, ulong length)
        {
            return API.virStorageVolDownload(_Storage_VolumePtr, Stream.GetPtr(stream), offset, length);
        }
        public int virStorageVolGetInfo(out _virStorageVolInfo info)
        {
            return API.virStorageVolGetInfo(_Storage_VolumePtr, out info);
        }
        public string virStorageVolGetKey()
        {
            return API.virStorageVolGetKey(_Storage_VolumePtr);
        }
        public string virStorageVolGetName()
        {
            return API.virStorageVolGetName(_Storage_VolumePtr);
        }
        public string virStorageVolGetPath()
        {
            return API.virStorageVolGetPath(_Storage_VolumePtr);
        }
        public string virStorageVolGetXMLDesc()
        {
            return API.virStorageVolGetXMLDesc(_Storage_VolumePtr);
        }

        public int virStorageVolResize(ulong capacity, virStorageVolResizeFlags flags)
        {
            return API.virStorageVolResize(_Storage_VolumePtr, capacity, flags);
        }
        public int virStorageVolUpload(Stream stream, ulong offset, ulong length)
        {
            return API.virStorageVolUpload(_Storage_VolumePtr, Stream.GetPtr(stream), offset, length);
        }
  
        public int virStorageVolWipe()
        {
            return API.virStorageVolWipe(_Storage_VolumePtr);
        }
        public int virStorageVolWipePattern(virStorageVolWipeAlgorithm algorithm)
        {
            return API.virStorageVolWipePattern(_Storage_VolumePtr, algorithm);
        }

        public static Libvirt.virStorageVolPtr GetPtr(Storage_Volume p)
        {
            return p._Storage_VolumePtr;
        }
        public void Dispose()
        {
            _Storage_VolumePtr.Dispose();
        }
    }
}
