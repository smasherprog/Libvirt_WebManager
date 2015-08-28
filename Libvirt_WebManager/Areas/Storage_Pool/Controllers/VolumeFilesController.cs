using System.Diagnostics;
using System.Web.Http;
using System.Net.Http;
using System.Linq;

namespace Libvirt_WebManager.Storage_Pool.Network.Controllers
{
    public class files
    {
        public string name { get; set; }
        public long size { get; set; }
    }
    public class VolumeFilesController : ApiController
    {
        [HttpPost]
        public async System.Threading.Tasks.Task<IHttpActionResult> UploadFile([FromUri]Areas.Storage_Pool.Models.Storage_Volume_Upload d)
        {
            if (!Request.Content.IsMimeMultipartContent()) return BadRequest();
            var range = Request.Content.Headers.ContentRange;
            var provider = await Request.Content.ReadAsMultipartAsync();
            var file = provider.Contents.FirstOrDefault();
            if (file == null) return BadRequest();
            var dataStream = await file.ReadAsStreamAsync();
            var h = Libvirt_WebManager.Service.VM_Manager.Instance.virConnectOpen(d.Host);
            using (var p = h.virStoragePoolLookupByName(d.Parent))
            using (var v = p.virStorageVolLookupByName(d.Volume))
            {
                if (range.From.Value == 0)
                {//first run.. resize the volume
                    Libvirt._virStorageVolInfo info;
                    v.virStorageVolGetInfo(out info);
                    if ((ulong)range.Length.Value < info.capacity)
                    {//shriknk volume

                        v.virStorageVolResize((ulong)range.Length.Value, Libvirt.virStorageVolResizeFlags.VIR_STORAGE_VOL_RESIZE_SHRINK);

                    }
                    else if ((ulong)range.Length.Value > info.capacity)
                    {
                        v.virStorageVolResize((ulong)range.Length.Value, Libvirt.virStorageVolResizeFlags.VIR_DEFAULT);
                    }
                }
                using (var st = h.virStreamNew(Libvirt.virStreamFlags.VIR_STREAM_NONBLOCK))
                {
                    var stupload = v.virStorageVolUpload(st, (ulong)range.From.Value, (ulong)dataStream.Length);
                    Debug.WriteLine("virStorageVolUpload (" + range.From.Value + " " + (ulong)dataStream.Length);
                    long chunksize = 65000;
                    var dat = new byte[chunksize];
                    var thischunksize = dataStream.Length;
                    while (thischunksize > 0)
                    {
                        var bytestoread = chunksize;
                        if (thischunksize < bytestoread)
                        {
                            bytestoread = thischunksize;
                        }
                        var bread = (uint)dataStream.Read(dat, 0, (int)bytestoread);
                        var bytessent = st.virStreamSend(dat, bread);
                        Debug.WriteLine("bread " + bread + "  bytesent " + bytessent);
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
            Debug.WriteLine("Done Uploading");
            return Ok(new { files = new files[] { new files { name = Request.Content.Headers.ContentDisposition.FileName, size = Request.Content.Headers.ContentLength.Value } } });
        }
    }
}
    //public IHttpActionResult UploadFile([FromUri]Areas.Storage_Pool.Models.Storage_Volume_Upload d)
    //{



    //    var h = Libvirt_WebManager.Service.VM_Manager.Instance.virConnectOpen(d.Host);
    //    using (var p = h.virStoragePoolLookupByName(d.Parent))
    //    using (var v = p.virStorageVolLookupByName(d.Volume))
    //    {
    //        if (range.From.Value == 0)
    //        {//first run.. resize the volume
    //            Libvirt._virStorageVolInfo info;
    //            v.virStorageVolGetInfo(out info);
    //            if ((ulong)range.Length.Value < info.capacity)
    //            {//shriknk volume

    //                v.virStorageVolResize((ulong)range.Length.Value, Libvirt.virStorageVolResizeFlags.VIR_STORAGE_VOL_RESIZE_SHRINK);

    //            }
    //            else if ((ulong)range.Length.Value > info.capacity)
    //            {
    //                v.virStorageVolResize((ulong)range.Length.Value, Libvirt.virStorageVolResizeFlags.VIR_DEFAULT);
    //            }
    //        }
    //        using (var st = h.virStreamNew(Libvirt.virStreamFlags.VIR_STREAM_NONBLOCK))
    //        {
    //            var stupload = v.virStorageVolUpload(st, (ulong)range.From.Value, (ulong)thischunksize);
    //            Debug.WriteLine("virStorageVolUpload (" + range.From.Value + " " + thischunksize);
    //            long chunksize = 65000;
    //            var dat = new byte[chunksize];

    //            using (var stream = Request.Content.ReadAsStreamAsync().Result)
    //            {
    //                stream.Position = Request.Content.Headers.ContentLength.Value - thischunksize;
    //                while (thischunksize > 0)
    //                {
    //                    var bytestoread = chunksize;
    //                    if (thischunksize < bytestoread)
    //                    {
    //                        bytestoread = thischunksize;
    //                    }
    //                    var bread = (uint)stream.Read(dat, 0, (int)bytestoread);
    //                    var bytessent = st.virStreamSend(dat, bread);
    //                    Debug.WriteLine("bread " + bread + "  bytesent " + bytessent);
    //                    if (bytessent < 0)
    //                    {
    //                        st.virStreamAbort();
    //                        break;//get out!!
    //                    }

    //                    thischunksize -= (long)bread;
    //                }
    //                st.virStreamFinish();
    //            }
    //        }
    //    }
    //    Debug.WriteLine("Done Uploading");
    //    return Ok(new { files = new files[] { new files { name = Request.Content.Headers.ContentDisposition.FileName, size = Request.Content.Headers.ContentLength.Value } } });
    //}
