using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Models
{
    public class Domain_Network_Down_VM : ViewModels.BaseViewModel
    {
        [Required]
        [Display(Name = "Network Model")]
        public Libvirt.Models.Concrete.Iface.Model_Types Model_Type { get; set; }
        [Required]
        [Display(Name = "Network")]
        public string network { get; set; }

    }
}