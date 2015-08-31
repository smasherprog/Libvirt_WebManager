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
            var element = xml.Element("pool");
            if (element == null)
            {
                if (xml.Name == "pool") element = xml;
                else element = null;
            }
            if (element == null) return;
            IStorage_Pool_Item.Pool_Types type = IStorage_Pool_Item.Pool_Types.dir;
            if (element != null)
            {
                var attr = element.Attribute("type");
                if (attr != null)
                {
                    type = (IStorage_Pool_Item.Pool_Types)Enum.Parse(typeof(IStorage_Pool_Item.Pool_Types), attr.Value);
                }
            }
            if (type == IStorage_Pool_Item.Pool_Types.dir) Storage_Pool_Item = new Storage_Pool_Dir();
            else if (type == IStorage_Pool_Item.Pool_Types.iscsi) Storage_Pool_Item = new Storage_Pool_Iscsi();
            else if (type == IStorage_Pool_Item.Pool_Types.netfs) Storage_Pool_Item = new Storage_Pool_Netfs();
            else if (type == IStorage_Pool_Item.Pool_Types.disk) Storage_Pool_Item = new Storage_Pool_Disk();
            else
            {
                throw new NotImplementedException("Other Storage Types are not implemented yet");
            }
            Storage_Pool_Item.From_XML(element);
        }
        public void Validate(IValdiator v)
        {

        }
    }
}
