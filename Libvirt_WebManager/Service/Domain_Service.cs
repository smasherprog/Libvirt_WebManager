using Libvirt_Pinvoke.CS_Objects.Extensions;
using System.Diagnostics;

namespace Libvirt_WebManager.Service
{
    public class Domain_Service : Interface.IService
    {
        public Domain_Service(Libvirt.Models.Interface.IValdiator v) : base(v) { }

        public void CreateDomain(ViewModels.Domain.New_Domain_VM v)
        {
            var h = GetHost(v.Host);
            Libvirt.Models.Concrete.Virtual_Machine virtuammachine = new Libvirt.Models.Concrete.Virtual_Machine();
            virtuammachine.CPU.vCpu_Count = v.Cpus;
            virtuammachine.type = Libvirt.Models.Concrete.Virtual_Machine.Domain_Types.qemu;
            virtuammachine.Metadata.name = v.Name;
            virtuammachine.Memory.memory_unit = virtuammachine.Memory.currentMemory_unit = Libvirt.Models.Concrete.Memory_Allocation.UnitTypes.MiB;
            virtuammachine.Memory.currentMemory = virtuammachine.Memory.memory = v.Ram;
         

            //Add a hard drive
            var harddrive = new Libvirt.Models.Concrete.Device();
            harddrive.Device_Bus_Type = Libvirt.Models.Concrete.Device.Device_Bus_Types.virtio;
            harddrive.Device_Device_Type = Libvirt.Models.Concrete.Device.Device_Device_Types.disk;
            harddrive.Device_Type = Libvirt.Models.Concrete.Device.Device_Types.volume;
            harddrive.Driver_Cache_Type = Libvirt.Models.Concrete.Device.Driver_Cache_Types._default;
            harddrive.Driver_Type = Libvirt.Models.Concrete.Device.Driver_Types.raw;
            harddrive.ReadOnly = false;
            harddrive.Snapshot_Type = Libvirt.Models.Concrete.Device.Snapshot_Types._default;
            var source = new Libvirt.Models.Concrete.Device_Source_Volume();
            source.pool = v.HD_Pool;
            source.volume = v.HD_Volume;
            source.Source_Startup_Policy = Libvirt.Models.Concrete.Device.Source_Startup_Policies.mandatory;
            harddrive.Source = source;
            virtuammachine.Devices.Add(harddrive);

            var oscdrom = new Libvirt.Models.Concrete.Device();
            oscdrom.Device_Bus_Type = Libvirt.Models.Concrete.Device.Device_Bus_Types.virtio;
            oscdrom.Device_Device_Type = Libvirt.Models.Concrete.Device.Device_Device_Types.cdrom;
            oscdrom.Device_Type = Libvirt.Models.Concrete.Device.Device_Types.volume;
            oscdrom.Driver_Cache_Type = Libvirt.Models.Concrete.Device.Driver_Cache_Types._default;
            oscdrom.Driver_Type = Libvirt.Models.Concrete.Device.Driver_Types.raw;
            oscdrom.ReadOnly = true;
            oscdrom.Snapshot_Type = Libvirt.Models.Concrete.Device.Snapshot_Types._default;
            var cdsource = new Libvirt.Models.Concrete.Device_Source_Volume();
            cdsource.pool = v.OS_Pool;
            cdsource.volume = v.OS_Volume;
            cdsource.Source_Startup_Policy = Libvirt.Models.Concrete.Device.Source_Startup_Policies.optional;
            oscdrom.Source = cdsource;
            virtuammachine.Devices.Add(oscdrom);
            var testxml = virtuammachine.To_XML();
            using (var domain = h.virDomainDefineXML(virtuammachine))
            {
                if (domain.IsValid)
                {
                    if (domain.virDomainCreate() == 0)
                    {
                        Debug.WriteLine("Successfully created and started the new VM!");
                    }
                    else
                    {
                        Debug.WriteLine("Successfully created the VM, but was unable to start it. Check the error logs");
                    }

                }
                else
                {
                    Debug.WriteLine("Unable to create the VM, please check the error logs!");
                }
            }
        }
    }
}