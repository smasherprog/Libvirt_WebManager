using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Interface
{
    public interface IValdiator
    {
        void AddError(string key, string message);
        bool IsValid();
    }
    public interface IValidation
    {
        void Validate(IValdiator v);
    }
}
