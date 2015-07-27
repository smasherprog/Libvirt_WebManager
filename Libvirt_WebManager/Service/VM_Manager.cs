using Libvirt_WebManager.Signalr;
using Libvirt_WebManager.ViewModels;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Libvirt_WebManager.Service
{
    public class VM_Manager : IDisposable
    {
        private static VM_Manager _instance = null;

        public Dictionary<string, Libvirt.CS_Objects.Host> Connections;
        private Libvirt.Utilities.Default_EventLoop _Libvirt_EventLoop;
        private Libvirt.virErrorFunc _ErrorFunc;
        private readonly Microsoft.AspNet.SignalR.IHubContext _hubContext;

        public static VM_Manager Instance { get { return _instance; } }
        public static void Start()
        {
            _instance = new VM_Manager(GlobalHost.ConnectionManager.GetHubContext<Libvirt_ManagerHub>());
            Debug.WriteLine("Starting Libvirt Library");
        }
        public static void Stop()
        {
            _instance.Dispose();
            _instance = null;
            Debug.WriteLine("Stopping Libvirt Library");
        }
        public void Dispose()
        {
            if (_Libvirt_EventLoop != null) _Libvirt_EventLoop.Stop();
            _Libvirt_EventLoop = null;
            foreach (var item in Connections)
            {
                try
                {
                    item.Value.Dispose();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            Connections.Clear();
        }

        private VM_Manager(Microsoft.AspNet.SignalR.IHubContext hub)
        {
            _hubContext = hub;
            Connections = new Dictionary<string, Libvirt.CS_Objects.Host>();
            _Libvirt_EventLoop = new Libvirt.Utilities.Default_EventLoop();
            _ErrorFunc = virErrorFunc;
            System.Web.Hosting.HostingEnvironment.QueueBackgroundWorkItem(ctx => _Libvirt_EventLoop.Start(ctx));

        }
        void virErrorFunc(IntPtr userData, Libvirt.virErrorPtr error)
        {
            var msg = Libvirt.API.MarshalErrorPtr(error);
            var errmsg = new Libvirt_WebManager.Models.Message.ErrorMessage
            {
                Additional_Info_1 = msg.str1,
                Additional_Info_2 = msg.str2,
                Additional_Info_3 = msg.str3,
                Body = msg.message,
                Code = msg.code,
                Message_Type = Models.Message_Types.danger,
                Time = DateTime.Now,
                Title = "Libvirt Error"
            };

            Message_Manager.Send(errmsg);
        }
        public bool virConnectOpen(string hostorip)
        {
            hostorip = hostorip.Replace("/", "");
            if (Connections.ContainsKey(hostorip.ToLower())) return true;
            else
            {
                Debug.WriteLine("Trying to Connect to " + hostorip);
                Libvirt_WebManager.Service.Message_Manager.Send(new Libvirt_WebManager.Models.Message.LogMessage { Title = "Connecting to " + hostorip, Message_Type = Libvirt_WebManager.Models.Message_Types.info, Body = "Connecting....Help text should be explicitly associated with the form control it relates to using the aria-describedby attribute. This will ensure that assistive technologies – such as screen readers – will announce this help text when the user focuses or enters the control." });

                var con = Libvirt.CS_Objects.Host.virConnectOpen("qemu+tcp://" + hostorip + "/system");
                if (con.IsValid)
                {
                    Connections.Add(hostorip, con);
                    con.virConnSetErrorFunc(_ErrorFunc);
                    return true;
                }
                con.Dispose();
                return false;
            }
        }

    }
}