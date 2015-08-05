using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.ViewModels
{
    public class BaseViewModel 
    {
        [Required]
        [MaxLength(50)]
        public string Host { get; set; }
        [Required]
        [MaxLength(50)]
        public string Parent { get; set; }
    }
}