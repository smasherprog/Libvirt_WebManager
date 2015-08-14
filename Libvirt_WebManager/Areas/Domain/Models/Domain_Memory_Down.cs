using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Models
{
    public class Domain_Memory_Down 
    {
        public Domain_Memory_Down_VM MemoryInfo { get; set; }
        public Libvirt._virNodeInfo NodeCpuInfo { get; set; }
    }
 
}