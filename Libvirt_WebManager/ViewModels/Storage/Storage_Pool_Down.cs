namespace Libvirt_WebManager.ViewModels.Storage
{
    public class Storage_Pool_Down
    {
        public Libvirt.CS_Objects.Storage_Pool Pool { get; set; }
        public Libvirt.CS_Objects.Storage_Volume[] Volumes { get; set; }
    }
}