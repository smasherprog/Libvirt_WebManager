using Libvirt_WebManager.ViewModels.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.ViewModels.Host
{
    public class virConnectOpen 
    {
        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        [Display(Name = "Host or IP")]
        [HostName]
        public string host_or_ip { get; set; }

    }
}