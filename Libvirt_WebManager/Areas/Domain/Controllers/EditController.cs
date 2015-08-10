using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Domain.Controllers
{
    public class EditController : Libvirt_WebManager.Controllers.CommonController
    {
        private Service.Domain_Service _Domain_Service;
        public EditController()
        {
            _Domain_Service = new Service.Domain_Service(new Libvirt_WebManager.Models.Validator(ModelState));
        }

        [HttpGet]
        public ActionResult _Partial_Index(string host, string domain)
        {

            return PartialView();
        }

    }
}