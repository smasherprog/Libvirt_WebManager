using Libvirt.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Concrete
{
    public class Storage_Pool : IXML, IValidation
    {
        public enum Pool_Types { dir, fs, netfs, disk, iscsi, logical, scsi, mpath, rbd , sheepdog, gluster, zfs};
        public Storage_Pool()
        {
            Storage_Pool_Item = new Storage_Pool_Dir();
        }
        public string name { get; set; }
        private string _uuid = "";
        public string uuid { get { return _uuid; } }
       
        public IStorage_Pool_Item Storage_Pool_Item { get; set; }

        public string To_XML()
        {
            var ret = "<pool type='" + Storage_Pool_Item.Pool_Type.ToString() + "'>";
            ret += "<name>"+name+"</name>";
            ret += Storage_Pool_Item.To_XML();
            ret += "<target><path>" + Storage_Pool_Item.target_path + "</path></target>";
            ret += "</pool>";
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
