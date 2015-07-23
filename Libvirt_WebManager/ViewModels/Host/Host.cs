using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.ViewModels.Host
{
    public class Host_VM
    {
        public string Hostname { get; set; }
        public string Hypervisor { get; set; }
        public string Cpu_Model { get; set; }
        public string Memory { get; set; }
        public string Cpu_Count { get; set; }
        public string Mhz { get; set; }
        public string Cores { get; set; }
        public string Threads { get; set; }
    }
}