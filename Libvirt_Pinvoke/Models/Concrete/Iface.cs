using Libvirt.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Libvirt.Models.Concrete
{
    public class Iface : IXML
    {
        public enum Model_Types { rtl8139, e1000, virtio };
        public Iface()
        {
            Model_Type = Model_Types.virtio;
            network = "default";
        }

        public Model_Types Model_Type { get; set; }
        public string network { get; set; }
        public void From_XML(XElement xml)
        {
            if (xml == null) return;
            var element = xml.Element("source");
            if (element != null)
            {
                var attr = element.Attribute("network");
                if (attr != null) network = attr.Value;
            }
            element = xml.Element("model");
            if (element != null)
            {
                var attr = element.Attribute("type");
                if (attr != null) Model_Type = (Model_Types)Enum.Parse(typeof(Model_Types), attr.Value.ToLower());
            }
        }
        public string To_XML()
        {
            var ret = "<interface type='network'>";
            ret += "<source network='" + network + "'/>";
            ret += "<model type='" + Model_Type.ToString() + "' />";
            ret += "</interface>";
            return ret;

        }
    }
}
