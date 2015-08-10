using Libvirt_WebManager.ViewModels.Validators;
using System.ComponentModel.DataAnnotations;

namespace Libvirt_WebManager.Areas.Host.Models
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