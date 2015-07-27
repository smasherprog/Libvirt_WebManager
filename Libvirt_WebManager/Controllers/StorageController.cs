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
            return PartialView(new ViewModels.Storage.Storage_Pool { Host = host });
        }
        [HttpPost]
        public ActionResult _Partial_CreatePool(ViewModels.Storage.Storage_Pool pool)
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
                        return PartialView("_Partial_CreateDirPool", new ViewModels.Storage.Dir_Pool { _Storage_Pool = pool });
                    }
                }
            }
            return PartialView(pool);
        }
        [HttpPost]
        public ActionResult _Partial_CreateDirPool(ViewModels.Storage.Dir_Pool pool)
        {
            if (ModelState.IsValid)
            {
                var h = GetHost(pool._Storage_Pool.Host);
                if (ModelState.IsValid)
                {
                    var p = new Libvirt.Models.Concrete.Storage_Pool();
                    p.name = pool._Storage_Pool.name;
                    var d = new Libvirt.Models.Concrete.Storage_Pool_Dir();
                    p.Storage_Pool_Item = d;
                    d.target_path = pool.path;
                    using (var storagepool = h.virStoragePoolDefineXML(p))
                    {
                        var suc = storagepool.virStoragePoolBuild(Libvirt.virStoragePoolBuildFlags.VIR_STORAGE_POOL_BUILD_NEW);
                        if (storagepool.virStoragePoolCreate() == 0)
                        {//succesfully created the pool
                            if (pool.AutoStart) storagepool.virStoragePoolSetAutostart(1);
                        }
                    }
                }
            }
            return PartialView(pool);
        }
        public ActionResult _Partial_GetPoolInfo_TreeView(string host)
        {
            ViewBag.HostName = host;
            return PartialView(GetHost(host));
        }
        public ActionResult _Partial_GetVolumes_TreeView(string host, string pool)
        {
            ViewBag.HostName = host;
            ViewBag.PoolName = pool;
            return PartialView(GetHost(host));
        }

        [HttpGet]
        public ActionResult _Partial_CreateVolume(string host, string pool)
        {
            var h = GetHost(host);
            using (var p = h.virStoragePoolLookupByName(pool))
            {
                if (p.IsValid)
                {
                    var svd = new ViewModels.Storage.Storage_Volume_Down();
                    Libvirt._virStoragePoolInfo info;
                    p.virStoragePoolGetInfo(out info);
                    svd.PoolInfo = info;
                    svd.Volume = new ViewModels.Storage.Storage_Volume { Host = host, Parent = pool };
                    return PartialView(svd);
                }
                else
                {
                    return CloseDialog();
                }
            }
        }
        [HttpPost]
        public ActionResult _Partial_CreateVolume(ViewModels.Storage.Storage_Volume volume, System.Web.HttpPostedFileBase File)
        {
            var h = GetHost(volume.Host);
            using (var p = h.virStoragePoolLookupByName(volume.Parent))
            {
                if (ModelState.IsValid)
                {
                    var t = new Libvirt.Service.Concrete.Storage_Volume_Validator();
                    var v = Utilities.AutoMapper.Mapper<Libvirt.Models.Concrete.Storage_Volume>.Map(volume);

                    if (ModelState.IsValid)
                    {
                        t.Validate(new Libvirt_WebManager.Models.Validator(ModelState), v, p);
                        if (ModelState.IsValid)
                        {
                            return PartialView("_Partial_CreateDirPool", new ViewModels.Storage.Storage_Volume());
                        }
                    }
                }
                if (p.IsValid)
                {
                    var svd = new ViewModels.Storage.Storage_Volume_Down();
                    Libvirt._virStoragePoolInfo info;
                    p.virStoragePoolGetInfo(out info);
                    svd.PoolInfo = info;
                    svd.Volume = volume;
                    return PartialView(svd);
                }
                else
                {
                    return CloseDialog();
                }
            }
        }
    }
}
