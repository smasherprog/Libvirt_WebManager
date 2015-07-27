using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.CS_Objects
{
    public class Storage_Pool : IDisposable
    {
        private Libvirt.virStoragePoolPtr _Storage_PoolPtr;
        public bool IsValid { get { return _Storage_PoolPtr.Pointer != IntPtr.Zero; } }
        public Storage_Pool(Libvirt.virStoragePoolPtr ptr)
        {
            _Storage_PoolPtr = ptr;
        }


        public int virStoragePoolBuild(virStoragePoolBuildFlags flags)
        {
            return API.virStoragePoolBuild(_Storage_PoolPtr, flags);
        }
        public int virStoragePoolCreate()
        {
            return API.virStoragePoolCreate(_Storage_PoolPtr);
        }
    
        public int virStoragePoolDelete(virStoragePoolDeleteFlags flags)
        {
            return API.virStoragePoolDelete(_Storage_PoolPtr, flags);
        }
        public int virStoragePoolDestroy()
        {
            return API.virStoragePoolDestroy(_Storage_PoolPtr);
        }
        public int virStoragePoolGetAutostart(out int autostart)
        {
            return API.virStoragePoolGetAutostart(_Storage_PoolPtr, out autostart);
        }
        public int virStoragePoolGetInfo(out _virStoragePoolInfo info)
        {
            return API.virStoragePoolGetInfo(_Storage_PoolPtr, out info);
        }
        public string virStoragePoolGetName()
        {
            return API.virStoragePoolGetName(_Storage_PoolPtr);
        }
        public int virStoragePoolGetUUID(out byte[] uuid)
        {
            return API.virStoragePoolGetUUID(_Storage_PoolPtr, out uuid);
        }
        public int virStoragePoolGetUUIDString(out string buf)
        {
            return API.virStoragePoolGetUUIDString(_Storage_PoolPtr, out buf);
        }

        public string virStoragePoolGetXMLDesc(virStorageXMLFlags flags)
        {
            return API.virStoragePoolGetXMLDesc(_Storage_PoolPtr, flags);
        }
        public int virStoragePoolIsActive()
        {
            return API.virStoragePoolIsActive(_Storage_PoolPtr);
        }
        public int virStoragePoolIsPersistent()
        {
            return API.virStoragePoolIsPersistent(_Storage_PoolPtr);
        }
        public int virStoragePoolListAllVolumes(out Storage_Volume[] vols)
        {
            virStorageVolPtr[] ptrs;
            var ret = API.virStoragePoolListAllVolumes(_Storage_PoolPtr, out ptrs);
            vols = new Storage_Volume[ptrs.Length];
            for (var i = 0; i < ptrs.Length; i++)
            {
                vols[i] = new Storage_Volume(ptrs[i]);
            }
            return ret;
        }
        public int virStoragePoolListVolumes(out string[] names, int maxnames)
        {
            return API.virStoragePoolListVolumes(_Storage_PoolPtr, out names, maxnames);
        }
        public int virStoragePoolNumOfVolumes()
        {
            return API.virStoragePoolNumOfVolumes(_Storage_PoolPtr);
        }

        public int virStoragePoolRefresh()
        {
            return API.virStoragePoolRefresh(_Storage_PoolPtr);
        }
        public int virStoragePoolSetAutostart(int autostart)
        {
            return API.virStoragePoolSetAutostart(_Storage_PoolPtr, autostart);
        }
        public int virStoragePoolUndefine()
        {
            return API.virStoragePoolUndefine(_Storage_PoolPtr);
        }
        public Storage_Volume virStorageVolCreateXML(Models.Concrete.Storage_Volume xmlDesc, virStorageVolCreateFlags flags)
        {
            return new Storage_Volume(API.virStorageVolCreateXML(_Storage_PoolPtr, xmlDesc.To_XML(), flags));
        }
        public Storage_Volume virStorageVolCreateXMLFrom(Models.Concrete.Storage_Volume xmlDesc,Storage_Volume clonevol, virStorageVolCreateFlags flags)
        {
            return new Storage_Volume(API.virStorageVolCreateXMLFrom(_Storage_PoolPtr, xmlDesc.To_XML(), Storage_Volume.GetPtr(clonevol), flags));
        }
        public Storage_Volume virStorageVolLookupByName(string name)
        {
            return new Storage_Volume(API.virStorageVolLookupByName(_Storage_PoolPtr, name));
        }
        public void Dispose()
        {
            _Storage_PoolPtr.Dispose();
        }
    }
}
