using System.Collections.Generic;

namespace Libvirt_WebManager.Areas.Domain.Models
{
    public class Domain_Migrate_Down : ViewModels.BaseViewModel
    {
        public Domain_Migrate_Down()
        {
            Hosts = new List<System.Web.Mvc.SelectListItem>();
        }
        public List<System.Web.Mvc.SelectListItem> Hosts { get; set; }
    }
}