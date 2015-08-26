using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Models
{
    public class Domain_Drive_Down_VM : ViewModels.BaseViewModel
    {
        [Required]
        [Display(Name = "Type")]
        public Libvirt.Models.Concrete.Disk.Disk_Types Device_Type { get; set; }
        [Required]
        [Display(Name = "Device Type")]
        public Libvirt.Models.Concrete.Disk.Disk_Device_Types Device_Device_Type { get; set; }
        [Required]
        [Display(Name = "Snapshot Type")]
        public Libvirt.Models.Concrete.Disk.Snapshot_Types Snapshot_Type { get; set; }
        [Required]
        [Display(Name = "Driver Type")]
        public Libvirt.Models.Concrete.Disk.Driver_Types Driver_Type { get; set; }
        [Required]
        [Display(Name = "Driver Cache")]
        public Libvirt.Models.Concrete.Disk.Driver_Cache_Types Driver_Cache_Type { get; set; }
        [Required]
        [Display(Name = "Driver Bus Type")]
        public Libvirt.Models.Concrete.Disk.Disk_Bus_Types Device_Bus_Type { get; set; }
        [Required]
        [Display(Name = "Readonly")]
        public bool ReadOnly { get; set; }
        [Required]
        [Display(Name = "Drive Letter")]
        public char Letter { get; set; }


    }
}