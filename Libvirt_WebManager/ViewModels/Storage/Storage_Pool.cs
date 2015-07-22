using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.ViewModels.Storage
{
    public class Storage_Pool
    {
        [Required]
        public string Host { get; set; }
        [Display(Name = "Pool Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string name { get; set; }
        [Display(Name = "Pool Type")]
        public Libvirt.Models.Concrete.Storage_Pool.Pool_Types pool_type { get; set; }
    }
}