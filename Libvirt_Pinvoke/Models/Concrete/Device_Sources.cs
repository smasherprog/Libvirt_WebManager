using Libvirt.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Concrete
{
    public class Device_Source_Dir : IDevice_Source
    {
        public string dir_path { get; set; }
        public override string To_XML()
        {
            var ret = "<source dir='" + dir_path + "' " + base.To_XML() + ">";
            ret += "</source>";
            return ret;
        }
        public override void Validate(IValdiator v)
        {
            if (string.IsNullOrEmpty(dir_path))
            {
                v.AddError("Device_Source_Dir.dir_path", "Path cannot be empty!");
            }
        }

        public override void From_XML(System.Xml.Linq.XElement xml)
        {
            var os = xml.Element("source");
            if (os != null)
            {
                var attr = os.Attribute("dir");
                if (attr != null)
                {
                    dir_path = attr.Value;
                }
                base.From_XML(os);
            }
        }
    }
    public class Device_Source_File : IDevice_Source
    {
        public string file_path { get; set; }
        public override string To_XML()
        {
            var ret = "<source file='" + file_path + "' " + base.To_XML() + ">";
            ret += "</source>";
            return ret;
        }
        public override void Validate(IValdiator v)
        {
            if (string.IsNullOrEmpty(file_path))
            {
                v.AddError("Device_Source_File.file_path", "Path cannot be empty!");
            }
        }
        public override void From_XML(System.Xml.Linq.XElement xml)
        {
            var os = xml.Element("source");
            if (os != null)
            {
                var attr = os.Attribute("file");
                if (attr != null)
                {
                    file_path = attr.Value;
                }
                base.From_XML(os);
            }
        }
    }
    public class Device_Source_Block : IDevice_Source
    {
        public string block_path { get; set; }
        public override string To_XML()
        {
            if (string.IsNullOrWhiteSpace(block_path)) return "";
            else return "<source dev='" + block_path + "' " + base.To_XML() + "></source>";
        }
        public override void Validate(IValdiator v)
        {
            if (string.IsNullOrEmpty(block_path))
            {
                v.AddError("Device_Source_Block.block_path", "Path cannot be empty!");
            }
        }
        public override void From_XML(System.Xml.Linq.XElement xml)
        {
            var os = xml.Element("source");
            if (os != null)
            {
                var attr = os.Attribute("dev");
                if (attr != null)
                {
                    block_path = attr.Value;
                }
                base.From_XML(os);
            }
        }
    }
    public class Device_Source_Network : IDevice_Source
    {
        //missing auth stuff in here so it will only work with no authentication to the source target
        public Device_Source_Network()
        {
            protocol = Protocol_Types.iscsi;
        }
        public enum Protocol_Types { nbd, iscsi, rbd, sheepdog, gluster };
        public string network_path { get; set; }
        public Protocol_Types protocol { get; set; }
        public string host { get; set; }//hostname or ip address
        public override string To_XML()
        {
            var ret = "<source protocol='" + protocol.ToString() + "' name='" + network_path + "' " + base.To_XML() + ">";
            ret += "<host name='" + host + "'/>";
            ret += "</source>";
            return ret;
        }
        public override void Validate(IValdiator v)
        {
            if (string.IsNullOrEmpty(network_path))
            {
                v.AddError("Device_Source_Network.network_path", "Path cannot be empty!");
            }
        }
        public override void From_XML(System.Xml.Linq.XElement xml)
        {
            protocol = Protocol_Types.iscsi;
            var os = xml.Element("source");
            if (os != null)
            {
                var attr = os.Attribute("protocol");
                if (attr != null)
                {
                    var b = Protocol_Types.iscsi;
                    Enum.TryParse(attr.Value, true, out b);
                    protocol = b;
                }
                attr = os.Attribute("name");
                if (attr != null)
                {
                    network_path = attr.Value;
                }
                base.From_XML(os);
            }
            var element = os.Element("host");
            if (element != null)
            {
                var attr = os.Attribute("name");
                if (attr != null)
                {
                    host = attr.Value;
                }
            }
        }
    }
    public class Device_Source_Volume : IDevice_Source
    {
        //missing auth stuff in here so it will only work with no authentication to the source target
        public Device_Source_Volume()
        {

        }
        public string pool { get; set; }
        public string volume { get; set; }

        public override string To_XML()
        {
            var ret = "<source pool='" + pool + "' volume='" + volume + "' " + base.To_XML() + ">";
            ret += "</source>";
            return ret;
        }
        public override void Validate(IValdiator v)
        {
            if (string.IsNullOrEmpty(pool))
            {
                v.AddError("Device_Source_Volume.pool", "Pool cannot be empty!");
            }
            if (string.IsNullOrEmpty(volume))
            {
                v.AddError("Device_Source_Volume.volume", "Volume cannot be empty!");
            }
        }
        public override void From_XML(System.Xml.Linq.XElement xml)
        {

            var os = xml.Element("source");
            if (os != null)
            {
                var attr = os.Attribute("pool");
                if (attr != null)
                {
                    pool = attr.Value;
                }
                attr = os.Attribute("volume");
                if (attr != null)
                {
                    volume = attr.Value;
                }
                base.From_XML(os);
            }
        }
    }
}
