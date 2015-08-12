using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Models
{
    public class Domain_Details_Down 
    {
        public General_Metadata_VM MetaData { get; set; }
        public Libvirt.Models.Concrete.BIOS_Bootloader Bios { get; set; }
        public Libvirt.Models.Concrete.Virtual_Machine.Domain_Types type { get; set; }
    }
 
}