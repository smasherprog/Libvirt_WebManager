using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Models
{
    public enum Listen_Address_Types { All_Interfaces, LocalHost };
    public class Domain_Graphics_Down_VM : ViewModels.BaseViewModel
    {
        public Domain_Graphics_Down_VM() {

        }

        [Required]
        [Display(Name = "Remote Type")]
        public Libvirt.Models.Concrete.Graphics.Graphic_Types Graphic_Type { get; set; }
        [Required]
        [Display(Name = "Listen Address")]
        public Listen_Address_Types Listen_Address_Type { get; set; }

        [Display(Name = "Password")]
        public string passwd { get; set; }

        [Display(Name = "Password Expires on")]
        public System.DateTime? passwdValidTo { get; set; }

        [Required]
        [Display(Name = "WebSocket")]
        public bool WebSocket { get; set; }


    }
}