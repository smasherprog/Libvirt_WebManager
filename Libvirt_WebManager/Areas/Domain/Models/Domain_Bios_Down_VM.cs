using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Models
{
    public class BootOrder_VM
    {
        public bool Enabled { get; set; }
        public Libvirt.Models.Concrete.BIOS_Bootloader.Boot_Types BootType { get; set; }
    }
    public class Domain_Bios_Down_VM : ViewModels.BaseViewModel
    {

        [Required]
        [Display(Name = "Start Automatically")]
        public bool StartGuestAutomatically { get; set; }
        [Required]
        [Display(Name = "Boot Menu")]
        public bool ShowBootMenu { get; set; }
        [Required]
        [Display(Name = "Boot Order")]
        public List<BootOrder_VM> BootOrder { get; set; }

    }
}