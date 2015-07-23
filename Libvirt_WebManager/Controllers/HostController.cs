using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libvirt_WebManager.Controllers
{
    public class HostController : CommonController
    {
        public ActionResult _Partial_Index(string host, string p)
        {
            var h = GetHost(host);
            var ret = new Libvirt_WebManager.ViewModels.Host.Host_VM { Hostname = "Does Not exist!" };
            if (h != null)
            {
                ret.Hostname = h.virConnectGetHostname();
                ret.Hypervisor = h.virConnectGetType();
                Libvirt._virNodeInfo info;
                h.virNodeGetInfo(out info);
                ret.Cpu_Model = info.model;
                ret.Memory = Libvirt_WebManager.Utilities.String.Formatting.Format(info.memory);
                ret.Cpu_Count = info.cpus.ToString();

                ret.Mhz = info.mhz.ToString();
                ret.Cores = info.cores.ToString();
                ret.Threads = info.threads.ToString();
            }
            return PartialView(ret);
        }
    }
}
