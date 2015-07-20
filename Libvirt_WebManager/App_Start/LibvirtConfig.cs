using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.App_Start
{
    public class LibvirtConfig
    {
        public static void Start()
        {
            Libvirt_WebManager.Service.VM_Manager.Start();
            Libvirt_WebManager.Service.ErrorMessage_Service.Init();
            Libvirt_WebManager.Service.LogMessage_Service.Init();
        }
    }
}