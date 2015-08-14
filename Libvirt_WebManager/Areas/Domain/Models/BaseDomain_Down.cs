using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.Areas.Domain.Models
{
    public class BaseDomain_Down : ViewModels.BaseViewModel
    {
        public Libvirt.Models.Concrete.Virtual_Machine Machine { get; set; }
        public Libvirt._virNodeInfo NodeInfo { get; set; }
    }
}