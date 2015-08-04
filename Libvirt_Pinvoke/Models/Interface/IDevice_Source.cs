using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Interface
{
    public abstract class IDevice_Source : IXML, IValidation
    {
        public IDevice_Source()
        {
            Source_Startup_Policy = Libvirt.Models.Concrete.Disk.Source_Startup_Policies.mandatory;
        }
        public virtual string To_XML()
        {
            return "startupPolicy='" + Source_Startup_Policy.ToString() + "'";
        }
        public Libvirt.Models.Concrete.Disk.Source_Startup_Policies Source_Startup_Policy { get; set; }
        public abstract void Validate(IValdiator v);
        public virtual void From_XML(System.Xml.Linq.XElement xml)
        {
            Source_Startup_Policy = Libvirt.Models.Concrete.Disk.Source_Startup_Policies.mandatory;
            if (xml != null)
            {
                var attr = xml.Attribute("startupPolicy");
                if (attr != null)
                {
                    var b = Libvirt.Models.Concrete.Disk.Source_Startup_Policies.mandatory;
                    Enum.TryParse(attr.Value, true, out b);
                    Source_Startup_Policy = b;
                }
            }
        }
    }
}
