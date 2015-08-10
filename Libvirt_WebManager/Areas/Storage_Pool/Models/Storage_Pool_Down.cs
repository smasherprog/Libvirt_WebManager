namespace Libvirt_WebManager.Areas.Storage_Pool.Models
{
    public class Storage_Pool_Down: Storage_PoolBase
    {
        public Libvirt.CS_Objects.Storage_Volume[] Volumes { get; set; }
    }
}