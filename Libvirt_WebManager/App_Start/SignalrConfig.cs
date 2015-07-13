using Microsoft.Owin;
using Owin;

namespace Libvirt_WebManager.Signalr
{
    public class Startup
    {
        public void Configuration(Owin.IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
