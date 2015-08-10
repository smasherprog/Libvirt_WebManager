using Libvirt.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libvirt.Models.Concrete
{
    public class Virtual_Machine : IXML, IValidation
    {
        public enum Domain_Types { kvm, qemu };//not supporting xen yet as I have no way of testing
        public enum Clock_Types { localtime, utc };
        public Virtual_Machine()
        {
            Reset();
        }
        public Domain_Types type { get; set; }
        public General_Metadata Metadata { get; set; }
        public BIOS_Bootloader BootLoader { get; set; }
        public CPU_Layout CPU { get; set; }
        public Memory_Allocation Memory { get; set; }
        public Features System_Features { get; set; }
        public Clock_Types clock { get; set; }
        public Graphics graphics { get; set; }
        public Libvirt.Models.Concrete.Drive_Collection Drives { get; set; }
        public string To_XML()
        {
            var ret = "<domain type='" + type.ToString() + "'>";
            ret += Metadata.To_XML();
            ret += BootLoader.To_XML();
            ret += CPU.To_XML();
            ret += Memory.To_XML();

            //standard options here....
            ret += "<on_poweroff>destroy</on_poweroff>";
            ret += "<on_reboot>restart</on_reboot>";
            ret += "<on_crash>restart</on_crash>";
            ret += System_Features.To_XML();
            ret += "<clock offset='" + clock.ToString() + "'></clock>";
            ret += "<devices>";
            ret += "<emulator>/usr/bin/qemu-system-x86_64</emulator>";//according to http://www.linux-kvm.org/page/RunningKVM  (kvm doesn't make a distinction between i386 and x86_64 so even in i386 you should use `qemu-system-x86_64`
            ret += Drives.To_XML();
            ret += graphics.To_XML();
            ret += "</devices>";
            ret += "</domain>";
            return ret;
        }
        public void Validate(IValdiator v)
        {

        }
        private void Reset()
        {
            type = Domain_Types.qemu;//default is software emulation of hardware, which is slow, but i am testing vm within a VM and its my only choice-- DEAL WITH IT!
            Metadata = new General_Metadata();
            BootLoader = new BIOS_Bootloader();
            CPU = new CPU_Layout();
            Memory = new Memory_Allocation();
            System_Features = new Features();
            clock = Clock_Types.utc;// utc for everything except windows which uses localtime
            Drives = new Libvirt.Models.Concrete.Drive_Collection();
            graphics = new Graphics();
        }
        public void From_XML(System.Xml.Linq.XElement xml)
        {
            var attr = xml.Attribute("type");
            if (attr != null)
            {
                var b = Domain_Types.qemu;
                Enum.TryParse(attr.Value, true, out b);
                type = b;
            }
            Metadata.From_XML(xml);
            BootLoader.From_XML(xml);
            CPU.From_XML(xml);
            Memory.From_XML(xml);
            System_Features.From_XML(xml);

            var element = xml.Element("clock");
            if (element != null)
            {
                attr = xml.Attribute("offset");
                if (attr != null)
                {
                    var b = Clock_Types.utc;
                    Enum.TryParse(attr.Value, true, out b);
                    clock = b;
                }
            }
            element = xml.Element("devices");
            if (element != null)
            {
                Drives.From_XML(element);
               graphics.From_XML(element);
         
            }
        }
    }
}
