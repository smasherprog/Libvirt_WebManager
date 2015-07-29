using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libvirt_WebManager.Controllers
{
    public class CommonController : Controller
    {
        public CommonController()
        {
            ObjectsToDispose = new List<IDisposable>();
        }
        protected ActionResult CloseDialog()
        {
            return Content("<div id='scriptcloserhelperthingy_123'></div><script>$('#scriptcloserhelperthingy_123').closest('.modal').modal('hide');</script>");
        }
        protected Libvirt.CS_Objects.Host GetHost(string hostname)
        {
            Libvirt.CS_Objects.Host t = null;
            if (!Libvirt_WebManager.Service.VM_Manager.Instance.Connections.TryGetValue(hostname.ToLower(), out t))
            {
                ModelState.AddModelError("Host Does not Exist", "The host does not exist!");
            }
            return t;
        }
        protected List<IDisposable> ObjectsToDispose { get; set; }
        protected void AddToAutomaticDisposal(IDisposable o) { ObjectsToDispose.Add(o); }
        protected void AddToAutomaticDisposal(IEnumerable<IDisposable> objs) { ObjectsToDispose.AddRange(objs); }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var item in ObjectsToDispose) item.Dispose();
                ObjectsToDispose.Clear();
            }

            base.Dispose(disposing);
        }
    }
}