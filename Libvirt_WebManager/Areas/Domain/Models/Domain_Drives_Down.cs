using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Models
{
    public class Domain_Drive_Down 
    {
        public Domain_Drive_Down_VM Domain_Drive { get; set; }
        public Libvirt.Models.Concrete.Disk Disk { get; set; }
    }
 
}