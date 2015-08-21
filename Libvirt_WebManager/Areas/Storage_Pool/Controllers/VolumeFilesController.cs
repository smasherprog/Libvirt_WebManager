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
        public IHttpActionResult UpladFile([FromUri]int extradata)
        {
            var length = Request.Content.Headers.ContentLength;
            var dis = Request.Content.Headers.ContentDisposition.FileName;
            if (Request.Headers.Range != null)
            {
                Debug.WriteLine("range" + Request.Headers.Range);
            }

            return Ok(new { files = new files[] { new files { name = dis, size = Request.Content.Headers.ContentLength.Value } } });
        }
    }
}
