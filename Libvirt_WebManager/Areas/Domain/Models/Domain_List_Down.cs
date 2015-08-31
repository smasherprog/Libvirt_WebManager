namespace Libvirt_WebManager.Areas.Domain.Models
{
    public class Domain_List_Down: ViewModels.BaseViewModel
    {
        public Libvirt_Pinvoke.CS_Objects.Container.LibvirtContainer<Libvirt.CS_Objects.Domain> Domains { get; set; }
    }
}