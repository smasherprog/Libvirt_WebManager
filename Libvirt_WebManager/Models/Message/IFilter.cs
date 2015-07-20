using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Libvirt_WebManager.Models.Message
{
    public interface IFilter
    {
        Task Send(Libvirt_WebManager.Models.IMessage message);
    }
}