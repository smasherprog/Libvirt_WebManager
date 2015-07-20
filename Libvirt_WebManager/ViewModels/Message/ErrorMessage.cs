using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.ViewModels.Message
{
    public class ErrorMessage
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Additional_Info_1 { get; set; }
        public string Additional_Info_2 { get; set; }
        public string Additional_Info_3 { get; set; }
        public string Message_Type { get; set; }
        public DateTime Time { get; set; }
    }   
}