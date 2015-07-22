using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libvirt_WebManager.Controllers
{
    public class StorageController : CommonController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
        [HttpGet]
        public ActionResult _Partial_CreatePool(string host)
        {
            return PartialView(new Libvirt_WebManager.ViewModels.Storage.Storage_Pool { Host = host });
        }
        [HttpPost]
        public ActionResult _Partial_CreatePool(Libvirt_WebManager.ViewModels.Storage.Storage_Pool pool)
        {
            if (ModelState.IsValid)
            {
                var t = new Libvirt.Service.Concrete.Storage_Pool_Validator();
                var v = Utilities.AutoMapper.Mapper<Libvirt.Models.Concrete.Storage_Pool>.Map(pool);
                var h = GetHost(pool.Host);
                if (ModelState.IsValid)
                {
                    t.Validate(new Libvirt_WebManager.Models.Validator(ModelState), v, h);
                    if (ModelState.IsValid)
                    {
                        return PartialView("_Partial_CreateDirPool", new Libvirt_WebManager.ViewModels.Storage.Dir_Pool { _Storage_Pool = pool });
                    }
                }
            }
            return PartialView(pool);
        }
        [HttpPost]
        public ActionResult _Partial_CreateDirPool(Libvirt_WebManager.ViewModels.Storage.Dir_Pool pool)
        {
            if (ModelState.IsValid)
            {

            }
            return PartialView(pool);
        }

    }
}
