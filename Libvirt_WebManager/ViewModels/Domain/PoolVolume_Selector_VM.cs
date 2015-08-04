using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.ViewModels.Domain
{
    public class PoolVolume_Selector: BaseViewModel
    {
        public string PoolSelector { get; set; }
        public string VolumeSelector { get; set; }
        public bool Select_ISO { get; set; }
        public Libvirt.CS_Objects.Storage_Volume[] Volumes { get; set; }
    }
    public class PoolVolume_Selector_Down: BaseViewModel
    {
        public Libvirt.CS_Objects.Storage_Pool[] Pools { get; set; }
    }
}