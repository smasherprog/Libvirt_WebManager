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
                    machine = d.virDomainGetXMLDesc(Libvirt.virDomainXMLFlags.VIR_DOMAIN_XML_INACTIVE | Libvirt.virDomainXMLFlags.VIR_DOMAIN_XML_SECURE);
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
        public static Models.Domain_Graphics_Down Build_Domain_Graphics_Down(string host, string domain, out Libvirt.Models.Concrete.Virtual_Machine machine)
        {
            machine = GetMachine(host, domain, null);
            var vm = new Models.Domain_Graphics_Down();
            vm.Domain_Graphics = new Models.Domain_Graphics_Down_VM();
            vm.Domain_Graphics.Graphic_Type = machine.graphics.Graphic_Type;
            vm.Domain_Graphics.Listen_Address_Type = Models.Listen_Address_Types.LocalHost;
            if (!string.IsNullOrWhiteSpace(machine.graphics.listen))
            {
                vm.Domain_Graphics.Listen_Address_Type = (machine.graphics.listen == "0.0.0.0" ? Models.Listen_Address_Types.All_Interfaces : Models.Listen_Address_Types.LocalHost);
            }
            vm.Domain_Graphics.passwd = machine.graphics.passwd;
            vm.Domain_Graphics.passwdValidTo = machine.graphics.passwdValidTo;
            vm.Domain_Graphics.WebSocket = machine.graphics.websocket.HasValue;

            vm.Domain_Graphics.Host = host;
            vm.Domain_Graphics.Parent = domain;
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
            using (var ns = h.virConnectListAllNetworks(Libvirt.virConnectListAllNetworksFlags.VIR_DEFAULT))
            {
                vm.Networks = ns.Select(a => a.virNetworkGetXMLDesc(Libvirt.virNetworkXMLFlags.VIR_DEFAULT)).ToList();
            }
            return vm;
        }

        public static Models.Domain_Bios_Down Build_Domain_Bios_Down(string host, string domain, out Libvirt.Models.Concrete.Virtual_Machine machine)
        {
            machine = GetMachine(host, domain, null);
            var h = Service.VM_Manager.Instance.virConnectOpen(host);

            using (var d = h.virDomainLookupByName(domain))
            {

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
        public static Models.Domain_Drive_Down Domain_Drive_Down(string host, string domain, char letter, out Libvirt.Models.Concrete.Virtual_Machine machine)
        {
            machine = GetMachine(host, domain, null);
            var h = Service.VM_Manager.Instance.virConnectOpen(host);

            using (var d = h.virDomainLookupByName(domain))
            {
                var vm = new Models.Domain_Drive_Down();
                vm.Domain_Drive = new Models.Domain_Drive_Down_VM();
                vm.Domain_Drive = Utilities.AutoMapper.Mapper<Models.Domain_Drive_Down_VM>.Map(machine.Drives.Disks.FirstOrDefault(a => a.Letter == letter));
                vm.Disk = machine.Drives.Disks.FirstOrDefault(a => a.Letter == letter);
                var volthingy = vm.Disk.Source as Libvirt.Models.Concrete.Device_Source_Volume;
                if (volthingy != null)
                {
                    vm.Domain_Drive.Pool = volthingy.pool;
                    vm.Domain_Drive.Volume = volthingy.volume;
                }
                vm.Domain_Drive.Source_Startup_Policy = vm.Disk.Source.Source_Startup_Policy;
                vm.Domain_Drive.Host = host;
                vm.Domain_Drive.Parent = domain;

                return vm;
            }
        }
    }
}