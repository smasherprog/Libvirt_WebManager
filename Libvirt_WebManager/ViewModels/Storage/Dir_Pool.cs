using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.ViewModels.Storage
{
    public class Dir_Pool
    {
        [Display(Name = "Path")]
        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string path { get; set; }
        public Storage_Pool _Storage_Pool { get; set; }
    }
}