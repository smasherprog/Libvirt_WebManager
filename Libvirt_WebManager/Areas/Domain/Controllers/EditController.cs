using System.Diagnostics;
using System.Web.Mvc;
using System.Linq;

namespace Libvirt_WebManager.Areas.Domain.Controllers
{
    public class EditController : Libvirt_WebManager.Controllers.CommonController
    {
        private Service.Domain_Service _Domain_Service;
        public EditController()
        {
            _Domain_Service = new Service.Domain_Service(new Libvirt_WebManager.Models.Validator(ModelState));
        }

        [HttpGet]
        public ActionResult _Partial_IndexMainContent(string host, string domain)
        {
            var vm = new Models.Domain_Hardware_Down();
            using(var d = GetHost(host).virDomainLookupByName(domain))
            {
                vm.Host = host;
                vm.Parent = domain;
                vm.Machine = d.virDomainGetXMLDesc(Libvirt.virDomainXMLFlags.VIR_DEFAULT);
            }
            return PartialView(vm);
        }
        [HttpGet]
        public ActionResult _Partial_Details(string Host, string Parent)
        {
            Libvirt.Models.Concrete.Virtual_Machine machine = null;
            return PartialView(Code.ViewModelFactory.Build_Domain_Details_Down(Host, Parent, out machine));
        }

        [HttpPost]
        public ActionResult _Partial_Details(Models.General_Metadata_VM MetaData)
        {
            Libvirt.Models.Concrete.Virtual_Machine machine = null;
            var vm = Code.ViewModelFactory.Build_Domain_Details_Down(MetaData.Host, MetaData.Parent, out machine);
            machine.Metadata = Utilities.AutoMapper.Mapper<Libvirt.Models.Concrete.General_Metadata>.Map(MetaData);
            if (ModelState.IsValid) virDomainDefineXML(machine, GetHost(MetaData.Host));
            vm.MetaData = MetaData;
            return PartialView(vm);
        }
        [HttpGet]
        public ActionResult _Partial_Graphics(string Host, string Parent)
        {
            Libvirt.Models.Concrete.Virtual_Machine machine = null;
            return PartialView(Code.ViewModelFactory.Build_Domain_Graphics_Down(Host, Parent, out machine));
        }
        [HttpPost]
        public ActionResult _Partial_Graphics(Models.Domain_Graphics_Down_VM Domain_Graphics)
        {
            Libvirt.Models.Concrete.Virtual_Machine machine = null;
            var vm = Code.ViewModelFactory.Build_Domain_Graphics_Down(Domain_Graphics.Host, Domain_Graphics.Parent, out machine);

            if (Domain_Graphics.WebSocket)
            {
                machine.graphics.autoport = true;
                machine.graphics.websocket = -1;
            } else
            {
                machine.graphics.autoport = false;
                machine.graphics.websocket = null;
            }
            machine.graphics.passwd = Domain_Graphics.passwd;
            machine.graphics.passwdValidTo = Domain_Graphics.passwdValidTo;
            machine.graphics.Graphic_Type = Domain_Graphics.Graphic_Type;
            machine.graphics.listen = Domain_Graphics.Listen_Address_Type == Models.Listen_Address_Types.LocalHost ? "localhost" : "0.0.0.0";

            if (ModelState.IsValid) virDomainDefineXML(machine, GetHost(Domain_Graphics.Host));

            vm.Domain_Graphics = Domain_Graphics;
            return PartialView(vm);
        }

        [HttpGet]
        public ActionResult _Partial_CPU(string Host, string Parent)
        {
            Libvirt.Models.Concrete.Virtual_Machine machine = null;
            return PartialView(Code.ViewModelFactory.Build_Domain_CPU_Down(Host, Parent, out machine));
        }
        [HttpPost]
        public ActionResult _Partial_CPU(Models.Domain_CPU_Down_VM CpuInfo)
        {
            Libvirt.Models.Concrete.Virtual_Machine machine = null;
            var vm = Code.ViewModelFactory.Build_Domain_CPU_Down(CpuInfo.Host, CpuInfo.Parent, out machine);

            var validator = new Libvirt.Service.Concrete.CPU_Layout_Validator();
            var cpulayout = Utilities.AutoMapper.Mapper<Libvirt.Models.Concrete.CPU_Layout>.Map(CpuInfo);
            validator.Validate(new Libvirt_WebManager.Models.Validator(ModelState), cpulayout, GetHost(CpuInfo.Host));
            machine.CPU = cpulayout;
            if (ModelState.IsValid) virDomainDefineXML(machine, GetHost(CpuInfo.Host));

            vm.CpuInfo = CpuInfo;
            return PartialView(vm);
        }

