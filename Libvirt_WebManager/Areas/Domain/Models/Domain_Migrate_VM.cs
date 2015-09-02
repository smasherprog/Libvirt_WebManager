using System.Collections.Generic;

namespace Libvirt_WebManager.Areas.Domain.Models
{
    public class Domain_Migrate_VM : ViewModels.BaseViewModel
    {
        public Domain_Migrate_VM()
        {
            Persist_On_Dst = true;
            Delete_On_Src = false;
        }
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MinLength(3)]
        [System.ComponentModel.DataAnnotations.Display(Name ="Destination Domain")]
        public string Dst_Domain { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Display(Name = "Persist On Destination")]
        public bool Persist_On_Dst { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Display(Name = "Delete On Source")]
        public bool Delete_On_Src { get; set; }

    }
}