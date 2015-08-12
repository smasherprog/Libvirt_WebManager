using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Models
{
    public class Domain_CPU_Down_VM : ViewModels.BaseViewModel
    {
        [Required]
        [Display(Name = "Cpu Count")]
        public int vCpu_Count { get; set; }
        [Required]
        [Display(Name = "Cpu Model")]
        public Libvirt.Models.Concrete.CPU_Layout.CPU_Models Cpu_Model { get; set; }

    }
}