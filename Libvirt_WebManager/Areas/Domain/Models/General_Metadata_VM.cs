using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Models
{
    public class General_Metadata_VM : BaseMachineDetails
    {
        [Required]
        [MinLength(3)]
        [MaxLength(35)]
        [Display(Name = "Name")]
        public string name { get; set; }

        public string uuid { get; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        [Display(Name = "Title")]
        public string title { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
    }
 
}