using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Libvirt_WebManager.Service
{
    public class Message_Manager
    {
        private readonly static Lazy<Message_Manager> _instance = new Lazy<Message_Manager>(() => new Message_Manager());
        public Message_Manager()
        {
            Filters = new List<Libvirt_WebManager.Models.Message.IFilter>();
            FuncFilters = new List<Action<Libvirt_WebManager.Models.IMessage>>();
        }

        private List<Libvirt_WebManager.Models.Message.IFilter> Filters;
        private List<Action<Libvirt_WebManager.Models.IMessage>> FuncFilters;

        public static void AddFilter(Libvirt_WebManager.Models.Message.IFilter filter)
        {
            _instance.Value.Filters.Add(filter);
        }
        public static void AddFilter(Action<Libvirt_WebManager.Models.IMessage> filter)
        {
            _instance.Value.FuncFilters.Add(filter);
        }
        public static void Send(Libvirt_WebManager.Models.IMessage message)
        {
            foreach (var item in _instance.Value.Filters)
            {
                item.Send(message);
            }
            foreach (var item in _instance.Value.FuncFilters)
            {
                item(message);
            }
        }
    }
}