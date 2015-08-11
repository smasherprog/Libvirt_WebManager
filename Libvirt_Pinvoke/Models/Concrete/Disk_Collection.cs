using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Concrete
{
    public class Drive_Collection : Libvirt.Models.Interface.IXML
    {
        public List<Libvirt.Models.Concrete.Disk> Disks;

        public Drive_Collection()
        {
            Reset();
        }
        public void Add(Libvirt.Models.Concrete.Disk d)
        {
            Disks.Add(d);
            Organize();
        }
        public int RemoveAll(Predicate<Libvirt.Models.Concrete.Disk> match)
        {
            var ret = Disks.RemoveAll(match);
            Organize();
            return ret;
        }
        private void Organize()
        {
            var l = 'a';
            foreach (var item in Disks)
            {
                item.Letter = l++;
            }
        }
        private void Reset(){
            Disks = new List<Libvirt.Models.Concrete.Disk>();
        }
        public string To_XML()
        {
            var ret = "";
            foreach (var item in Disks)
            {
                ret += item.To_XML();
            } 
            return ret;
        }
        public void From_XML(System.Xml.Linq.XElement xml)
        {
            Reset();
            foreach (var item in xml.Elements("disk"))
            {
                var d = new Libvirt.Models.Concrete.Disk();
                d.From_XML(item);
                Disks.Add(d);
            }
        }
    }
}
