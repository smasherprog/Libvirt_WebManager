using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Interface
{
    public abstract class IStorage_Pool_Item : IXML, IValidation
    {
        public IStorage_Pool_Item()
        {

        }
        protected Concrete.Storage_Pool.Pool_Types _Pool_Type = Concrete.Storage_Pool.Pool_Types.dir;
        public Concrete.Storage_Pool.Pool_Types Pool_Type { get { return _Pool_Type; } }
        public string target_path { get; set; }
        public abstract string To_XML();
        public abstract void From_XML(System.Xml.Linq.XElement xml);
        public abstract void Validate(IValdiator v);
    }
}
