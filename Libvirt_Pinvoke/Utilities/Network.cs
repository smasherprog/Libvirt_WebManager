using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Utilities
{
    public static class Network
    {
        public static bool IsAvailable(string host_or_ip)
        {
            try
            {
                PingReply pingReply;
                using (var ping = new Ping())
                    pingReply = ping.Send(host_or_ip, 10*1000);
                return pingReply.Status == IPStatus.Success;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
