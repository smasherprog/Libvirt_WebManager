using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Libvirt_WebManager.Areas.Storage_Pool.Models
{
    public class Storage_Volume_Resize : ViewModels.BaseViewModel
    {
        public Storage_Volume_Resize()
        {
         
        }
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string name { get; set; }
        [Display(Name = "New Capacity")]
        [Required]
        public UInt64 capacity { get; set; }

        public Libvirt._virStoragePoolInfo PoolInfo { get; set; }
        public Libvirt._virStorageVolInfo VolInfo { get; set; }
    }
}