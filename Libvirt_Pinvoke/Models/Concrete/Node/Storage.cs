using Libvirt.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Concrete.Node
{

    public class Storage : Device
    {
        public string block { get; set; }
        public string bus { get; set; }
        public string drive_type { get; set; }
        public string model { get; set; }
        public string vendor { get; set; }
        public string serial { get; set; }
        public string size { get; set; }
        public string logical_block_size { get; set; }
        public string num_blocks { get; set; }
        public Storage()
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
           
            var ele = element.Element("block");
            if (ele != null) block = ele.Value;
            ele = element.Element("bus");
            if (ele != null) bus = ele.Value;

            ele = element.Element("drive_type");
            if (ele != null) drive_type = ele.Value;

            ele = element.Element("model");
            if (ele != null) model = ele.Value;

            ele = element.Element("vendor");
            if (ele != null) vendor = ele.Value;

            ele = element.Element("serial");
            if (ele != null) serial = ele.Value;
            ele = element.Element("size");
            if (ele != null) size = ele.Value;
            ele = element.Element("logical_block_size");
            if (ele != null) logical_block_size = ele.Value;
            ele = element.Element("num_blocks");
            if (ele != null) num_blocks = ele.Value;
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
