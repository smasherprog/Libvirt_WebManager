using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Models
{
    public class Domain_Network_Down 
    {
        public Domain_Network_Down_VM Network { get; set; }
        public List<Libvirt.Models.Concrete.Network> Networks{ get; set; }
    }
 
}