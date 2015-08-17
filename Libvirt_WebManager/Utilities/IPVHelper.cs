using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.Utilities
{
    public class IPVHelper
    {
        public static bool CheckIPValid(string strIP)
        {
            if (string.IsNullOrWhiteSpace(strIP)) return false;
            //  Split string by ".", check that array length is 4
            string[] arrOctets = strIP.Split('.');
            if (arrOctets.Length != 4)
                return false;

            //Check each substring checking that parses to byte
            byte obyte = 0;
            foreach (string strOctet in arrOctets)
                if (!byte.TryParse(strOctet, out obyte))
                    return false;
            System.Net.IPAddress address;
            return System.Net.IPAddress.TryParse(strIP, out address);
 
        }
    }
}