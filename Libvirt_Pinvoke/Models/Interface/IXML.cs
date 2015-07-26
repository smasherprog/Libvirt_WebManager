using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Interface
{
    public interface IXML
    {
        string To_XML();
        void From_XML(System.Xml.Linq.XElement xml);
    }
}
