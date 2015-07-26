using Libvirt.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Concrete
{
    public class CPU_Layout : IXML, IValidation
    {
        public enum CPU_Models { Hypervisor_Default, Broadwell, qemu32, qemu64, kvm32, kvm64, Haswell, Conroe, Penryn, Nehalem, Westmere, Opteron_G1, Opteron_G2, Opteron_G3, Opteron_G4, Sandybridge };
        public CPU_Layout()
        {
            Reset();

        }
        public int vCpu_Count { get; set; }
        public CPU_Models Cpu_Model { get; set; }

        //TOPOLOGY doesnt really make any sense at this point
        //private int _Socket_Count;
        //public int Socket_Count { get { return _Socket_Count; } set { } }
        //private int _Core_Count;
        //public int Core_Count { get { return _Core_Count; } set; }
        //private int _Thread_Count;
        //public int Thread_Count { get { return _Thread_Count; } set; }

        public string To_XML()
        {
            var ret = "<vcpu placement='static'>" + vCpu_Count.ToString() + "</vcpu>";
            ret += "<cpu match='exact'>";
            if (Cpu_Model != CPU_Models.Hypervisor_Default) ret += "<model>" + Cpu_Model.ToString() + "</model>";
            ret += "</cpu>";
            //if (Socket_Count > 0 || Core_Count > 0 || Thread_Count > 0)
            //{
            //    ret += "<cpu>";
            //    ret += "<topology ";
            //    if (Socket_Count > 0) ret += "sockets='" + Socket_Count.ToString() + "' ";
            //    if (Core_Count > 0) ret += "cores='" + Core_Count.ToString() + "' ";
            //    if (Thread_Count > 0) ret += "threads='" + Thread_Count.ToString() + "' ";
            //    ret += " /></cpu>";
            //}

            return ret;
        }
        private void Reset()
        {
            vCpu_Count = 1;
            Cpu_Model = CPU_Models.qemu64;// AGAIN, I am using a vm within a vm to test, so this must be selected as the default..
            // Socket_Count = Core_Count = Thread_Count = -1;
        }
        public void From_XML(System.Xml.Linq.XElement xml)
        {
            Reset();
            var element = xml.Element("vcpu");
            if (element != null)
            {
                var i = 0;
                Int32.TryParse(element.Value, out i);
                if (i == 0) i = 1;
                vCpu_Count = i;

            }
            element = xml.Element("model");
            if (element != null)
            {
                var b = CPU_Models.qemu64;
                Enum.TryParse(element.Value, true, out b);
                Cpu_Model = b;
            }
            else Cpu_Model = CPU_Models.Hypervisor_Default;
        }
        public void Validate(IValdiator v)
        {

        }
    }
}
