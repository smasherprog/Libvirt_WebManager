using Libvirt.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Libvirt.Models.Concrete
{
    public class Network_Bridge : IXML
    {
        public enum Spt_Types { on, off };
        public Network_Bridge()
        {
            spt = Spt_Types.on;
            delay = 0;
        }
        public string name { get; set; }
        public Spt_Types spt { get; set; }
        public int delay { get; set; }
        public void From_XML(XElement xml)
        {
            if (xml != null)
            {
                var attr = xml.Attribute("name");
                if (attr != null) name = attr.Value;
                attr = xml.Attribute("spt");
                if (attr != null) spt = (Spt_Types)Enum.Parse(typeof(Spt_Types), attr.Value.ToLower());
                attr = xml.Attribute("delay");
                if (attr != null) delay = int.Parse(attr.Value);
            }
        }
        public string To_XML()
        {
            return "<bridge " + (!string.IsNullOrWhiteSpace(name) ? "name='" + name + "'" : "") + " spt='" + spt.ToString() + "' delay='" + delay.ToString() + "'/>";
        }


    }
    public class Network_Bandwith : IXML
    {
        public int average { get; set; }
        public int peak { get; set; }
        public int burst { get; set; }

        public string To_XML()
        {
            return "average='" + average.ToString() + "' peak='" + peak.ToString() + "' burst='" + burst.ToString() + "' />";
        }

        public void From_XML(XElement xml)
        {
            var attr = xml.Attribute("average");
            if (attr != null) average = int.Parse(attr.Value);
            attr = xml.Attribute("peak");
            if (attr != null) peak = int.Parse(attr.Value);
            attr = xml.Attribute("burst");
            if (attr != null) burst = int.Parse(attr.Value);
        }
    }
    public class Network_QOS : IXML
    {

        public Network_QOS()
        {
            Inbound = Outbound = null;
        }
        public Network_Bandwith Inbound { get; set; }
        public Network_Bandwith Outbound { get; set; }
        public void From_XML(XElement xml)
        {
            if (xml == null) return;
            var element = xml.Element("inbound");
            if (element != null)
            {
                Inbound = new Network_Bandwith();
                Inbound.From_XML(element);
            }
            element = xml.Element("outbound");
            if (element != null)
            {
                Outbound = new Network_Bandwith();
                Outbound.From_XML(element);
            }

        }
        public string To_XML()
        {
            if (Inbound == null && Outbound == null) return "";
            var ret = "<bandwidth>";
            if (Inbound != null) ret += "<inbound " + Inbound.To_XML();
            if (Outbound != null) ret += "<outbound " + Outbound.To_XML();
            ret += "</bandwidth>";
            return ret;
        }
    }
    public class Network_Configuration : IXML, IValidation
    {

        public Network_Configuration()
        {

        }
        public string default_gateway_address { get; set; }
        public string netmask { get; set; }
        public string dhcp_range_start { get; set; }
        public string dhcp_range_end { get; set; }
        public void From_XML(XElement xml)
        {
            if (xml == null) return;
            var attr = xml.Attribute("address");
            if (attr != null) default_gateway_address = attr.Value;
            attr = xml.Attribute("netmask");
            if (attr != null) netmask = attr.Value;

            var element = xml.Element("dhcp");
            if (element != null)
            {
                element = element.Element("range");
                if (element != null)
                {
                    attr = element.Attribute("start");
                    if (attr != null) dhcp_range_start = attr.Value;
                    attr = element.Attribute("end");
                    if (attr != null) dhcp_range_end = attr.Value;
                }
            }

        }
        public string To_XML()
        {
            var ret = "<ip address='" + default_gateway_address + "' netmask='" + netmask + "'>";
            ret += "<dhcp><range start='" + dhcp_range_start + "' end='" + dhcp_range_end + "'/></dhcp>";
            ret += "</ip>";
            return ret;
        }

        public void Validate(IValdiator v)
        {
            if (string.IsNullOrWhiteSpace(default_gateway_address)) v.AddError("default_gateway_address", "cannot be empty!");
            else if (!CheckIPValid(default_gateway_address)) v.AddError("default_gateway_address", "Not a valid IP address!");
            if (string.IsNullOrWhiteSpace(netmask)) v.AddError("netmask", "cannot be empty!");
            else if (!CheckIPValid(netmask)) v.AddError("netmask", "Not a valid IP address!");
            bool dhcp_range_good = false;
            if (string.IsNullOrWhiteSpace(dhcp_range_start)) v.AddError("dhcp_range_start", "cannot be empty!");
            else if (!CheckIPValid(dhcp_range_start)) v.AddError("dhcp_range_start", "Not a valid IP address!");
            else dhcp_range_good = true;
            if (string.IsNullOrWhiteSpace(dhcp_range_end)) v.AddError("dhcp_range_end", "cannot be empty!");
            else if (!CheckIPValid(dhcp_range_end)) v.AddError("dhcp_range_end", "Not a valid IP address!");
            else if (dhcp_range_good)
            {//all checks have passed except the dhcp end range
                int begin = BitConverter.ToInt32(System.Net.IPAddress.Parse(dhcp_range_start).GetAddressBytes(), 0);
                int end = BitConverter.ToInt32(System.Net.IPAddress.Parse(dhcp_range_end).GetAddressBytes(), 0);
                if (begin >= end)
                {
                    v.AddError("dhcp_range_start", "the start must be less than the end range!");
                    v.AddError("dhcp_range_end", "the end must be greater than the start range!");
                }
            }
        }
        private bool CheckIPValid(string strIP)
        {
            //  Split string by ".", check that array length is 4
            string[] arrOctets = strIP.Split('.');
            if (arrOctets.Length != 4)
                return false;

            //Check each substring checking that parses to byte
            byte obyte = 0;
            foreach (string strOctet in arrOctets)
                if (!byte.TryParse(strOctet, out obyte))
                    return false;

            return true;
        }
    }
    public class Network : IXML, IValidation
    {

        public enum Forward_Types { nat, bridge };
        public Network()
        {
            Reset();
        }
        public string name { get; set; }
        public string mac { get; set; }
        public bool ipv6 { get; set; }
        public string uuid { get; set; }
        private Forward_Types _Forward_Type;
        public Forward_Types Forward_Type
        {
            get
            {
                return _Forward_Type;
            }
            set
            {
                if (value == Forward_Types.bridge)
                {
                    QOS = new Network_QOS();// reset QOS since this is not valid in bridge setting
                    Configuration = new Network_Configuration();// these are not valid for a bridged connection since that info is taken from the subnet of the host
                }
                _Forward_Type = value;
            }
        }
        public Network_Bridge Bridge { get; set; }
        public Network_QOS QOS { get; set; }
        public Network_Configuration Configuration { get; set; }

        public string To_XML()
        {
            var ret = "<network ipv6='" + (ipv6 ? "yes" : "no") + "' >";
            ret += "<name>" + name + "</name>";
            if (!string.IsNullOrWhiteSpace(mac)) ret += "<mac name='" + mac + "'/>";
            if (!string.IsNullOrWhiteSpace(uuid)) ret += "<uuid>" + uuid + "</uuid>";
            ret += "<forward mode ='" + Forward_Type.ToString() + "' />";
            ret += Bridge.To_XML();
            ret += QOS.To_XML();
            ret += Configuration.To_XML();
            ret += "</network>";
            return ret;
        }
        private void Reset()
        {
            Forward_Type = Forward_Types.nat;
            ipv6 = false;
            Bridge = new Network_Bridge();
            QOS = new Network_QOS();
            Configuration = new Network_Configuration();
        }
        public void From_XML(System.Xml.Linq.XElement xml)
        {
            Reset();
            if (xml == null) return;
            var element = xml.Name == "network" ? xml : null;
            if (element == null) return;
            var attr = element.Attribute("ipv6");
            if (attr != null) ipv6 = attr.Value.ToLower() == "yes";

            var ele = element.Element("name");
            if (ele != null) name = ele.Value;
            ele = element.Element("mac");
            if (ele != null)
            {
                attr = ele.Attribute("name");
                if (attr != null) mac = attr.Value;
            }
            ele = element.Element("uuid");
            if (ele != null) uuid = ele.Value;
            ele = element.Element("forward");
            if (ele != null)
            {
                attr = ele.Attribute("mode");
                if (attr != null) Forward_Type = (Forward_Types)Enum.Parse(typeof(Forward_Types), attr.Value);
            }
            Bridge.From_XML(element.Element("bridge"));
            QOS.From_XML(element.Element("bandwidth"));
            Configuration.From_XML(element.Element("ip"));
        }
        public void Validate(IValdiator v)
        {
            Configuration.Validate(v);
        }
    }
}
