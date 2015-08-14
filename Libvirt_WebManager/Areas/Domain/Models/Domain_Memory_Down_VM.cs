using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Models
{
    public class Domain_Memory_Down_VM : ViewModels.BaseViewModel
    {
        [Required]
        [Display(Name = "Initial Ram")]
        public System.Int64 currentMemory { get; set; }
        [Required]
        [Display(Name = "Total Ram")]
        public System.Int64 memory { get; set; }

    }
}