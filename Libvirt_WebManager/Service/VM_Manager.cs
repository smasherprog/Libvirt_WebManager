using Libvirt_WebManager.Signalr;
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

        private List<Libvirt.CS_Objects.Host> _Connections = new List<Libvirt.CS_Objects.Host>();
        private Libvirt.Utilities.Default_EventLoop _Libvirt_EventLoop;
        private Libvirt.virErrorFunc _ErrorFunc;
        private readonly Microsoft.AspNet.SignalR.IHubContext _hubContext;

        public static VM_Manager Instance { get { return _instance; } }
        public static void Start()
        {
            _instance = new VM_Manager(GlobalHost.ConnectionManager.GetHubContext<Libvirt_ManagerHub>());
        }
        public static void Stop()
        {
            _instance.Dispose();
        }
        public void Dispose()
        {
            if (_Libvirt_EventLoop != null) _Libvirt_EventLoop.Stop();
            _Libvirt_EventLoop = null;
            foreach (var item in _Connections)
            {
                try
                {
                    item.Dispose();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            _Connections.Clear();
        }

        private VM_Manager(Microsoft.AspNet.SignalR.IHubContext hub)
        {
            _hubContext = hub;
            _Connections = new List<Libvirt.CS_Objects.Host>();
            _Libvirt_EventLoop = new Libvirt.Utilities.Default_EventLoop();
            _ErrorFunc = virErrorFunc;
            System.Web.Hosting.HostingEnvironment.QueueBackgroundWorkItem(ctx => _Libvirt_EventLoop.Start(ctx));

        }
        void virErrorFunc(IntPtr userData, Libvirt.virErrorPtr error)
        {
            _hubContext.Clients.All.ErrorEvent(Libvirt.API.MarshalErrorPtr(error));
        }
        public bool virConnectOpen(string hostorip)
        {

            if (_Connections.Any(a => a.virConnectGetHostname().ToLower() == hostorip.ToLower())) return true;
            else
            {
                Debug.WriteLine("Trying to Connect to " + hostorip);
                Libvirt_WebManager.Service.Message_Manager.Send(new Libvirt_WebManager.Models.Message.LogMessage { Title = "Connecting to " + hostorip, Message_Type = Libvirt_WebManager.Models.Message_Types.info, Body = "Connecting....Help text should be explicitly associated with the form control it relates to using the aria-describedby attribute. This will ensure that assistive technologies – such as screen readers – will announce this help text when the user focuses or enters the control." });

                Libvirt_WebManager.Service.Message_Manager.Send(new Libvirt_WebManager.Models.Message.ErrorMessage
                {
                    Code = 2,
                    Title = "Error Message " + hostorip,
                    Message_Type = Libvirt_WebManager.Models.Message_Types.info,
                    Body = "private VM_Manager(Microsoft.AspNet.SignalR.IHubContext hub){\n_hubContext = hub;\n_Connections = new List<Libvirt.CS_Objects.Host>();\n\t_Libvirt_EventLoop = new Libvirt.Utilities.Default_EventLoop();\n\t_ErrorFunc = virErrorFunc;\n\tSystem.Web.Hosting.HostingEnvironment.QueueBackgroundWorkItem(ctx => _Libvirt_EventLoop.Start(ctx));}",
                    Additional_Info_1 = "additional info first here",
                    Additional_Info_2 = "additional info first here",
                    Additional_Info_3 = "additional info first here"

                });

                //var con = Libvirt.CS_Objects.Host.virConnectOpen(hostorip);
                //if (con.IsValid)
                //{
                //    _Connections.Add(con);
                //    con.virConnSetErrorFunc(_ErrorFunc);
                //    return true;
                //}
                //else
                //{
                //    con.Dispose();
                //    return false;
                //}
                return true;
            }
        }

    }
}