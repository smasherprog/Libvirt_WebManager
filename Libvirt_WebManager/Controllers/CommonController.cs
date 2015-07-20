using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libvirt_WebManager.Controllers
{
    public class CommonController : Controller
    {
        protected ActionResult CloseDialog(){
            return Content("<div id='scriptcloserhelperthingy_123'></div><script>$('#scriptcloserhelperthingy_123').closest('.modal').modal('hide');</script>");
        }
    }
}