        [HttpGet]
        public ActionResult _Partial_Memory(string Host, string Parent)
        {
            Libvirt.Models.Concrete.Virtual_Machine machine = null;
            return PartialView(Code.ViewModelFactory.Build_Domain_Memory_Down(Host, Parent, out machine));
        }
        [HttpPost]
        public ActionResult _Partial_Memory(Models.Domain_Memory_Down_VM MemoryInfo)
        {
            Libvirt.Models.Concrete.Virtual_Machine machine = null;
            var vm = Code.ViewModelFactory.Build_Domain_Memory_Down(MemoryInfo.Host, MemoryInfo.Parent, out machine);
            var h = GetHost(MemoryInfo.Host);

            var validator = new Libvirt.Service.Concrete.Memory_Allocation_Validator();
            var memorylayout = Utilities.AutoMapper.Mapper<Libvirt.Models.Concrete.Memory_Allocation>.Map(MemoryInfo);
            memorylayout.memory_unit = memorylayout.currentMemory_unit = Libvirt.Models.Concrete.Memory_Allocation.UnitTypes.MiB;
            validator.Validate(new Libvirt_WebManager.Models.Validator(ModelState), memorylayout, h);
            machine.Memory = memorylayout;

            if(ModelState.IsValid) virDomainDefineXML(machine, h);

            vm.MemoryInfo = MemoryInfo;
            return PartialView(vm);
        }
        [HttpGet]
        public ActionResult _Partial_Network(string Host, string Parent)
        {
            Libvirt.Models.Concrete.Virtual_Machine machine = null;
            return PartialView(Code.ViewModelFactory.Build_Domain_Network_Down(Host, Parent, out machine));
        }
        [HttpPost]
        public ActionResult _Partial_Network(Models.Domain_Network_Down_VM net)
        {
            Libvirt.Models.Concrete.Virtual_Machine machine = null;
            var vm = Code.ViewModelFactory.Build_Domain_Network_Down(net.Host, net.Parent, out machine);
            var h = GetHost(net.Host);
            machine.Iface = Utilities.AutoMapper.Mapper<Libvirt.Models.Concrete.Iface>.Map(net);
            if (ModelState.IsValid) virDomainDefineXML(machine, h);
            vm.Network = net;
            return PartialView(vm);
        }

        
        [HttpGet]
        public ActionResult _Partial_BootOptions(string Host, string Parent)
        {
            Libvirt.Models.Concrete.Virtual_Machine machine = null;
            var vm = Code.ViewModelFactory.Build_Domain_Bios_Down(Host, Parent, out machine);
            BuildBootOrder(vm.BiosInfo, machine);
            return PartialView(vm);
        }

        [HttpPost]
        public ActionResult _Partial_BootOptions(Models.Domain_Bios_Down_VM BiosInfo)
        {
            Libvirt.Models.Concrete.Virtual_Machine machine = null;

            var vm = Code.ViewModelFactory.Build_Domain_Bios_Down(BiosInfo.Host, BiosInfo.Parent, out machine);
            machine.BootLoader.BootOrder = BiosInfo.BootOrder.Where(a => a.Enabled).Select(a => (Libvirt.Models.Concrete.BIOS_Bootloader.Boot_Types)System.Enum.Parse(typeof(Libvirt.Models.Concrete.BIOS_Bootloader.Boot_Types), a.BootType.ToString())).ToList();
            machine.BootLoader.ShowBootMenu = BiosInfo.ShowBootMenu;
            if (ModelState.IsValid)
            {
                var h = GetHost(BiosInfo.Host);
                using (var d = h.virDomainLookupByName(BiosInfo.Parent))
                {
                    d.virDomainSetAutostart(BiosInfo.StartGuestAutomatically ? 1 : 0);
                }
                virDomainDefineXML(machine, h);
            }

            vm.BiosInfo = BiosInfo;
            BuildBootOrder(vm.BiosInfo, machine);
            return PartialView(vm);
        }


