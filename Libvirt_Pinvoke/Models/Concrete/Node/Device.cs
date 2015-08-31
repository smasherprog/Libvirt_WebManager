using Libvirt.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Concrete.Node
{

    public abstract class Device : IXML, IValidation
    {
        public enum Node_Types { system, pci, usb_device, usb, net, scsi_host, scsi, storage }
        public string name { get; set; }

        public string parent { get; set; }
        public Device()
        {

        }

        public void From_XML(System.Xml.Linq.XElement xml)
        {
            var element = xml.Element("device");
            if (element == null)
            {
                if (xml.Name == "device") element = xml;
                else element = null;
            }
            if (element == null) return;
            var ele = element.Element("name");
            if (ele != null) name = ele.Value;
            ele = element.Element("parent");
            if (ele != null) parent = ele.Value;
        }

        public string To_XML()
        {
            return "";
        }

        public void Validate(IValdiator v)
        {
       

        }
    }
}
