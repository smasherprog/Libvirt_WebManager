using Libvirt.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Concrete
{
    public class Storage_Volume : IXML, IValidation
    {
        //always file type for now
        public enum Volume_Types { raw, cow, iso, qcow, qcow2, qed, vmdk, vpc, dir };
        public Storage_Volume()
        {

        }
        public string name { get; set; }
        public Volume_Types Volume_Type { get; set; }
        private string _key = "";
        public string key { get { return _key; } }
        public UInt64 allocation { get; set; }
        public Memory_Allocation.UnitTypes Memory_Units { get; set; }
        public UInt64 capacity { get; set; }

        public string To_XML()
        {
            var ret = "<volume type='file'><name>" + name + "</name><allocation unit='" + Memory_Units + "'>" + (allocation).ToString() + "</allocation>";
            ret += "<capacity unit='" + Memory_Units + "'>" + (capacity).ToString() + "</capacity>";
            ret += "<target><format type='" + Volume_Type.ToString() + "'/></target>";
            ret += "</volume>";
            return ret;
        }
        public void From_XML(System.Xml.Linq.XElement xml)
        {
            if (xml == null) return;

            var element = xml.Element("volume");
            if (element == null)
            {
                if (xml.Name == "volume") element = xml;
                else return;
            }

            var ele = xml.Element("name");
            if (ele != null)
                name = ele.Value;

            ele = xml.Element("allocation");
            if (ele != null)
            {
                allocation = UInt64.Parse(ele.Value);
                var attr = ele.Attribute("unit");
                if (attr != null)
                {
                    Memory_Units = (Memory_Allocation.UnitTypes)Enum.Parse(typeof(Memory_Allocation.UnitTypes), attr.Value);
                }
            }
            ele = xml.Element("capacity");
            if (ele != null)
            {
                capacity = UInt64.Parse(ele.Value);
                var attr = ele.Attribute("unit");
                if (attr != null)
                {
                    Memory_Units = (Memory_Allocation.UnitTypes)Enum.Parse(typeof(Memory_Allocation.UnitTypes), attr.Value);
                }
            }
            ele = xml.Element("target");
            if (ele != null)
            {
                ele = ele.Element("format");
                if (ele != null)
                {
                    var attr = ele.Attribute("type");
                    if (attr != null)
                    {
                        Volume_Type = (Volume_Types)Enum.Parse(typeof(Volume_Types), attr.Value);
                    }
                }
            }
        }
        public void Validate(IValdiator v)
        {

        }
    }
}
