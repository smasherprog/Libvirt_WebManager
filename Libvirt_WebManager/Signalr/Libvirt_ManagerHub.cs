using Libvirt_WebManager.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.Signalr
{
    public class Libvirt_ManagerHub : Microsoft.AspNet.SignalR.Hub
    {
        private readonly VM_Manager _Connection_Manager;

        public Libvirt_ManagerHub() : this(VM_Manager.Instance) { }

        public Libvirt_ManagerHub(VM_Manager conmanager)
        {
            _Connection_Manager = conmanager;
        }
    
    }
}