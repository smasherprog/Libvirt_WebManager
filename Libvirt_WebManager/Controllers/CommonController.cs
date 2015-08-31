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
        static int number = 5;
        protected ActionResult CloseDialog()
        {
            return PartialView("~/Views/Common/CloseDialog.cshtml", number++);
        }
        protected Libvirt.CS_Objects.Host GetHost(string hostname)
        {
            var t = Service.VM_Manager.Instance.virConnectOpen(hostname);
            if(t==null) ModelState.AddModelError("Host Does not Exist", "The host does not exist!");
            return t;
        }
        protected string GenerateURIFromHostname(string hostname)
        {
            return "qemu+tcp://" + hostname + "/system";
        }
        protected List<IDisposable> ObjectsToDispose { get; set; }
        protected IEnumerable<T> AddToAutomaticDisposal<T>(IEnumerable<T> objs) where T : IDisposable { ObjectsToDispose.AddRange((IEnumerable<IDisposable>)objs); return objs; }
        protected T[] AddToAutomaticDisposal<T>(T[] objs) where T : IDisposable { foreach (var item in objs) ObjectsToDispose.Add(item); return objs; }
        protected T AddToAutomaticDisposal<T>(T o) where T : IDisposable { ObjectsToDispose.Add(o); return o; }

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