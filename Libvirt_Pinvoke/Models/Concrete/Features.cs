using Libvirt.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Concrete
{
    public class Features : IXML, IValidation
    {
        public Features()
        {
            pae = acpi = apic = hap = true;

        }
        public bool pae { get; set; }
        public bool acpi { get; set; }
        public bool apic { get; set; }
        public bool hap { get; set; }
        public string To_XML()
        {
            var ret = "<features>";
            if (pae) ret += "<pae/>";
            if (acpi) ret += "<acpi/>";
            if (apic) ret += "<apic/>";

            //standard options that should be on
            ret += "<hyperv>";
            ret += "<relaxed state='on'/>";
            ret += "<vapic state='on'/>";
            ret += "<spinlocks state='on' retries='4096'/>";
            ret += "</hyperv>";

            ret += "</features>";
            return ret;
        }
        public void Validate(IValdiator v)
        {

        }

        public void From_XML(System.Xml.Linq.XElement xml)
        {
            var element = xml.Element("features");
            if (element == null)
            {
                if (xml.Name == "features") element = xml;
                else element = null;
            }
            pae = element.Element("pae")!= null;
            acpi = element.Element("acpi") != null;
            apic = element.Element("apic") != null;
        }
    }
}