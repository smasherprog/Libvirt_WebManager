using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.ViewModels.Domain
{
   
    public class BasePoolVolume_Selector : BaseViewModel
    {
        [Required]
        [MaxLength(50)]
        public string PoolSelector { get; set; }
        [Required]
        [MaxLength(50)]
        public string VolumeSelector { get; set; }
        [Required]
        public bool Select_ISO { get; set; }
    }
    public class PoolVolume_Selector: BasePoolVolume_Selector
    {
        public Libvirt.CS_Objects.Storage_Volume[] Volumes { get; set; }
    }
    public class PoolVolume_Selector_Down: BasePoolVolume_Selector
    {
        public Libvirt.CS_Objects.Storage_Pool[] Pools { get; set; }
    }
}