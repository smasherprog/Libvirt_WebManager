using Libvirt_WebManager.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.Signalr
{
    public class Connection_ManagerHub : Microsoft.AspNet.SignalR.Hub
    {
        private readonly Connection_Manager _Connection_Manager;

        public Connection_ManagerHub() : this(Connection_Manager.Instance) { }

        public Connection_ManagerHub(Connection_Manager conmanager)
        {
            _Connection_Manager = conmanager;
        }


    }
}