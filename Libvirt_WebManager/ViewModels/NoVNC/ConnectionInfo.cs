using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.ViewModels.NoVNC
{
    public class ConnectionInfo
    {
        public ConnectionInfo()
        {
            Path = "websockify";
        }
        public string Host { get; set;}
        public string Port { get; set; }
        public string Password { get; set; }
        public string Path { get; set; }
        public Libvirt.virDomainState State { get; set; }
    }
}