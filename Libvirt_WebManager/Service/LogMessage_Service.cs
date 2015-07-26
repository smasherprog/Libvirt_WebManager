using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;

namespace Libvirt_WebManager.Service
{
    public class LogMessage_Service
    {
        private readonly Microsoft.AspNet.SignalR.IHubContext _hubContext;
        private readonly static Lazy<LogMessage_Service> _instance = new Lazy<LogMessage_Service>(() => new LogMessage_Service(GlobalHost.ConnectionManager.GetHubContext<Libvirt_WebManager.Signalr.Libvirt_ManagerHub>()));
        private static LogMessage_Service Instance { get { return _instance.Value; } }
        private LogMessage_Service(Microsoft.AspNet.SignalR.IHubContext hub)
        {
            _hubContext = hub;
            Message_Manager.AddFilter(SendLogEvent);
        }
        public static void Init()
        {
            var t = Instance;
        }
        private void SendLogEvent(Libvirt_WebManager.Models.IMessage message)
        {
            var mes = message as Libvirt_WebManager.Models.Message.LogMessage;
            if (mes != null)
            {
                Task.Factory.StartNew(() => { 
                    _hubContext.Clients.All.LogEventReceived(new Libvirt_WebManager.ViewModels.Message.LogMessage() { Body = mes.Body, Title = mes.Title, Message_Type = mes.Message_Type.ToString() }); 
                });
            }
        }

    }
}