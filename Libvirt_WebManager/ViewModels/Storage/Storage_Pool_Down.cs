namespace Libvirt_WebManager.ViewModels.Storage
{
    public class Storage_Pool_Down: Storage_PoolBase
    {
        public Libvirt.CS_Objects.Storage_Volume[] Volumes { get; set; }
    }
}