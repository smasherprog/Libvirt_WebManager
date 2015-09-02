using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Models
{
    public class Domain_Graphics_Down 
    {
        public Domain_Graphics_Down_VM Domain_Graphics { get; set; }
        public Libvirt.Models.Concrete.Graphics Graphics { get; set; }
    }
 
}