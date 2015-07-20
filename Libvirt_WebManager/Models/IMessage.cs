using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt_WebManager.Models
{
    public enum Message_Types { primary, success, info, warning, danger }
    public interface IMessage
    {
        DateTime Time { get; set; }
        string Title { get; set; }
        string Body { get; set; }
        Message_Types Message_Type { get; set; }
    }
}