        [HttpGet]
        public ActionResult _Partial_Drives(string Host, string Parent, char letter)
        {
            Libvirt.Models.Concrete.Virtual_Machine machine = null;
            return PartialView(Code.ViewModelFactory.Domain_Drive_Down(Host, Parent, letter, out machine));
        }

        [HttpPost]
        public ActionResult _Partial_Drives(Models.Domain_Drive_Down_VM Domain_Drive)
        {
            Libvirt.Models.Concrete.Virtual_Machine machine = null;

            var vm = Code.ViewModelFactory.Domain_Drive_Down(Domain_Drive.Host, Domain_Drive.Parent, Domain_Drive.Letter, out machine);
         
            if (ModelState.IsValid)
            {
                var harddrive = new Libvirt.Models.Concrete.Disk();
                harddrive.Device_Bus_Type = Domain_Drive.Device_Bus_Type;
                harddrive.Disk_Device_Type= Domain_Drive.Disk_Device_Type;
                harddrive.Device_Type = Libvirt.Models.Concrete.Disk.Disk_Types.volume;//use volumes because this makes management much easier
                harddrive.Driver_Cache_Type = Domain_Drive.Driver_Cache_Type;
                harddrive.Driver_Type = Domain_Drive.Driver_Type;
                harddrive.ReadOnly = Domain_Drive.ReadOnly;
                harddrive.Snapshot_Type = Domain_Drive.Snapshot_Type;
                harddrive.Letter = Domain_Drive.Letter;
                var source = new Libvirt.Models.Concrete.Device_Source_Volume();
                source.pool = Domain_Drive.Pool;
                source.volume = Domain_Drive.Volume;

                source.Source_Startup_Policy = Domain_Drive.Source_Startup_Policy;
                harddrive.Source = source;
                machine.Drives.Disks.RemoveAll(a => a.Letter == Domain_Drive.Letter);
                machine.Drives.Disks.Add(harddrive);
                virDomainDefineXML(machine, GetHost(Domain_Drive.Host));
            }
            vm.Domain_Drive = Domain_Drive;
            return PartialView(vm);
        }

        private void BuildBootOrder(Models.Domain_Bios_Down_VM BiosInfo, Libvirt.Models.Concrete.Virtual_Machine machine)
        {
            BiosInfo.BootOrder.Clear();
            if (machine.Drives.Disks.Any(a => a.Disk_Device_Type == Libvirt.Models.Concrete.Disk.Disk_Device_Types.cdrom))
            {
                BiosInfo.BootOrder.Add(new Models.BootOrder_VM
                {
                    Enabled = machine.BootLoader.BootOrder.Any(b => b == Libvirt.Models.Concrete.BIOS_Bootloader.Boot_Types.cdrom),
                    BootType = Libvirt.Models.Concrete.BIOS_Bootloader.Boot_Types.cdrom
                });
            }
            if (machine.Drives.Disks.Any(a => a.Disk_Device_Type == Libvirt.Models.Concrete.Disk.Disk_Device_Types.disk))
            {
                BiosInfo.BootOrder.Add(new Models.BootOrder_VM
                {
                    Enabled = machine.BootLoader.BootOrder.Any(b => b == Libvirt.Models.Concrete.BIOS_Bootloader.Boot_Types.hd),
                    BootType = Libvirt.Models.Concrete.BIOS_Bootloader.Boot_Types.hd
                });
            }
            BiosInfo.BootOrder.Add(new Models.BootOrder_VM
            {
                Enabled = machine.BootLoader.BootOrder.Any(b => b == Libvirt.Models.Concrete.BIOS_Bootloader.Boot_Types.network),
                BootType = Libvirt.Models.Concrete.BIOS_Bootloader.Boot_Types.network
            });
        }

        private void virDomainDefineXML(Libvirt.Models.Concrete.Virtual_Machine machine, Libvirt.CS_Objects.Host h)
        {
            if (ModelState.IsValid)
            {
                using (var newd = h.virDomainDefineXML(machine))
                {
                    Debug.WriteLine("virDomainDefineXML Called");
                }
            }
        }
    }
}