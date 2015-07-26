using Libvirt.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Concrete
{
    public class Memory_Allocation : IXML, IValidation
    {
        public enum UnitTypes { b, KB, k, KiB, MB, M, MiB, GB, G, GiB, TB, T, TiB };
        public Memory_Allocation()
        {
            Reset();
        }
        public Int64 currentMemory { get; set; }//this is the initial ACTUAL ram AQUIRED from the Host
        public UnitTypes currentMemory_unit { get; set; }
        public Int64 memory { get; set; }//this is the amount of memory that the guest THINKS it has, but not the actual AQUIRED(Allocated) memory
        public UnitTypes memory_unit { get; set; }

        //public int currentMemory { get; set; }//Not needed as defaults to use the Memory element if not present
        public string To_XML()
        {
            var ret = "<currentMemory unit='" + currentMemory_unit.ToString() + "'>" + currentMemory.ToString() + "</maxMemory>";
            ret += "<memory unit='" + memory_unit.ToString() + "'>" + memory.ToString() + "</memory>";
            return ret;
        }
        public void Validate(IValdiator v)
        {
            if (memory_unit != currentMemory_unit)
            {
                //for now, both should equal one another...
                v.AddError("currentMemory_unit", "Must equal memory_unit");
                v.AddError("memory_unit", "Must equal currentMemory_unit");
            }
            else
            {
                if (currentMemory < memory)
                {
                    v.AddError("currentMemory", "currentMemory Cannot be less than memory!");
                }
            }
        }

        private void Reset()
        {
            memory = currentMemory = 128;
            currentMemory_unit = memory_unit = UnitTypes.MiB;
        }
        public void From_XML(System.Xml.Linq.XElement xml)
        {
            Reset();
            var element = xml.Element("memory");
            if (element != null)
            {
                Int64 i = 0;
                Int64.TryParse(element.Value, out i);
                if (i < 128) i = 128;
                var attr = element.Attribute("unit");
                if (attr != null)
                {
                    var b = UnitTypes.MiB;
                    Enum.TryParse(attr.Value, true, out b);
                    memory_unit = b;
                }
                else memory_unit = UnitTypes.KiB;//default
                memory = i;
            }
            element = xml.Element("currentMemory");
            if (element != null)
            {
                Int64 i = 0;
                Int64.TryParse(element.Value, out i);
                if (i < 128) i = 128;
                var attr = element.Attribute("unit");
                if (attr != null)
                {
                    var b = UnitTypes.MiB;
                    Enum.TryParse(attr.Value, true, out b);
                    currentMemory_unit = b;
                }
                else memory_unit = UnitTypes.KiB;//default
                currentMemory = i;

            }
            else
            {// if not present, uses same as memory
                currentMemory = memory;
                currentMemory_unit = memory_unit;
            }
        }

    }
}
