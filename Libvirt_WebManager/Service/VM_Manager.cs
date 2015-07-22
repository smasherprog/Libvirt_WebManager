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
        }
        public static void Stop()
        {
            _instance.Dispose();
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
            _hubContext.Clients.All.ErrorEvent(Libvirt.API.MarshalErrorPtr(error));
        }
        public bool virConnectOpen(string hostorip)
        {

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


        public List<TreeViewModel> GetTreeData(string path)
        {
            var nodes = new List<TreeViewModel>();
            var splits = path.Split('/').ToList();
            splits.RemoveAll(a => string.IsNullOrWhiteSpace(a));
            var currentpath = "";
            if (splits.Count > 0)
            {

                Libvirt.CS_Objects.Host host;
                if (Connections.TryGetValue(splits[0].ToLower(), out host))
                {
                    var hostname = splits[0].ToLower();

                    if (splits.Count == 2)
                    {
                        Libvirt_WebManager.ViewModels.TreeViewModel.Node_Types typ;
                        if (Enum.TryParse(splits[1], out typ))
                        {
                            currentpath = "/" + hostname + "/" + typ.ToString() + "/";
                            if (typ == TreeViewModel.Node_Types.Domains)
                            {
                                Libvirt.CS_Objects.Domain[] d;
                                if (host.virConnectListAllDomains(out d, Libvirt.virConnectListAllDomainsFlags.VIR_DEFAULT) > -1)
                                {
                                    try
                                    {
                                        foreach (var domain in d)
                                        {
                                            var dname = domain.virDomainGetName();
                                            nodes.Add(new TreeViewModel { IsDirectory = false, Node_Type = TreeViewModel.Node_Types.Domain, Name = dname, Path = currentpath + dname + "/", Host = hostname });
                                            domain.Dispose();
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Debug.WriteLine(e.Message);
                                    }

                                }
                            }
                            else if (typ == TreeViewModel.Node_Types.Interfaces)
                            {

                            }
                            else if (typ == TreeViewModel.Node_Types.Storage_Pools)
                            {

                                Libvirt.CS_Objects.Storage_Pool[] p;
                                if (host.virConnectListAllStoragePools(out p, Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_ACTIVE | Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_INACTIVE | Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_AUTOSTART) > -1)
                                {
                                    foreach (var pool in p)
                                    {
                                        var dname = pool.virStoragePoolGetName();
                                        nodes.Add(new TreeViewModel { IsDirectory = true, Node_Type = TreeViewModel.Node_Types.Storage_Pool, Name = dname, Path = currentpath + dname + "/", Host = hostname });
                                        pool.Dispose();
                                    }
                                }
                            }
                        }
                    }
                    else if (splits.Count == 1)
                    {
                        currentpath = "/" + hostname + "/";
                        nodes.Add(new TreeViewModel { IsDirectory = true, Node_Type = TreeViewModel.Node_Types.Domains, Name = "Domains", Path = currentpath + "Domains/", Host = hostname });
                        nodes.Add(new TreeViewModel { IsDirectory = true, Node_Type = TreeViewModel.Node_Types.Interfaces, Name = "Interfaces", Path = currentpath + "Interfaces/", Host = hostname });
                        nodes.Add(new TreeViewModel { IsDirectory = true, Node_Type = TreeViewModel.Node_Types.Storage_Pools, Name = "Storage_Pools", Path = currentpath + "Storage_Pools/", Host = hostname });
                    }
                    else
                    {
                        nodes.Add(new TreeViewModel { IsDirectory = true, Node_Type = TreeViewModel.Node_Types.Host, Name = hostname, Path = currentpath + "/" + hostname + "/", Host = hostname });
                    }
                }
            }
            else
            {
                foreach (var item in Connections)
                {
                    nodes.Add(new TreeViewModel { IsDirectory = true, Node_Type = TreeViewModel.Node_Types.Host, Name = item.Key, Path = currentpath + "/" + item.Key + "/", Host = item.Key });
                }
            }
            return nodes;
        }
    }
}