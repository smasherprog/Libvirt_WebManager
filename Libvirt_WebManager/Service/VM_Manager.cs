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
        private static List<string> _connections = new List<string>() { "Host1", "Host3" };
        public List<TreeViewModel> GetTreeData(string path)
        {
            var nodes = new List<TreeViewModel>();
            var splits = path.Split('/').ToList();
            splits.RemoveAll(a => string.IsNullOrWhiteSpace(a));
            var currentpath="";
            if (splits.Count > 0)
            {
#if DEBUG
                var host = _connections.FirstOrDefault(a => a.ToLower() == splits[0].ToLower());
#else
                var host = _Connections.FirstOrDefault(a => a.virConnectGetHostname().ToLower() == splits[0].ToLower());
#endif
                if (host != null)
                {
                    if (splits.Count == 2)
                    {
                        currentpath = "/" + host + "/Domains/";
                        nodes.Add(new TreeViewModel { IsDirectory = false, Node_Type = TreeViewModel.Node_Types.Domain, Name = "Mis-13", Path = currentpath + "Mis-13/" });
                        nodes.Add(new TreeViewModel { IsDirectory = false, Node_Type = TreeViewModel.Node_Types.Domain, Name = "Finance-1", Path = currentpath + "Finance-1/" });
                        nodes.Add(new TreeViewModel { IsDirectory = false, Node_Type = TreeViewModel.Node_Types.Domain, Name = "Server-1", Path = currentpath + "Server-1/" });
                    }
                    else if (splits.Count == 1)
                    {
                        currentpath = "/" + host + "/";
                        nodes.Add(new TreeViewModel { IsDirectory = true, Node_Type= TreeViewModel.Node_Types.Domains , Name = "Domains", Path = currentpath + "Domains/" });
                        nodes.Add(new TreeViewModel { IsDirectory = true, Node_Type = TreeViewModel.Node_Types.Interfaces, Name = "Interfaces", Path = currentpath + "Interfaces/" });
                        nodes.Add(new TreeViewModel { IsDirectory = true, Node_Type = TreeViewModel.Node_Types.Storage_Pools, Name = "Storage_Pools", Path = currentpath + "Storage_Pools/" });
                    }
                    else
                    {
#if DEBUG
                        nodes.Add(new TreeViewModel { IsDirectory = true, Node_Type = TreeViewModel.Node_Types.Host, Name = host, Path = currentpath + "/" + host + "/" });
#else
                        nodes.Add(new TreeViewModel { IsDirectory = true, Ext = "host", Name = host.virConnectGetHostname(), Path = currentpath + "/" + host.virConnectGetHostname() });
#endif
                    }
                }
            }
            else
            {
#if DEBUG
                foreach (var item in _connections)
                {
                    nodes.Add(new TreeViewModel { IsDirectory = true, Node_Type = TreeViewModel.Node_Types.Host, Name = item, Path = currentpath + "/" + item + "/" });
                }
#else
                   foreach (var item in _Connections)
                {
                    nodes.Add(new TreeViewModel { IsDirectory = true, Ext = "host", Name = item.virConnectGetHostname(), Path = currentpath + "/" + item.virConnectGetHostname() });
                }
#endif

            }
            return nodes;
        }
    }
}