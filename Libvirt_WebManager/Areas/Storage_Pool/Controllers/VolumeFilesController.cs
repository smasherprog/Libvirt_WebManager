using System.Diagnostics;
using System.Web.Http;
using System.Web.Mvc;

namespace Libvirt_WebManager.Storage_Pool.Network.Controllers
{
    public class files
    {
        public string name { get; set; }
        public long size { get; set; }
    }
    public class VolumeFilesController : ApiController
    {
        public IHttpActionResult UpladFile([FromUri]Areas.Storage_Pool.Models.Storage_Volume_Upload d)
        {
            var range = Request.Content.Headers.ContentRange;
            if (range != null)
            {
                var thischunksize = range.To.Value - range.From.Value;
                var h = Libvirt_WebManager.Service.VM_Manager.Instance.virConnectOpen(d.Host);
                using (var p = h.virStoragePoolLookupByName(d.Parent))
                using (var v = p.virStorageVolLookupByName(d.Volume))
                {
                    if (range.From.Value == 0)
                    {//first run.. resize the volume
                        Libvirt._virStorageVolInfo info;
                        v.virStorageVolGetInfo(out info);
                        if ((ulong)range.Length.Value < info.capacity )
                        {//shriknk volume

                            v.virStorageVolResize((ulong)range.Length.Value, Libvirt.virStorageVolResizeFlags.VIR_STORAGE_VOL_RESIZE_SHRINK);

                        }
                        else if ( (ulong)range.Length.Value >info.capacity)
                        {
                            v.virStorageVolResize((ulong)range.Length.Value, Libvirt.virStorageVolResizeFlags.VIR_DEFAULT);
                        }
                    }
                    using (var st = h.virStreamNew(Libvirt.virStreamFlags.VIR_STREAM_NONBLOCK))
                    {
                        var stupload = v.virStorageVolUpload(st, (ulong)range.From.Value, (ulong)thischunksize);
                        Debug.WriteLine("virStorageVolUpload (" + range.From.Value + " " + thischunksize);
                        long chunksize = 65000;
                        var dat = new byte[chunksize];

                        using (var stream = Request.Content.ReadAsStreamAsync().Result)
                        {
                            while (thischunksize > 0)
                            {
                                var bytestoread = chunksize;
                                if (thischunksize < bytestoread)
                                {
                                    bytestoread = thischunksize;
                                }
                                var bread = (uint)stream.Read(dat, 0, (int)bytestoread);
                                var bytessent = st.virStreamSend(dat, bread);
                                if (bytessent < 0)
                                {
                                    st.virStreamAbort();
                                    break;//get out!!
                                }
                                thischunksize -= (long)bread;
                            }
                            st.virStreamFinish();
                        }
                    }
                }
            }
            return Ok(new { files = new files[] { new files { name = Request.Content.Headers.ContentDisposition.FileName, size = Request.Content.Headers.ContentLength.Value } } });
        }
    }
}