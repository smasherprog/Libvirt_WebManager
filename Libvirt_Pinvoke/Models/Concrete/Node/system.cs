using Libvirt.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Concrete.Node
{

    public class Sys : Device
    {
        public string product { get; set; }
        public string hardware { get; set; }
        public string firmware { get; set; }
       
        public Sys()
        {
            Reset();
        }
        
        private void Reset()
        {

        }
       
        public new void From_XML(System.Xml.Linq.XElement xml)
        {
            Reset();
            base.From_XML(xml);
            var element = xml.Element("capability");
            if (element == null)
            {
                if (xml.Name == "capability") element = xml;
                else element = null;
            }
            if (element == null) return;
           
            var ele = element.Element("product");
            if (ele != null) product = ele.Value;
        }

        public new string To_XML()
        {
            return "";
        }

        public new void Validate(IValdiator v)
        {
       

        }
    }
}
