namespace Libvirt_WebManager.Areas.Storage_Pool.Models
{
    public class Storage_Pools: ViewModels.BaseViewModel
    {
        public Libvirt_Pinvoke.CS_Objects.Container.LibvirtContainer<Libvirt.CS_Objects.Storage_Pool> Pools { get; set; }


    }
}