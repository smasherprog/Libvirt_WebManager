using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Libvirt_WebManager.Service
{
    public class ErrorMessage_Service
    {
        private readonly Microsoft.AspNet.SignalR.IHubContext _hubContext;
        private readonly static Lazy<ErrorMessage_Service> _instance = new Lazy<ErrorMessage_Service>(() => new ErrorMessage_Service(GlobalHost.ConnectionManager.GetHubContext<Libvirt_WebManager.Signalr.Libvirt_ManagerHub>()));
        private static ErrorMessage_Service Instance { get { return _instance.Value; } }
        private ErrorMessage_Service(Microsoft.AspNet.SignalR.IHubContext hub)
        {
            _hubContext = hub;
            Message_Manager.AddFilter(SendErrorEvent);
        }
        public static void Init()
        {
            var t = Instance;
        }
        private void SendErrorEvent(Libvirt_WebManager.Models.IMessage message)
        {
            var mes = message as Libvirt_WebManager.Models.Message.ErrorMessage;
            if (mes != null)
            {
                var errmsg = Libvirt_WebManager.Utilities.AutoMapper.Mapper<Libvirt_WebManager.ViewModels.Message.ErrorMessage>.Map(mes);
                errmsg.Message_Type = mes.Message_Type.ToString();
                _hubContext.Clients.All.ErrorEventReceived(errmsg);
            }
        }
    }
}