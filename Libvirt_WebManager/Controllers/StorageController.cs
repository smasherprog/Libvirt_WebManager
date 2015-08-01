using System.Web.Mvc;


namespace Libvirt_WebManager.Controllers
{
    public class StorageController : CommonController
    {
        private Service.Storage_Service _Storage_Service;
        public StorageController()
        {
            _Storage_Service = new Service.Storage_Service(new Libvirt_WebManager.Models.Validator(ModelState));
        }
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
                _Storage_Service.CreatePool_Dir(pool);
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
            return PartialView(GetStorage_Volume_Down(new ViewModels.Storage.Storage_Volume { Host = host, Parent = pool }));
        }
        [HttpPost]
        public ActionResult _Partial_CreateVolume(ViewModels.Storage.Storage_Volume volume, System.Web.HttpPostedFileBase File)
        {
            if (ModelState.IsValid) _Storage_Service.CreateVolume(volume, File);
            return PartialView(GetStorage_Volume_Down(volume));
        }

        public ActionResult _Partial_PoolInfo_MainContent(string host, string pool)
        {
            var p = GetHost(host).virStoragePoolLookupByName(pool);

            var vm = new ViewModels.Storage.Storage_Pool_Down();
            vm.Pool = p;
            Libvirt.CS_Objects.Storage_Volume[] vols;
            AddToAutomaticDisposal(p).virStoragePoolListAllVolumes(out vols);
            vm.Volumes = vols;
            AddToAutomaticDisposal(vols);
            return PartialView(vm);
        }



        private ViewModels.Storage.Storage_Volume_Down GetStorage_Volume_Down(ViewModels.Storage.Storage_Volume volume)
        {
            var h = GetHost(volume.Host);
            using (var p = h.virStoragePoolLookupByName(volume.Parent))
            {
                var svd = new ViewModels.Storage.Storage_Volume_Down();
                svd.Volume = volume;
                if (p.IsValid)
                {
                    Libvirt._virStoragePoolInfo info;
                    p.virStoragePoolGetInfo(out info);
                    svd.PoolInfo = info;
                }
                return svd;
            }
        }
    }
}
