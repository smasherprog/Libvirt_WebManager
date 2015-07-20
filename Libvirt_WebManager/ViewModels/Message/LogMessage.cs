using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.ViewModels.Message
{
    public class LogMessage
    {
        public DateTime Time { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Message_Type { get; set; }
    }   
}