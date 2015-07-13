using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libvirt_WebManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult index_frame()
        {
            return View();
        }
        [HttpPost]
        public ActionResult _Partial_Connect_ToHost(Libvirt_WebManager.ViewModels.Host.virConnectOpen obj)
        {
            if (ModelState.IsValid)
            {
                //using (var con = Libvirt.CS_Objects.Host.virConnectOpen(host_or_ip))
                //{
                //    if (con.IsValid)
                //        Debug.WriteLine("connected");
                //    else Debug.WriteLine("NOT connected");
                //}   
            }
            return PartialView("_Partial_Connect_ToHost_Form", obj);
        }
        [HttpPost]
        public virtual ActionResult GetHosts(string dir)
        {

            const string baseDir = @"~/Content";

            dir = Server.UrlDecode(dir);
            string realDir = Server.MapPath(baseDir + dir);

            //validate to not go above basedir
            if (!realDir.StartsWith(Server.MapPath(baseDir)))
            {
                realDir = Server.MapPath(baseDir);
                dir = "/";
            }

            List<TreeViewModel> files = new List<TreeViewModel>();

            var di = new DirectoryInfo(realDir);

            foreach (DirectoryInfo dc in di.GetDirectories())
            {
                files.Add(new TreeViewModel() { Name = dc.Name, Path = String.Format("{0}{1}\\", dir, dc.Name), IsDirectory = true });
            }

            foreach (FileInfo fi in di.GetFiles())
            {
                files.Add(new TreeViewModel() { Name = fi.Name, Ext = fi.Extension.Substring(1).ToLower(), Path = dir + fi.Name, IsDirectory = false });
            }

            return PartialView(files);
        }


    }
}
