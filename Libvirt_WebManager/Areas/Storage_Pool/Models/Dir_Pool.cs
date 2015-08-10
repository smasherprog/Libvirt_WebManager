using System.ComponentModel.DataAnnotations;

namespace Libvirt_WebManager.Areas.Storage_Pool.Models
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
        public Storage_Pool Storage_Pool { get; set; }
    }
}