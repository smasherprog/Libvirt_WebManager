using Libvirt.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Concrete
{
    public class General_Metadata : IXML, IValidation
    {
        public General_Metadata()
        {

        }
        public string name { get; set; }
       
        public string uuid { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string To_XML()
        {
            var ret = "";
            ret += "<name>" + name + "</name>";
            ret += "<title>" + title + "</title>";
            ret += "<description>" + description + "</description>";
            if(!string.IsNullOrWhiteSpace(uuid)) ret += "<uuid>" + uuid + "</uuid>";
            return ret;
        }
        public void Validate(IValdiator v)
        {
            if (string.IsNullOrWhiteSpace(name)) v.AddError("General_Metadata.name", "Name cannot be empty!");
            else
            {
                foreach (var item in name)
                {
                    if (!Char.IsLetter(item) && item != '_')
                    {
                        v.AddError("General_Metadata.name", "Name can only contain letters or underscores!");
                        break;
                    }
                }
            }
        }

        public void From_XML(System.Xml.Linq.XElement xml)
        {
            var element = xml.Element("name");
            if (element != null)
            {
                name = element.Value;
            }
            element = xml.Element("title");
            if (element != null)
            {
                title = element.Value;
            } 
            element = xml.Element("description");
            if (element != null)
            {
                description = element.Value;
            }
            element = xml.Element("uuid");
            if (element != null)
            {
                uuid = element.Value;
            }
        }
    }
}
