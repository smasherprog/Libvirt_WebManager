﻿using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Storage_Pool.Controllers
{
    public class ListingController : Libvirt_WebManager.Controllers.CommonController
    {
        private Service.Storage_Service _Storage_Service;
        public ListingController()
        {
            _Storage_Service = new Service.Storage_Service(new Libvirt_WebManager.Models.Validator(ModelState));
        }


        public ActionResult _Partial_DetailsMainContent(string host, string pool)
        {
            var vm = new Libvirt_WebManager.Areas.Storage_Pool.Models.Storage_Pool_Down();
            vm.Pool = GetHost(host).virStoragePoolLookupByName(pool);
            Libvirt.CS_Objects.Storage_Volume[] vols;
            AddToAutomaticDisposal(vm.Pool).virStoragePoolListAllVolumes(out vols);
            AddToAutomaticDisposal(vols);
            vm.Volumes = vols;
            vm.Host = host;
            vm.Parent = pool;
            return PartialView(vm);
        }

        public ActionResult _Partial_MainContent(string host)
        {
            var vm = new Libvirt_WebManager.Areas.Storage_Pool.Models.Storage_Pools();
            var h = GetHost(host);
            var p = h.virConnectListAllStoragePools(Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_DEFAULT);
            AddToAutomaticDisposal(p);
            foreach(var item in p)
            {
                var t = item.virStoragePoolGetXMLDesc(Libvirt.virStorageXMLFlags.VIR_DEFAULT);

            }
            vm.Pools = p;
            vm.Host = host;
            return PartialView(vm);
        }


        public ActionResult _Partial_Delete_Volume(string Host, string Pool, string Volume)
        {
            using (var p = GetHost(Host).virStoragePoolLookupByName(Pool))
            {
                var v = p.virStorageVolLookupByName(Volume);
                AddToAutomaticDisposal(v);
                if (v.virStorageVolDelete() == -1) return PartialView("_Partial_Volume_Details_Listing", new Libvirt_WebManager.Areas.Storage_Pool.Models.Storage_Volume_Details { Host = Host, Parent = Pool, Volume = v });
                else return Content("");//return an empty string so it will delete the node
            }
        }


        public ActionResult _Partial_Refresh_Pool(string Host, string Pool)
        {

            var p = GetHost(Host).virStoragePoolLookupByName(Pool);
            AddToAutomaticDisposal(p);
            p.virStoragePoolRefresh();
            return PartialView("_Partial_Pool_TableRowDetails", new Models.Storage_PoolBase { Host = Host, Parent = Host, Pool = p });
        }
        public ActionResult _Partial_Delete_Pool(string Host, string Pool)
        {
            using (var p = GetHost(Host).virStoragePoolLookupByName(Pool))
            {
                p.virStoragePoolDelete(Libvirt.virStoragePoolDeleteFlags.VIR_STORAGE_POOL_DELETE_NORMAL);
                p.virStoragePoolUndefine();
            }
            return Content("");
        }
        public ActionResult _Partial_Start_Pool(string Host, string Pool)
        {
            var p = GetHost(Host).virStoragePoolLookupByName(Pool);
            AddToAutomaticDisposal(p);
            p.virStoragePoolCreate();
            return PartialView("_Partial_Pool_TableRowDetails", new Models.Storage_PoolBase { Host = Host, Parent = Host, Pool = p });
        }
        public ActionResult _Partial_Stop_Pool(string Host, string Pool)
        {
            var p = GetHost(Host).virStoragePoolLookupByName(Pool);
            AddToAutomaticDisposal(p);
            p.virStoragePoolDestroy();
            return PartialView("_Partial_Pool_TableRowDetails", new Models.Storage_PoolBase { Host = Host, Parent = Host, Pool = p });
        }
        public void VolumeDownload(string Host, string Pool, string volume)
        {
            var h = GetHost(Host);
            using (var p = h.virStoragePoolLookupByName(Pool))
            using (var v = p.virStorageVolLookupByName(volume))
            using (var st = h.virStreamNew(Libvirt.virStreamFlags.VIR_STREAM_NONBLOCK))
            {
                var info =v.virStorageVolGetInfo();
                var stupload = v.virStorageVolDownload(st, 0, (ulong)info.allocation);
                System.Diagnostics.Debug.WriteLine("virStorageDownload");
                ulong chunksize = 65000;
                var dat = new byte[chunksize];
                Response.CacheControl = "No-cache";
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + volume);
                var dataToRead = (ulong)info.allocation;

                while (Response.IsClientConnected && dataToRead > 0)
                {
                    var got = st.virStreamRecv(dat, chunksize);
                    if (got > 0)
                    {
                        Response.OutputStream.Write(dat, 0, got);
                        Response.Flush();
                    }
                    else if (got == 0)
                    {
                        dataToRead = 0;
                    }
                    dataToRead -= (ulong)got;

                }
                st.virStreamFinish();
            }
        }
        [HttpGet]
        public ActionResult _Partial_ResizeVolume(string Host, string Parent, string volume)
        {
            var vm = new Models.Storage_Volume_Resize();
            var h = GetHost(Host);
            vm.Host = Host;
            vm.Parent = Parent;
            vm.name = volume;
            using (var p = h.virStoragePoolLookupByName(Parent))
            {
                Libvirt._virStoragePoolInfo poolinfo;
                p.virStoragePoolGetInfo(out poolinfo);
                vm.PoolInfo = poolinfo;
                using (var v = p.virStorageVolLookupByName(volume))
                {
                    var volinfo = v.virStorageVolGetInfo();
                    vm.capacity = volinfo.capacity;
                    vm.VolInfo = volinfo;
                }
            }
            return PartialView(vm);
        }
        [HttpPost]
        public ActionResult _Partial_ResizeVolume(Models.Storage_Volume_Resize volres)
        {
   
            using (var p = GetHost(volres.Host).virStoragePoolLookupByName(volres.Parent))
            {
                Libvirt._virStoragePoolInfo poolinfo;
                p.virStoragePoolGetInfo(out poolinfo);
                volres.PoolInfo = poolinfo;
                using (var v = p.virStorageVolLookupByName(volres.name))
                {
                    var volinfo = v.virStorageVolGetInfo();
                    if (volinfo.capacity > volres.capacity)
                    {
                        v.virStorageVolResize(volres.capacity, Libvirt.virStorageVolResizeFlags.VIR_STORAGE_VOL_RESIZE_SHRINK);
                    }
                    else
                    {
                        v.virStorageVolResize(volres.capacity, Libvirt.virStorageVolResizeFlags.VIR_DEFAULT);
                    }
                    volres.VolInfo = v.virStorageVolGetInfo();
                }
            }
            return PartialView(volres);
        }
    }
}
