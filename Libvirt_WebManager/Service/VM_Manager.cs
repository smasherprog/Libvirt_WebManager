using Libvirt_WebManager.Signalr;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Libvirt_WebManager.Service
{
    public class VM_Manager : IDisposable
    {
        private static VM_Manager _instance = null;
        private ConcurrentDictionary<string, Libvirt.CS_Objects.Host> Connections;
        private Libvirt.Utilities.Default_EventLoop _Libvirt_EventLoop;
        private Libvirt.virErrorFunc _ErrorFunc;
        private readonly IHubContext _hubContext;

        public static VM_Manager Instance { get { return _instance; } }
        public IEnumerable<string> Hosts
        {
            get
            {
                return Connections.Keys.ToList();
            }
        }
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
            Connections = new ConcurrentDictionary<string, Libvirt.CS_Objects.Host>();
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
        public Libvirt.CS_Objects.Host virConnectOpen(string hostorip)
        {
            hostorip = hostorip.Replace("/", "");
            Libvirt.CS_Objects.Host h = null;
            if (Connections.TryGetValue(hostorip, out h))
            {//test if connection is alive
                lock (h)
                {//prevent other threads from accessing h concurrently
                    if (!h.IsValid || h.virConnectIsAlive() == 0)
                    {//reconnect
                        h.Dispose();
                        Message_Manager.Send(new Libvirt_WebManager.Models.Message.LogMessage { Title = "Reconnecting . . " + hostorip, Message_Type = Libvirt_WebManager.Models.Message_Types.info, Body = "Connected to host: " + hostorip });

                        var newh = Connect(hostorip);
                        if (newh == null)
                        {
                            Connections.TryRemove(hostorip, out newh);
                            return null;
                        }
                        Connections.TryUpdate(hostorip, newh, h);
                        return newh;
                    }
                    else return h;
                }
            }
            else
            {
                lock (Connections)
                {//new connection must lock the entire container
                    h = Connect(hostorip);
                    if (h == null) return h;
                    Connections.TryAdd(hostorip, h);
                }
                return h;
            }
        }
        private Libvirt.CS_Objects.Host Connect(string hostorip)
        {
            var con = Libvirt.CS_Objects.Host.virConnectOpen("qemu+tcp://" + hostorip + "/system");
            if (con.IsValid)
            {
                con.virConnSetErrorFunc(_ErrorFunc);
                Message_Manager.Send(new Libvirt_WebManager.Models.Message.LogMessage { Title = "Connected " + hostorip, Message_Type = Libvirt_WebManager.Models.Message_Types.info, Body = "Connected to host: " + hostorip });
                return con;
            }
            else
            {
                Message_Manager.Send(new Libvirt_WebManager.Models.Message.LogMessage { Title = "Unable to connect! " + hostorip, Message_Type = Libvirt_WebManager.Models.Message_Types.warning, Body = "Could not connect to host: " + hostorip });
            }
            con.Dispose();
            return null;
        }
    }
}