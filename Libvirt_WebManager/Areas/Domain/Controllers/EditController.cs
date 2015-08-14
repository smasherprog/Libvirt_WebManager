using System.Diagnostics;
using System.Web.Mvc;

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
            var h = GetHost(host);
            using (var d = h.virDomainLookupByName(domain))
            {
                Libvirt._virNodeInfo info;
                h.virNodeGetInfo(out info);
                return PartialView(new Libvirt_WebManager.Areas.Domain.Models.BaseDomain_Down
                {
                    Host = host,
                    Parent = domain,
                    Machine = d.virDomainGetXMLDesc(Libvirt.virDomainXMLFlags.VIR_DEFAULT),
                    NodeInfo = info
                });
            }

        }

        [HttpPost]
        public ActionResult _Partial_Details_MainContent(Models.General_Metadata_VM MetaData)
        {
            var vm = new Models.Domain_Details_Down();
            Libvirt.Models.Concrete.Virtual_Machine machine = new Libvirt.Models.Concrete.Virtual_Machine();
            if (ModelState.IsValid)
            {
                var h = GetHost(MetaData.Host);
                using (var d = h.virDomainLookupByName(MetaData.Parent))
                {
                    machine = d.virDomainGetXMLDesc(Libvirt.virDomainXMLFlags.VIR_DEFAULT);
                    machine.Metadata = Utilities.AutoMapper.Mapper<Libvirt.Models.Concrete.General_Metadata>.Map(MetaData);
                    using (var newd = h.virDomainDefineXML(machine))
                    {
                        Debug.WriteLine("got here");
                    }
                }
            }
            vm.type = machine.type;
            vm.MetaData = Utilities.AutoMapper.Mapper<Models.General_Metadata_VM>.Map(machine.Metadata);
            vm.MetaData.Host = MetaData.Host;
            vm.MetaData.Parent = MetaData.Parent;
            vm.Bios = machine.BootLoader;
            return PartialView(vm);

        }


        [HttpPost]
        public ActionResult _Partial_CPU_MainContent(Models.Domain_CPU_Down_VM CpuInfo)
        {
            var h = GetHost(CpuInfo.Host);
            using (var d = h.virDomainLookupByName(CpuInfo.Parent))
            {
                var validator = new Libvirt.Service.Concrete.CPU_Layout_Validator();
                var cpulayout = Utilities.AutoMapper.Mapper<Libvirt.Models.Concrete.CPU_Layout>.Map(CpuInfo);
                validator.Validate(new Libvirt_WebManager.Models.Validator(ModelState), cpulayout, h);
                var machine = d.virDomainGetXMLDesc(Libvirt.virDomainXMLFlags.VIR_DEFAULT);
                if (ModelState.IsValid)
                {
                    machine.CPU = cpulayout;
                    using (var newd = h.virDomainDefineXML(machine))
                    {
                        Debug.WriteLine("got here");
                    }
                }
                var vm = new Models.Domain_CPU_Down();
                Libvirt._virNodeInfo info;
                h.virNodeGetInfo(out info);
                vm.NodeCpuInfo = info;
                vm.CpuInfo = CpuInfo;
                return PartialView(vm);
            }

        }
        [HttpPost]
        public ActionResult _Partial_Memory_MainContent(Models.Domain_Memory_Down_VM MemoryInfo)
        {

            var h = GetHost(MemoryInfo.Host);
            using (var d = h.virDomainLookupByName(MemoryInfo.Parent))
            {
                var validator = new Libvirt.Service.Concrete.Memory_Allocation_Validator();
                var memorylayout = Utilities.AutoMapper.Mapper<Libvirt.Models.Concrete.Memory_Allocation>.Map(MemoryInfo);
                memorylayout.memory_unit= memorylayout.currentMemory_unit = Libvirt.Models.Concrete.Memory_Allocation.UnitTypes.MiB;
                validator.Validate(new Libvirt_WebManager.Models.Validator(ModelState), memorylayout, h);
                var machine = d.virDomainGetXMLDesc(Libvirt.virDomainXMLFlags.VIR_DEFAULT);
                if (ModelState.IsValid)
                {
                    machine.Memory = memorylayout;
                    using (var newd = h.virDomainDefineXML(machine))
                    {
                        Debug.WriteLine("got here");
                    }
                }
                var vm = new Models.Domain_Memory_Down();
                Libvirt._virNodeInfo info;
                h.virNodeGetInfo(out info);
                vm.NodeCpuInfo = info;
                vm.MemoryInfo.Host = MemoryInfo.Host;
                vm.MemoryInfo.Parent = MemoryInfo.Parent;
                vm.MemoryInfo.currentMemory = vm.MemoryInfo.currentMemory > 0 ? vm.MemoryInfo.currentMemory / 1024 : 0;
                vm.MemoryInfo.memory = vm.MemoryInfo.memory > 0 ? vm.MemoryInfo.memory / 1024 : 0;
                return PartialView(vm);
            }

        }
    }
}