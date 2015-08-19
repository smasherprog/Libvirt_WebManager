using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.Areas.Domain.Code
{
    public static class ViewModelFactory
    {
        private static Libvirt.Models.Concrete.Virtual_Machine GetMachine(string host, string domain, Libvirt.Models.Concrete.Virtual_Machine machine = null)
        {
            if (machine == null)
            {
                var h = Service.VM_Manager.Instance.virConnectOpen(host);
                using (var d = h.virDomainLookupByName(domain))
                {
                    machine = d.virDomainGetXMLDesc(Libvirt.virDomainXMLFlags.VIR_DEFAULT);
                }
            }
            return machine;
        }

        public static Models.Domain_Details_Down Build_Domain_Details_Down(string host, string domain, out Libvirt.Models.Concrete.Virtual_Machine machine)
        {
            machine = GetMachine(host, domain, null);
            var vm = new Models.Domain_Details_Down();
            vm.type = machine.type;
            vm.Bios = machine.BootLoader;
            vm.MetaData = Utilities.AutoMapper.Mapper<Models.General_Metadata_VM>.Map(machine.Metadata);
            vm.MetaData.Host = host;
            vm.MetaData.Parent = domain;
            return vm;
        }
        public static Models.Domain_CPU_Down Build_Domain_CPU_Down(string host, string domain, out Libvirt.Models.Concrete.Virtual_Machine machine)
        {
            machine = GetMachine(host, domain, null);
            Libvirt._virNodeInfo info;
            Service.VM_Manager.Instance.virConnectOpen(host).virNodeGetInfo(out info);
            var vm = new Models.Domain_CPU_Down();
            vm.NodeCpuInfo = info;
            vm.CpuInfo = Utilities.AutoMapper.Mapper<Models.Domain_CPU_Down_VM>.Map(machine.CPU);
            vm.CpuInfo.Host = host;
            vm.CpuInfo.Parent = domain;
            return vm;
        }
        public static Models.Domain_Memory_Down Build_Domain_Memory_Down(string host, string domain, out Libvirt.Models.Concrete.Virtual_Machine machine)
        {
            machine = GetMachine(host, domain, null);
            Libvirt._virNodeInfo info;
            var h = Service.VM_Manager.Instance.virConnectOpen(host);
            h.virNodeGetInfo(out info);

            var vm = new Models.Domain_Memory_Down();
            vm.MemoryInfo = Utilities.AutoMapper.Mapper<Models.Domain_Memory_Down_VM>.Map(machine.Memory);
            vm.NodeCpuInfo = info;
            vm.MemoryInfo.Host = host;
            vm.MemoryInfo.Parent = domain;
            vm.MemoryInfo.currentMemory = vm.MemoryInfo.currentMemory > 0 ? vm.MemoryInfo.currentMemory / 1024 : 0;
            vm.MemoryInfo.memory = vm.MemoryInfo.memory > 0 ? vm.MemoryInfo.memory / 1024 : 0;
            vm.MemoryInfo.Host = host;
            vm.MemoryInfo.Parent = domain;
            return vm;
        }
        public static Models.Domain_Network_Down Build_Domain_Network_Down(string host, string domain, out Libvirt.Models.Concrete.Virtual_Machine machine)
        {
            machine = GetMachine(host, domain, null);
            var h = Service.VM_Manager.Instance.virConnectOpen(host);
           
            var vm = new Models.Domain_Network_Down();
            vm.Network = Utilities.AutoMapper.Mapper<Models.Domain_Network_Down_VM>.Map(machine.Iface);
            Libvirt.CS_Objects.Network[] ns;
            h.virConnectListAllNetworks(out ns, Libvirt.virConnectListAllNetworksFlags.VIR_DEFAULT);
            vm.Networks = ns.Select(a => a.virNetworkGetXMLDesc(Libvirt.virNetworkXMLFlags.VIR_DEFAULT)).ToList();
            foreach (var item in ns) item.Dispose();
            return vm;
        }
        
        public static Models.Domain_Bios_Down Build_Domain_Bios_Down(string host, string domain, out Libvirt.Models.Concrete.Virtual_Machine machine)
        {
            using (var d = Service.VM_Manager.Instance.virConnectOpen(host).virDomainLookupByName(domain))
            {
                machine = d.virDomainGetXMLDesc(Libvirt.virDomainXMLFlags.VIR_DEFAULT);
                var vm = new Models.Domain_Bios_Down();
                vm.BiosInfo = new Models.Domain_Bios_Down_VM();
                vm.BiosInfo.BootOrder = machine.BootLoader.BootOrder.Select(a => new Models.BootOrder_VM { BootType = a, Enabled = true }).ToList();
                vm.BiosInfo.ShowBootMenu = machine.BootLoader.ShowBootMenu;
                var autostart = 0;
                d.virDomainGetAutostart(ref autostart);
                vm.BiosInfo.StartGuestAutomatically = autostart == 1;
                vm.BiosInfo.Host = host;
                vm.BiosInfo.Parent = domain;

                return vm;
            }
        }
    }
}