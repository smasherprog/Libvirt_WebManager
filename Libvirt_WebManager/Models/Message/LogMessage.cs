using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.Models.Message
{
    public class LogMessage : IMessage
    {

        public string Title { get; set; }
        public string Body { get; set; }
        public Message_Types Message_Type { get; set; }

        public DateTime Time{ get;set;}
    }   
}