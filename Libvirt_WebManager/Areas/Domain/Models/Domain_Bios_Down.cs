using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Models
{
    public class Domain_Bios_Down 
    {
        public Domain_Bios_Down_VM BiosInfo { get; set; }
        public Libvirt.Models.Concrete.BIOS_Bootloader Bios { get; set; }
    }
 
}