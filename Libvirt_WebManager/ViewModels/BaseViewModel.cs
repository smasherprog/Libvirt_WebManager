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
        public string Host { get; set;}
        public string Parent { get; set; }
    }
}