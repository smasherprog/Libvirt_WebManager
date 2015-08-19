using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.Service
{
    public class Network_Service : Interface.IService
    {
        public Network_Service(Libvirt.Models.Interface.IValdiator v) : base(v) { }
        public bool Create(Libvirt_WebManager.Areas.Network.Models.Create_Network_Down vm)
        {
            if (_Create(vm))
            {
                Message_Manager.Send(new Libvirt_WebManager.Models.Message.LogMessage { Title = "Create Network: '" + vm.name + "' ", Message_Type = Libvirt_WebManager.Models.Message_Types.success, Body = "Successfully Created a network!" });
                return true;
            }
            else
            {
                Message_Manager.Send(new Libvirt_WebManager.Models.Message.LogMessage { Title = "Create Network: '" + vm.name + "' ", Message_Type = Libvirt_WebManager.Models.Message_Types.warning, Body = "Failed to Create a network!" });
                return false;
            }
        }
        private bool _Create(Libvirt_WebManager.Areas.Network.Models.Create_Network_Down vm)
        {
            var h = Libvirt_WebManager.Service.VM_Manager.Instance.virConnectOpen(vm.Host);
            var n = Utilities.AutoMapper.Mapper<Libvirt.Models.Concrete.Network>.Map(vm);
            if (n.Forward_Type == Libvirt.Models.Concrete.Network.Forward_Types.nat)
            {
                n.Configuration = Utilities.AutoMapper.Mapper<Libvirt.Models.Concrete.Network_Configuration>.Map(vm.Configuration);
                if (vm.Inbound_QOS || vm.Outbound_QOS)
                {
                    n.QOS = new Libvirt.Models.Concrete.Network_QOS();

                    if (vm.Inbound_QOS) n.QOS.Inbound = Utilities.AutoMapper.Mapper<Libvirt.Models.Concrete.Network_Bandwith>.Map(vm.Inbound);
                    if (vm.Outbound_QOS) n.QOS.Outbound = Utilities.AutoMapper.Mapper<Libvirt.Models.Concrete.Network_Bandwith>.Map(vm.Outbound);
                }
            }
            using (var newnet = h.virNetworkDefineXML(n))
            {
                if (newnet.virNetworkIsActive() == 0) newnet.virNetworkCreate();//start the network up
                return newnet.IsValid;
            }
        }
        public bool Edit(Libvirt_WebManager.Areas.Network.Models.Create_Network_Down vm)
        {
            if (_Create(vm))
            {
                Message_Manager.Send(new Libvirt_WebManager.Models.Message.LogMessage { Title = "Update Network: '" + vm.name + "' ", Message_Type = Libvirt_WebManager.Models.Message_Types.success, Body = "Successfully updated the network configuration!" });
                return true;
            }
            else
            {
                Message_Manager.Send(new Libvirt_WebManager.Models.Message.LogMessage { Title = "Update Network: '" + vm.name + "' ", Message_Type = Libvirt_WebManager.Models.Message_Types.warning, Body = "Failed to updated the network configuration!" });
                return false;
            }
        }
    }
}