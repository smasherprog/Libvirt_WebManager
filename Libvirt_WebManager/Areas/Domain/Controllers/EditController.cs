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
        public ActionResult _Partial_Index(string host, string domain)
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult _Partial_Details_MainContent(string host, string domain)
        {
            using (var d = GetHost(host).virDomainLookupByName(domain))
            {
                var vm = new Models.Domain_Details_Down();
                var machine = d.virDomainGetXMLDesc(Libvirt.virDomainXMLFlags.VIR_DEFAULT);
                vm.MetaData = Utilities.AutoMapper.Mapper<Models.General_Metadata_VM>.Map(machine.Metadata);
                vm.type = machine.type;
                vm.MetaData.Host = host;
                vm.MetaData.Parent = domain;
                vm.Bios = machine.BootLoader;
                return PartialView(vm);
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




        [HttpGet]
        public ActionResult _Partial_CPU_MainContent(string host, string domain)
        {
            var h = GetHost(host);
            using (var d = h.virDomainLookupByName(domain))
            {
                var vm = new Models.Domain_CPU_Down();
                Libvirt._virNodeInfo info;
                h.virNodeGetInfo(out info);
                vm.NodeCpuInfo = info;
                var machine = d.virDomainGetXMLDesc(Libvirt.virDomainXMLFlags.VIR_DEFAULT);
                vm.CpuInfo = Utilities.AutoMapper.Mapper<Models.Domain_CPU_Down_VM>.Map(machine.CPU);
                vm.CpuInfo.Host = host;
                vm.CpuInfo.Parent = domain;
                return PartialView(vm);
            }
        }
        [HttpPost]
        public ActionResult _Partial_CPU_MainContent(Models.Domain_CPU_Down_VM CpuInfo)
        {
            var h = GetHost(CpuInfo.Host);
            using (var d = h.virDomainLookupByName(CpuInfo.Parent))
            {
                var validator = new Libvirt.Service.Concrete.CPU_Layout_Validator();
                var cpulayout= Utilities.AutoMapper.Mapper<Libvirt.Models.Concrete.CPU_Layout>.Map(CpuInfo);
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
    }
}