using System.Web.Mvc;

namespace Libvirt_WebManager.Areas.Storage_Pool
{
    public class Storage_PoolAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Storage_Pool";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Storage_Pool_default",
                "Storage_Pool/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}