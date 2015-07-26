using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Concrete
{
    public class Validator : Libvirt.Models.Interface.IValdiator
    {
        protected Dictionary<string, List<string>> ErrorContainer;
        public Validator(Dictionary<string, List<string>> error_container)
        {
            ErrorContainer = error_container;
        }
        public void AddError(string key, string message)
        {
            List<string> obj = null;
            if (ErrorContainer.TryGetValue(key, out obj))
            {
                obj.Add(message);
            }
            else
            {
                obj = new List<string>();
                obj.Add(message);
                ErrorContainer.Add(key, obj);
            }
        }
        public bool IsValid()
        {
            return !ErrorContainer.Any();
        }
    }
}
