using Libvirt_WebManager.Signalr;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.Service
{
    public class Connection_Manager
    {
        private readonly static Lazy<Connection_Manager> _instance = new Lazy<Connection_Manager>(() => new Connection_Manager(GlobalHost.ConnectionManager.GetHubContext<Connection_ManagerHub>().Clients));
        public List<Libvirt.CS_Objects.Host> Hosts { get; set; }
        public static Connection_Manager Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        private Microsoft.AspNet.SignalR.Hubs.IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        private Connection_Manager(Microsoft.AspNet.SignalR.Hubs.IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            Hosts = new List<Libvirt.CS_Objects.Host>();
        }

    }
}