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
        public enum Volume_Types { raw, cow, qcow, qcow2, qed, vmdk, vpc, iso};
        public Storage_Volume()
        {
     
        }
        public string name { get; set; }
        public Volume_Types Volume_Type { get; set; }
        private string _key = "";
        public string key { get { return _key; } }
        public Int64 allocation { get; set; }
        public Memory_Allocation.UnitTypes Memory_Units { get; set; }
        public Int64 capacity { get; set; }
 
        public string To_XML()
        {
            var ret = "<volume type='file'><name>" + name + "</name><allocation unit='" + Memory_Units + "'>" + (allocation).ToString() + "</allocation>";
            ret += "<capacity unit='" + Memory_Units + "'>" + (capacity).ToString() + "</capacity>";
            ret += "<target><format type='" + (Volume_Type == Volume_Types.iso? "raw": Volume_Type.ToString()) + "'/></target></volume>";
            return ret;
        }
        public void From_XML(System.Xml.Linq.XElement xml)
        {

        }
        public void Validate(IValdiator v)
        {

        }
    }
}
