using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Models
{
    public class Domain_CPU_Down 
    {
        public Domain_CPU_Down_VM CpuInfo { get; set; }
        public Libvirt._virNodeInfo NodeCpuInfo { get; set; }
    }
 
}