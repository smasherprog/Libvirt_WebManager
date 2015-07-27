using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.ViewModels.Storage
{
    public class Dir_Pool
    {
        public Dir_Pool()
        {
            AutoStart = true;
        }
        [Display(Name = "Path")]
        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string path { get; set; }
        [Display(Name = "Auto start pool")]
        public bool AutoStart { get; set; }
        public Storage_Pool _Storage_Pool { get; set; }
    }
}