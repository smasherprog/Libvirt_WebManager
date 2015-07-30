using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.ViewModels.Domain
{
    public class PoolVolume_Selector_VM
    {
        public string PoolSelector { get; set; }
        public string VolumeSelector { get; set; }
        public bool Select_ISO { get; set; }
        public string Host { get; set; }

    }
    public class PoolVolume_Selector_VM_Down
    {
        public Libvirt.CS_Objects.Storage_Pool[] Pools { get; set; }
        public PoolVolume_Selector_VM Selector { get; set; }

    }
}