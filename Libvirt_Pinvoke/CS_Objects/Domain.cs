
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.CS_Objects
{
    public class Domain : IDisposable
    {
        private Libvirt.virDomainPtr _DomainPtr;
        public bool IsValid { get { return _DomainPtr.Pointer != IntPtr.Zero; } }
        public Domain(Libvirt.virDomainPtr ptr)
        {
            _DomainPtr = ptr;
        }

        public int virDomainAbortJob()
        {
            return API.virDomainAbortJob(_DomainPtr);
        }
        public int virDomainAddIOThread(uint iothread_id, virDomainModificationImpact flags)
        {
            return API.virDomainAddIOThread(_DomainPtr, iothread_id, flags);
        }
        public int virDomainAttachDevice(Libvirt.Models.Concrete.Device device)
        {
            return API.virDomainAttachDevice(_DomainPtr, device.To_XML());
        }
        public int virDomainAttachDeviceFlags(Libvirt.Models.Concrete.Device device, virDomainDeviceModifyFlags flags)
        {
            return API.virDomainAttachDeviceFlags(_DomainPtr, device.To_XML(), flags);
        }
        public int virDomainBlockCommit(string disk, string b, string top, uint bandwidth, virDomainBlockCommitFlags flags)
        {
            return API.virDomainBlockCommit(_DomainPtr, disk, b, top, bandwidth, flags);
        }
        public int virDomainBlockCopy(string disk, string destxml, virTypedParameterPtr pars, int nparams, virDomainBlockCopyFlags flags)
        {
            return API.virDomainBlockCopy(_DomainPtr, disk, destxml, pars, nparams, flags);
        }
        public int virDomainBlockJobAbort(string disk, virDomainBlockJobAbortFlags flags)
        {
            return API.virDomainBlockJobAbort(_DomainPtr, disk, flags);
        }
        public int virDomainBlockJobSetSpeed(string disk, uint bandwidth, virDomainBlockJobSetSpeedFlags flags)
        {
            return API.virDomainBlockJobSetSpeed(_DomainPtr, disk, bandwidth, flags);
        }
        public int virDomainBlockPeek(string disk, ulong offset, ulong size, byte[] buffer)
        {
            return API.virDomainBlockPeek(_DomainPtr, disk, offset, new UIntPtr(size), buffer);
        }
        public int virDomainBlockPull(string disk, uint bandwidth, virDomainBlockPullFlags flags)
        {
            return API.virDomainBlockPull(_DomainPtr, disk, bandwidth, flags);
        }
        public int virDomainBlockRebase(string disk, string b, uint bandwidth, virDomainBlockRebaseFlags flags)
        {
            return API.virDomainBlockRebase(_DomainPtr, disk, b, bandwidth, flags);
        }
        public int virDomainBlockResize(string disk, ulong size, virDomainBlockResizeFlags flags)
        {
            return API.virDomainBlockResize(_DomainPtr, disk, size, flags);
        }
        public int virDomainBlockStats(string disk, out _virDomainBlockStats stats)
        {
            stats = new _virDomainBlockStats();
            return API.virDomainBlockStats(_DomainPtr, disk, out stats, new UIntPtr(Convert.ToUInt32(Marshal.SizeOf(stats))));
        }
        public int virDomainBlockStatsFlags(string disk, out virTypedParameter[] pars, virTypedParameterFlags flags)
        {
            int count = 0;
            return API.virDomainBlockStatsFlags(_DomainPtr, disk, out pars, ref count, flags);
        }
        public int virDomainCoreDump(string to, virDomainCoreDumpFlags flags)
        {
            return API.virDomainCoreDump(_DomainPtr, to, flags);
        }
        public int virDomainCoreDumpWithFormat(string to, uint dumpformat, virDomainCoreDumpFlags flags)
        {
            return API.virDomainCoreDumpWithFormat(_DomainPtr, to, dumpformat, flags);
        }
        public int virDomainCreate()
        {
            return API.virDomainCreate(_DomainPtr);
        }
        public int virDomainCreateWithFiles(int[] files, virDomainCreateFlags flags)
        {
            return API.virDomainCreateWithFiles(_DomainPtr, Convert.ToUInt32(files.Length), files, flags);
        }
        public int virDomainCreateWithFlags(virDomainCreateFlags flags)
        {
            return API.virDomainCreateWithFlags(_DomainPtr, flags);
        }
        public int virDomainDelIOThread(uint iothread_id, virDomainModificationImpact flags)
        {
            return API.virDomainDelIOThread(_DomainPtr, iothread_id, flags);
        }
        public int virDomainDestroy()
        {
            return API.virDomainDestroy(_DomainPtr);
        }
        public int virDomainDestroyFlags(virDomainDestroyFlagsValues flags)
        {
            return API.virDomainDestroyFlags(_DomainPtr, flags);
        }
        public int virDomainDetachDevice(string xml)
        {
            return API.virDomainDetachDevice(_DomainPtr, xml);
        }

        public int virDomainDetachDeviceFlags(string xml, virDomainDeviceModifyFlags flags)
        {
            return API.virDomainDetachDeviceFlags(_DomainPtr, xml, flags);
        }
        public int virDomainFSFreeze(string[] mountpoints)
        {
            return API.virDomainFSFreeze(_DomainPtr, mountpoints, Convert.ToUInt32(mountpoints.Length));
        }
        public int virDomainFSThaw(string[] mountpoints)
        {
            return API.virDomainFSThaw(_DomainPtr, mountpoints, Convert.ToUInt32(mountpoints.Length));
        }
        public int virDomainFSTrim(string mountPoint, ulong minimum)
        {
            return API.virDomainFSTrim(_DomainPtr, mountPoint, minimum);
        }
        public int virDomainGetAutostart(ref int autostart)
        {
            return API.virDomainGetAutostart(_DomainPtr, ref autostart);
        }

        public int virDomainGetBlkioParameters(out virTypedParameter[] pars, uint flags)
        {
            int count = 0;
            return API.virDomainGetBlkioParameters(_DomainPtr, out pars, ref count, flags);
        }
        public int virDomainGetBlockInfo(string disk, out _virDomainBlockInfo info)
        {
            return API.virDomainGetBlockInfo(_DomainPtr, disk, out info);
        }
        public int virDomainGetBlockIoTune(string disk, out virTypedParameter[] pars, uint flags)
        {
            int count = 0;
            return API.virDomainGetBlockIoTune(_DomainPtr, disk, out pars, ref count, flags);
        }
        public int virDomainGetBlockJobInfo(string disk, out  _virDomainBlockJobInfo info, virDomainBlockJobInfoFlags flags)
        {
            return API.virDomainGetBlockJobInfo(_DomainPtr, disk, out info, flags);
        }

        public int virDomainGetCPUStats(out virTypedParameter[] pars, uint nparams, int start_cpu, uint ncpus, virTypedParameterFlags flags)
        {
            return API.virDomainGetCPUStats(_DomainPtr, out pars, nparams, start_cpu, ncpus, flags);
        }
        public int virDomainGetControlInfo(out _virDomainControlInfo info)
        {
            return API.virDomainGetControlInfo(_DomainPtr, out info);
        }

        public int virDomainGetDiskErrors(out virDomainDiskError[] errors, uint maxerrors)
        {
            return API.virDomainGetDiskErrors(_DomainPtr, out errors, maxerrors);
        }
        public int virDomainGetEmulatorPinInfo(out byte[] cpumap, int maplen, virDomainModificationImpact flags)
        {
            return API.virDomainGetEmulatorPinInfo(_DomainPtr, out cpumap, maplen, flags);
        }
        public int virDomainGetFSInfo(out _virDomainFSInfo[] info, uint flags = 0)
        {
            return API.virDomainGetFSInfo(_DomainPtr, out info, flags);
        }
        public string virDomainGetHostname()
        {
            return API.virDomainGetHostname(_DomainPtr);
        }
        public uint virDomainGetID()
        {
            return API.virDomainGetID(_DomainPtr);
        }

        public int virDomainGetIOThreadInfo(out _virDomainIOThreadInfo[] info, virDomainModificationImpact flags)
        {
            return API.virDomainGetIOThreadInfo(_DomainPtr, out info, flags);
        }
        public int virDomainGetInfo(out _virDomainInfo info)
        {
            return API.virDomainGetInfo(_DomainPtr, out info);
        }
        public int virDomainGetInterfaceParameters(string device, out virTypedParameter[] pars, int nparams, uint flags)
        {
            return API.virDomainGetInterfaceParameters(_DomainPtr, device, out pars, ref nparams, flags);
        }
        public int virDomainGetJobInfo(out _virDomainJobInfo info)
        {
            return API.virDomainGetJobInfo(_DomainPtr, out info);
        }
        public int virDomainGetJobStats(virDomainJobType type, out virTypedParameter[] pars, int nparams, virDomainGetJobStatsFlags flags)
        {
            return API.virDomainGetJobStats(_DomainPtr, type, out  pars, ref nparams, flags);
        }
        public uint virDomainGetMaxMemory()
        {
            return API.virDomainGetMaxMemory(_DomainPtr);
        }
        public int virDomainGetMaxVcpus()
        {
            return API.virDomainGetMaxVcpus(_DomainPtr);
        }
        public int virDomainGetMemoryParameters(out virTypedParameter[] pars, uint flags)
        {
            int count = 0;
            return API.virDomainGetMemoryParameters(_DomainPtr, out pars, ref count, flags);
        }

        public string virDomainGetMetadata(virDomainMetadataType type, string uri, virDomainModificationImpact flags)
        {
            return API.virDomainGetMetadata(_DomainPtr, type, uri, flags);
        }
        public string virDomainGetName()
        {
            return API.virDomainGetName(_DomainPtr);
        }
        public int virDomainGetNumaParameters(out virTypedParameter[] pars, uint flags)
        {
            int count = 0;
            return API.virDomainGetNumaParameters(_DomainPtr, out pars, ref count, flags);
        }
        public string virDomainGetOSType()
        {
            return API.virDomainGetOSType(_DomainPtr);
        }
        public int virDomainGetSchedulerParameters(out virTypedParameter[] pars, int nparams)
        {
            return API.virDomainGetSchedulerParameters(_DomainPtr, out pars, ref nparams);
        }
        public int virDomainGetSchedulerParametersFlags(out virTypedParameter[] pars, int nparams, uint flags)
        {
            return API.virDomainGetSchedulerParametersFlags(_DomainPtr, out pars, ref nparams, flags);
        }
        public string virDomainGetSchedulerType(ref int nparams)
        {
            return API.virDomainGetSchedulerType(_DomainPtr, ref nparams);
        }
        public int virDomainGetSecurityLabel(out _virSecurityLabel seclabel)
        {
            return API.virDomainGetSecurityLabel(_DomainPtr, out seclabel);
        }
        public int virDomainGetState(out virDomainState state, out int reason)
        {
            return API.virDomainGetState(_DomainPtr, out state, out reason);
        }
        public int virDomainGetTime(out long seconds, out uint nseconds)
        {
            return API.virDomainGetTime(_DomainPtr, out seconds, out nseconds);
        }
        public int virDomainGetUUID(out byte[] uuid)
        {
            return API.virDomainGetUUID(_DomainPtr, out uuid);
        }
        public int virDomainGetUUIDString(out string buf)
        {
            return API.virDomainGetUUIDString(_DomainPtr, out buf);
        }

        public int virDomainGetVcpuPinInfo(int ncpumaps, out byte[] cpumaps, int maplen, uint flags)
        {
            return API.virDomainGetVcpuPinInfo(_DomainPtr, ncpumaps, out cpumaps, maplen, flags);
        }
        public int virDomainGetVcpus(out _virVcpuInfo[] info, int maxinfo, out byte[] cpumaps, int maplen)
        {
            return API.virDomainGetVcpus(_DomainPtr, out info, maxinfo, out cpumaps, maplen);
        }
        public int virDomainGetVcpusFlags(virDomainVcpuFlags flags)
        {
            return API.virDomainGetVcpusFlags(_DomainPtr, flags);
        }
        public string virDomainGetXMLDesc(virDomainXMLFlags flags)
        {
            return API.virDomainGetXMLDesc(_DomainPtr, flags);
        }
        public int virDomainHasManagedSaveImage()
        {
            return API.virDomainHasManagedSaveImage(_DomainPtr);
        }
        public int virDomainInjectNMI()
        {
            return API.virDomainInjectNMI(_DomainPtr);
        }
        private static _virDomainInterfaceStats _Dummy_virDomainInterfaceStats = new _virDomainInterfaceStats();
        public int virDomainInterfaceStats(string path, out _virDomainInterfaceStats stats)
        {
            return API.virDomainInterfaceStats(_DomainPtr, path, out stats, new UIntPtr(Convert.ToUInt32(Marshal.SizeOf(_Dummy_virDomainInterfaceStats))));
        }
        public int virDomainIsActive()
        {
            return API.virDomainIsActive(_DomainPtr);
        }
        public int virDomainIsPersistent()
        {
            return API.virDomainIsPersistent(_DomainPtr);
        }
        public int virDomainIsUpdated()
        {
            return API.virDomainIsUpdated(_DomainPtr);
        }
        public static int virDomainListGetStats(virDomainPtr[] doms, virDomainStatsTypes stats, out _virDomainStatsRecord[,] retStats, virConnectGetAllDomainStatsFlags flags)
        {
            return API.virDomainListGetStats(doms, stats, out retStats, flags);
        }
        public int virDomainManagedSave(virDomainSaveRestoreFlags flags)
        {
            return API.virDomainManagedSave(_DomainPtr, flags);
        }
        public int virDomainManagedSaveRemove()
        {
            return API.virDomainManagedSaveRemove(_DomainPtr);
        }
        public int virDomainMemoryPeek(ulong start, byte[] buffer, virDomainMemoryFlags flags)
        {
            return API.virDomainMemoryPeek(_DomainPtr, start, new UIntPtr(Convert.ToUInt32(buffer.Length)), buffer, flags);
        }
        public int virDomainMemoryStats(out _virDomainMemoryStat[] stats, uint nr_stats)
        {
            return API.virDomainMemoryStats(_DomainPtr, out stats, nr_stats);
        }
        public Domain virDomainMigrate(Host destination_host, virDomainMigrateFlags flags, string dst_vm_name, string uri, uint bandwidth)
        {
            return new Domain(API.virDomainMigrate(_DomainPtr, Host.GetPtr(destination_host), flags, dst_vm_name, uri, bandwidth));
        }
        public Domain virDomainMigrate2(Host destination_host, string dxml, virDomainMigrateFlags flags, string dst_vm_name, string uri, uint bandwidth)
        {
            return new Domain(API.virDomainMigrate2(_DomainPtr, Host.GetPtr(destination_host), dxml, flags, dst_vm_name, uri, bandwidth));
        }
        public Domain virDomainMigrate3(Host destination_host, _virTypedParameter[] pars, virDomainMigrateFlags flags)
        {
            return new Domain(API.virDomainMigrate3(_DomainPtr, Host.GetPtr(destination_host), pars, Convert.ToUInt32(pars.Length), flags));
        }
        public int virDomainMigrateGetCompressionCache(out ulong cacheSize)
        {
            return API.virDomainMigrateGetCompressionCache(_DomainPtr, out cacheSize);
        }
        public int virDomainMigrateGetMaxSpeed(out uint bandwidth)
        {
            return API.virDomainMigrateGetMaxSpeed(_DomainPtr, out bandwidth);
        }
        public int virDomainMigrateSetCompressionCache(uint cacheSize)
        {
            return API.virDomainMigrateSetCompressionCache(_DomainPtr, cacheSize);
        }
        public int virDomainMigrateSetMaxDowntime(ulong downtime)
        {
            return API.virDomainMigrateSetMaxDowntime(_DomainPtr, downtime);
        }
        public int virDomainMigrateSetMaxSpeed(uint bandwidth)
        {
            return API.virDomainMigrateSetMaxSpeed(_DomainPtr, bandwidth);
        }

        public int virDomainMigrateToURI(string duri, virDomainMigrateFlags flags, string dname, uint bandwidth)
        {
            return API.virDomainMigrateToURI(_DomainPtr, duri, flags, dname, bandwidth);
        }
        public int virDomainMigrateToURI2(string dconnuri, string miguri, string dxml, virDomainMigrateFlags flags, string dname, uint bandwidth)
        {
            return API.virDomainMigrateToURI2(_DomainPtr, dconnuri, miguri, dxml, flags, dname, bandwidth);
        }
        public int virDomainMigrateToURI3(string dconnuri, virTypedParameterPtr[] pars, virDomainMigrateFlags flags)
        {
            return API.virDomainMigrateToURI3(_DomainPtr, dconnuri, pars, Convert.ToUInt32(pars.Length), flags);
        }

        public int virDomainOpenChannel(string name, Stream st, virDomainChannelFlags flags)
        {
            return API.virDomainOpenChannel(_DomainPtr, name, Stream.GetPtr(st), flags);
        }
        public int virDomainOpenConsole(string dev_name, Stream st, virDomainConsoleFlags flags)
        {
            return API.virDomainOpenConsole(_DomainPtr, dev_name, Stream.GetPtr(st), flags);
        }
        public int virDomainOpenGraphics(uint idx, int fd, virDomainOpenGraphicsFlags flags)
        {
            return API.virDomainOpenGraphics(_DomainPtr, idx, fd, flags);
        }
        public int virDomainOpenGraphicsFD(uint idx, virDomainOpenGraphicsFlags flags)
        {
            return API.virDomainOpenGraphicsFD(_DomainPtr, idx, flags);
        }

        public int virDomainPMSuspendForDuration(virNodeSuspendTarget target, ulong duration)
        {
            return API.virDomainPMSuspendForDuration(_DomainPtr, target, duration);
        }
        public int virDomainPMWakeup()
        {
            return API.virDomainPMWakeup(_DomainPtr);
        }
        public int virDomainPinEmulator(out byte[] cpumap, int maplen, virDomainModificationImpact flags)
        {
            return API.virDomainPinEmulator(_DomainPtr, out  cpumap, maplen, flags);
        }
        public int virDomainPinIOThread(uint iothread_id, out byte[] cpumap, int maplen, virDomainModificationImpact flags)
        {
            return API.virDomainPinIOThread(_DomainPtr, iothread_id, out  cpumap, maplen, flags);
        }
        public int virDomainPinVcpu(uint vcpu, out byte[] cpumap, int maplen)
        {
            return API.virDomainPinVcpu(_DomainPtr, vcpu, out cpumap, maplen);
        }
        public int virDomainPinVcpuFlags(uint vcpu, out byte[] cpumap, int maplen, virDomainModificationImpact flags)
        {
            return API.virDomainPinVcpuFlags(_DomainPtr, vcpu, out cpumap, maplen, flags);
        }

        public int virDomainReboot(virDomainRebootFlagValues flags)
        {
            return API.virDomainReboot(_DomainPtr, flags);
        }
        public int virDomainReset()
        {
            return API.virDomainReset(_DomainPtr);
        }
        public int virDomainResume()
        {
            return API.virDomainResume(_DomainPtr);
        }

        public int virDomainSave(string to)
        {
            return API.virDomainSave(_DomainPtr, to);
        }

        public int virDomainSaveFlags(string to, string dxml, virDomainSaveRestoreFlags flags)
        {
            return API.virDomainSaveFlags(_DomainPtr, to, dxml, flags);
        }

        public string virDomainScreenshot(Stream stream, uint screen)
        {
            return API.virDomainScreenshot(_DomainPtr, Stream.GetPtr(stream), screen);
        }
        public int virDomainSendKey(virKeycodeSet codeset, uint holdtime, uint[] keycodes, int nkeycodes)
        {
            return API.virDomainSendKey(_DomainPtr, codeset, holdtime, keycodes, nkeycodes);
        }

        public int virDomainSendProcessSignal(long pid_value, uint signum, virDomainProcessSignal flags)
        {
            return API.virDomainSendProcessSignal(_DomainPtr, pid_value, signum, flags);
        }

        public int virDomainSetAutostart(int autostart)
        {
            return API.virDomainSetAutostart(_DomainPtr, autostart);
        }
        public int virDomainSetBlkioParameters(virTypedParameter[] pars, virDomainModificationImpact flags)
        {
            return API.virDomainSetBlkioParameters(_DomainPtr, pars, pars.Length, flags);
        }
        public int virDomainSetBlockIoTune(string disk, virTypedParameter[] pars, virDomainModificationImpact flags)
        {
            return API.virDomainSetBlockIoTune(_DomainPtr, disk, pars, pars.Length, flags);
        }
        public int virDomainSetInterfaceParameters(string device, virTypedParameter[] pars, virDomainModificationImpact flags)
        {
            return API.virDomainSetInterfaceParameters(_DomainPtr, device, pars, pars.Length, flags);
        }


        public int virDomainSetMaxMemory(uint memory)
        {
            return API.virDomainSetMaxMemory(_DomainPtr, memory);
        }
        public int virDomainSetMemory(uint memory)
        {
            return API.virDomainSetMemory(_DomainPtr, memory);
        }
        public int virDomainSetMemoryFlags(uint memory, virDomainMemoryModFlags flags)
        {
            return API.virDomainSetMemoryFlags(_DomainPtr, memory, flags);
        }
        public int virDomainSetMemoryParameters(virTypedParameter[] pars, int nparams, virDomainModificationImpact flags)
        {
            return API.virDomainSetMemoryParameters(_DomainPtr, pars, nparams, flags);
        }
        public int virDomainSetMemoryStatsPeriod(int period, virDomainMemoryModFlags flags)
        {
            return API.virDomainSetMemoryStatsPeriod(_DomainPtr, period, flags);
        }
        public int virDomainSetMetadata(virDomainMetadataType type, string metadata, string key, string uri, virDomainModificationImpact flags)
        {
            return API.virDomainSetMetadata(_DomainPtr, type, metadata, key, uri, flags);
        }
        public int virDomainSetNumaParameters(virTypedParameter[] pars, virDomainModificationImpact flags)
        {
            return API.virDomainSetNumaParameters(_DomainPtr, pars, pars.Length, flags);
        }

        public int virDomainSetSchedulerParameters(virTypedParameter[] pars)
        {
            return API.virDomainSetSchedulerParameters(_DomainPtr, pars, pars.Length);
        }
        public int virDomainSetSchedulerParametersFlags(virTypedParameter[] pars, virDomainModificationImpact flags)
        {
            return API.virDomainSetSchedulerParametersFlags(_DomainPtr, pars, pars.Length, flags);
        }

        public int virDomainSetTime(long seconds, uint nseconds, virDomainSetTimeFlags flags)
        {
            return API.virDomainSetTime(_DomainPtr, seconds, nseconds, flags);
        }

        public int virDomainSetUserPassword(string user, string password, virDomainSetUserPasswordFlags flags)
        {
            return API.virDomainSetUserPassword(_DomainPtr, user, password, flags);
        }

        public int virDomainSetVcpus(uint nvcpus)
        {
            return API.virDomainSetVcpus(_DomainPtr, nvcpus);
        }
        public int virDomainSetVcpusFlags(uint nvcpus, virDomainVcpuFlags flags)
        {
            return API.virDomainSetVcpusFlags(_DomainPtr, nvcpus, flags);
        }
        public int virDomainShutdown()
        {
            return API.virDomainShutdown(_DomainPtr);
        }

        public int virDomainShutdownFlags(virDomainShutdownFlagValues flags)
        {
            return API.virDomainShutdownFlags(_DomainPtr, flags);
        }

        public int virDomainSuspend()
        {
            return API.virDomainSuspend(_DomainPtr);
        }
        public int virDomainUndefine()
        {
            return API.virDomainUndefine(_DomainPtr);
        }
        public int virDomainUndefineFlags(virDomainUndefineFlagsValues flags)
        {
            return API.virDomainUndefineFlags(_DomainPtr, flags);
        }
        public int virDomainUpdateDeviceFlags(string xml, virDomainDeviceModifyFlags flags)
        {
            return API.virDomainUpdateDeviceFlags(_DomainPtr, xml, flags);
        }


        public static Libvirt.virDomainPtr GetPtr(Domain p)
        {
        
            return p._DomainPtr;
        }
        public void Dispose()
        {
            _DomainPtr.Dispose();
        }

    }
}
