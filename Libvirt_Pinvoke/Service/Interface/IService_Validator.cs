using Libvirt.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Service.Interface
{
    public interface IService_Validator<T, F>
    {
        void Validate(IValdiator v, T obj, F obj2);
    }
}
