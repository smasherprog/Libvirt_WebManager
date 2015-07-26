using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Concrete
{
    public class Device_Collection : Libvirt.Models.Interface.IXML
    {
        public List<Libvirt.Models.Concrete.Device> Devices;

        public Device_Collection()
        {
            Reset();
        }
        public void Add(Libvirt.Models.Concrete.Device d)
        {
            Devices.Add(d);
            Organize();
        }
        public int RemoveAll(Predicate<Libvirt.Models.Concrete.Device> match)
        {
            var ret = Devices.RemoveAll(match);
            Organize();
            return ret;
        }
        private void Organize()
        {
            var l = 'a';
            foreach (var item in Devices)
            {
                item.Letter = l++;
            }
        }
        private void Reset(){
            Devices = new List<Libvirt.Models.Concrete.Device>();
        }
        public string To_XML()
        {
            var ret = "<devices>";
            ret += "<emulator>/usr/bin/qemu-system-x86_64</emulator>";//according to http://www.linux-kvm.org/page/RunningKVM  (kvm doesn't make a distinction between i386 and x86_64 so even in i386 you should use `qemu-system-x86_64`
            foreach (var item in Devices)
            {
                ret += item.To_XML();
            } 
            ret += "</devices>";
            return ret;
        }
        public void From_XML(System.Xml.Linq.XElement xml)
        {
            Reset();
      
            var element = xml.Element("devices");
            if (element == null) return;

            foreach (var item in element.Elements("disk"))
            {
             
                var d = new Libvirt.Models.Concrete.Device();
                d.From_XML(item);
                Devices.Add(d);
            }
        }
    }
}
