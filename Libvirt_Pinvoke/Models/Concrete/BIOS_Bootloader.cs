using Libvirt.Models.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Concrete
{
    public class BIOS_Bootloader : IXML, IValidation
    {
        public enum Hypervisor_VM_Types { xen, linux, hvm, exe, uml };
        public enum Guest_OS_Bitness { i686, x86_64 };
        public enum Boot_Types { hd, cdrom, network };

        public BIOS_Bootloader()
        {
            Reset();
        }


        public Hypervisor_VM_Types type { get; set; }

        public List<Boot_Types> BootOrder { get; set; }
        public Guest_OS_Bitness Bitness { get; set; }
        public bool ShowBootMenu { get; set; }
        public string machine { get; set; }
        public string To_XML()
        {
            var ret = "<os>";

            ret += "<type arch='" + Bitness.ToString() + "' machine='"+machine+"'>" + type.ToString() + "</type>";//is everything a pc? I dont know.. 
            foreach (var item in BootOrder)
            {
                ret += "<boot dev='" + item.ToString() + "'/>";
            }
            if (ShowBootMenu)
            {
                ret += "<bootmenu enable='yes' timeout='3000'/>";
            }
            ret += "</os>";
            return ret;
        }
        private void Reset()
        {
            type = Hypervisor_VM_Types.hvm;
            BootOrder = new List<Boot_Types>();
            BootOrder.Add(Boot_Types.cdrom);
            BootOrder.Add(Boot_Types.hd);
            Bitness = Guest_OS_Bitness.x86_64;
            ShowBootMenu = false;
            machine = "pc-i440fx-2.3";
        }
        public void From_XML(System.Xml.Linq.XElement xml)
        {
            Reset();
            var os = xml.Element("os");
            if (os == null)
            {
                if (xml.Name == "os") os = xml;
                else os = null;
            }
            var element = os.Element("type");

            if (element != null)
            {
                var attr = element.Attribute("arch");
                if (attr != null)
                {
                    var b = Bitness;
                    Enum.TryParse(attr.Value, true, out b);
                    Bitness = b;
                }
                attr = element.Attribute("machine");
                if (attr != null) machine = attr.Value;
                  
                var m = type;
                Enum.TryParse(element.Value, true, out m);
                type = m;

            }

            BootOrder.Clear();
            foreach (var item in os.Elements("boot"))
            {
                var boot = Boot_Types.hd;
                Enum.TryParse(item.Attribute("dev").Value, true, out boot);
                BootOrder.Add(boot);
            }

            element = os.Element("bootmenu");
            if (element != null)
            {
                var attr = element.Attribute("enable");
                if (attr != null)
                {
                    if (attr.Value.ToLower() == "yes") ShowBootMenu = true;
                    else ShowBootMenu = false;
                }
            }
        }
        public void Validate(IValdiator v)
        {

        }
    }
}
