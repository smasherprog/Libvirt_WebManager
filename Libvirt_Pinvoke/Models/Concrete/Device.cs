using Libvirt.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Concrete
{

    public class Disk : IXML, IValidation
    {
        public enum Disk_Types { file, block, dir, network, volume };
        public enum Disk_Device_Types { floppy, disk, cdrom, lun };//default is disk
        public enum Snapshot_Types { _internal, external, _default };//Store the snapshots WITH the underlying storage, or seperate?
        public enum Driver_Types { raw, qcow2 };
        public enum Driver_Cache_Types { _default, none, writethrough, writeback, directsync, _unsafe };
        public enum Source_Startup_Policies { mandatory, requisite, optional };
        public enum Disk_Bus_Types { ide, scsi, virtio, usb, sata, sd };//default is disk
        public Disk()
        {
            Device_Type = Disk_Types.dir;
            Device_Device_Type = Disk_Device_Types.disk;
            Snapshot_Type = Snapshot_Types._default;
            Driver_Type = Driver_Types.raw;
            Driver_Cache_Type = Driver_Cache_Types._default;
            Device_Bus_Type = Disk_Bus_Types.virtio;
            ReadOnly = false;
            Letter = 'a';
        }

        public Disk_Types Device_Type { get; set; }
        public Disk_Device_Types Device_Device_Type { get; set; }
        public Snapshot_Types Snapshot_Type { get; set; }
        public Driver_Types Driver_Type { get; set; }
        public Driver_Cache_Types Driver_Cache_Type { get; set; }
        public Disk_Bus_Types Device_Bus_Type { get; set; }
        public IDevice_Source Source { get; set; }
        public bool ReadOnly { get; set; }
        public char Letter { get; set; }
        public string To_XML()
        {
            var ret = "<disk type='" + Device_Type.ToString() + "' device='" + Device_Device_Type.ToString() + "' ";
            if (Snapshot_Type != Snapshot_Types._default) ret += "snapshot='" + Snapshot_Type.ToString().Replace("_", "") + "'";
            ret += ">";
            ret += "<driver type='" + Driver_Type.ToString() + "' cache='" + Driver_Cache_Type.ToString().Replace("_", "") + "' />";
            ret += Source.To_XML();

            ret += "<target dev='";
            if (Device_Bus_Type == Disk_Bus_Types.virtio) ret += "vd";
            else if (Device_Bus_Type == Disk_Bus_Types.scsi) ret += "sd";
            else ret += "sd";
            ret += Letter + "' bus='" + Device_Bus_Type.ToString() + "' />";

            if (ReadOnly) ret += "<readonly/>";
            ret += "</disk>";
            return ret;
        }
        private void Reset()
        {
            Device_Type = Disk_Types.dir;
            Device_Device_Type = Disk_Device_Types.disk;
            Snapshot_Type = Snapshot_Types._default;
            Driver_Type = Driver_Types.raw;
            Driver_Cache_Type = Driver_Cache_Types._default;
            Device_Bus_Type = Disk_Bus_Types.virtio;
            ReadOnly = false;
            Letter = 'a';
        }
        public void From_XML(System.Xml.Linq.XElement xml)
        {
            Reset();
            var os = xml;
            if (os != null)
            {
                var attr = os.Attribute("type");
                if (attr != null)
                {
                    var b = Disk_Types.dir;
                    Enum.TryParse(attr.Value, true, out b);
                    Device_Type = b;
                }
                attr = os.Attribute("device");
                if (attr != null)
                {
                    var b = Disk_Device_Types.disk;
                    Enum.TryParse(attr.Value, true, out b);
                    Device_Device_Type = b;
                }
                attr = os.Attribute("snapshot");
                if (attr != null)
                {
                    var b = Snapshot_Types._default;
                    Enum.TryParse(attr.Value.Replace("_", ""), true, out b);
                    Snapshot_Type = b;
                }
            }
            var element = os.Element("driver");
            if (element != null)
            {
                var attr = os.Attribute("type");
                if (attr != null)
                {
                    var b = Driver_Types.raw;
                    Enum.TryParse(attr.Value, true, out b);
                    Driver_Type = b;
                }
                attr = os.Attribute("cache");
                if (attr != null)
                {
                    var b = Driver_Cache_Types._default;
                    Enum.TryParse(attr.Value.Replace("_", ""), true, out b);
                    Driver_Cache_Type = b;
                }
            }
            if (Device_Type == Disk_Types.dir) Source = new Device_Source_Dir();
            else if (Device_Type == Disk_Types.file) Source = new Device_Source_File();
            else if (Device_Type == Disk_Types.block) Source = new Device_Source_Block();
            else if (Device_Type == Disk_Types.network) Source = new Device_Source_Network();
            else if (Device_Type == Disk_Types.volume)  Source = new Device_Source_Volume();
            if(Source!= null) Source.From_XML(os);

            os = xml.Element("target");
            if (os != null)
            {
                var attr = os.Attribute("bus");
                if (attr != null)
                {
                    var b = Disk_Bus_Types.virtio;
                    Enum.TryParse(attr.Value, true, out b);
                    Device_Bus_Type = b;
                }
                attr = os.Attribute("dev");
                if (attr != null)
                {
                    Letter = attr.Value.LastOrDefault();
                }
            }
            os = xml.Element("readonly");
            if (os != null) ReadOnly = true;
            else ReadOnly = false;
        }
        public void Validate(IValdiator v)
        {
            if (Device_Device_Type == Disk_Device_Types.cdrom)
            {
                ReadOnly = true;// force this here
            }
            if (Device_Type == Disk_Types.file && Device_Device_Type == Disk_Device_Types.cdrom)
            {
                var src = Source as Device_Source_File;
                if (!string.IsNullOrWhiteSpace(src.file_path))
                {
                    if (!src.file_path.EndsWith(".iso"))
                    {
                        v.AddError("Source.file_path", "You must select an ISO!");
                    }
                }
                else
                {
                    v.AddError("Source.file_path", "You must select an ISO!");
                }
            }

        }
    }
}
