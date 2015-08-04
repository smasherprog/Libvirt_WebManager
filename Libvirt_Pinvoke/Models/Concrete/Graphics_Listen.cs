using Libvirt.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt_Pinvoke.Models.Concrete
{
    public class Graphics_Listen : IXML, IValidation
    {
        public Graphics_Listen()
        {

        }
        public string address { get; set; }
        public string To_XML()
        {
            return "<listen type='address' address='" + address + "'/>";
        }
        public void Validate(IValdiator v)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                v.AddError("address", "Address cannot be empty or null");
            }
        }

        public void From_XML(System.Xml.Linq.XElement xml)
        {
            var element = xml.Element("listen");
            if (element != null)
            {
                var addr = element.Attribute("address");
                if (addr != null)
                {
                    address = addr.Value;
                }
            }
        }
    }
}
