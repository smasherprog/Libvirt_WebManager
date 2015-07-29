namespace Libvirt
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;


    public enum virErrorLevel : uint
    {
        VIR_ERR_NONE = 0,
        VIR_ERR_WARNING = 1,	/* A simple warning */
        VIR_ERR_ERROR = 2		/* An error */
    };
    public enum virErrorDomain : uint
    {
        VIR_FROM_NONE = 0,
        VIR_FROM_XEN = 1,		/* Error at Xen hypervisor layer */
        VIR_FROM_XEND = 2,		/* Error at connection with xend daemon */
        VIR_FROM_XENSTORE = 3,	/* Error at connection with xen store */
        VIR_FROM_SEXPR = 4,		/* Error in the S-Expression code */

        VIR_FROM_XML = 5,		/* Error in the XML code */
        VIR_FROM_DOM = 6,		/* Error when operating on a domain */
        VIR_FROM_RPC = 7,		/* Error in the XML-RPC code */
        VIR_FROM_PROXY = 8,		/* Error in the proxy code; unused since
                                   0.8.6 */
        VIR_FROM_CONF = 9,		/* Error in the configuration file handling */

        VIR_FROM_QEMU = 10,		/* Error at the QEMU daemon */
        VIR_FROM_NET = 11,		/* Error when operating on a network */
        VIR_FROM_TEST = 12,		/* Error from test driver */
        VIR_FROM_REMOTE = 13,	/* Error from remote driver */
        VIR_FROM_OPENVZ = 14,	/* Error from OpenVZ driver */

        VIR_FROM_XENXM = 15,	/* Error at Xen XM layer */
        VIR_FROM_STATS_LINUX = 16,	/* Error in the Linux Stats code */
        VIR_FROM_LXC = 17,		/* Error from Linux Container driver */
        VIR_FROM_STORAGE = 18,	/* Error from storage driver */
        VIR_FROM_NETWORK = 19,	/* Error from network config */

        VIR_FROM_DOMAIN = 20,	/* Error from domain config */
        VIR_FROM_UML = 21,		/* Error at the UML driver */
        VIR_FROM_NODEDEV = 22,	/* Error from node device monitor */
        VIR_FROM_XEN_INOTIFY = 23,	/* Error from xen inotify layer */
        VIR_FROM_SECURITY = 24,	/* Error from security framework */

        VIR_FROM_VBOX = 25,		/* Error from VirtualBox driver */
        VIR_FROM_INTERFACE = 26,	/* Error when operating on an interface */
        VIR_FROM_ONE = 27,		/* The OpenNebula driver no longer exists.
                                   Retained for ABI/API compat only */
        VIR_FROM_ESX = 28,		/* Error from ESX driver */
        VIR_FROM_PHYP = 29,		/* Error from IBM power hypervisor */

        VIR_FROM_SECRET = 30,	/* Error from secret storage */
        VIR_FROM_CPU = 31,		/* Error from CPU driver */
        VIR_FROM_XENAPI = 32,	/* Error from XenAPI */
        VIR_FROM_NWFILTER = 33,	/* Error from network filter driver */
        VIR_FROM_HOOK = 34,		/* Error from Synchronous hooks */

        VIR_FROM_DOMAIN_SNAPSHOT = 35,/* Error from domain snapshot */
        VIR_FROM_AUDIT = 36,	/* Error from auditing subsystem */
        VIR_FROM_SYSINFO = 37,	/* Error from sysinfo/SMBIOS */
        VIR_FROM_STREAMS = 38,	/* Error from I/O streams */
        VIR_FROM_VMWARE = 39,	/* Error from VMware driver */

        VIR_FROM_EVENT = 40,	/* Error from event loop impl */
        VIR_FROM_LIBXL = 41,	/* Error from libxenlight driver */
        VIR_FROM_LOCKING = 42,	/* Error from lock manager */
        VIR_FROM_HYPERV = 43,	/* Error from Hyper-V driver */
        VIR_FROM_CAPABILITIES = 44, /* Error from capabilities */

        VIR_FROM_URI = 45,          /* Error from URI handling */
        VIR_FROM_AUTH = 46,         /* Error from auth handling */
        VIR_FROM_DBUS = 47,         /* Error from DBus */
        VIR_FROM_PARALLELS = 48,    /* Error from Parallels */
        VIR_FROM_DEVICE = 49,       /* Error from Device */

        VIR_FROM_SSH = 50,          /* Error from libssh2 connection transport */
        VIR_FROM_LOCKSPACE = 51,    /* Error from lockspace */
        VIR_FROM_INITCTL = 52,      /* Error from initctl device communication */
        VIR_FROM_IDENTITY = 53,     /* Error from identity code */
        VIR_FROM_CGROUP = 54,       /* Error from cgroups */

        VIR_FROM_ACCESS = 55,       /* Error from access control manager */
        VIR_FROM_SYSTEMD = 56,      /* Error from systemd code */
        VIR_FROM_BHYVE = 57,        /* Error from bhyve driver */
        VIR_FROM_CRYPTO = 58,       /* Error from crypto code */
        VIR_FROM_FIREWALL = 59,     /* Error from firewall */

        VIR_FROM_POLKIT = 60,       /* Error from polkit code */
        VIR_FROM_THREAD = 61,       /* Error from thread utils */


    };

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct virErrorPtr
    {

        public virErrorPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virError
    {
        public int code;	/* The error code, a virErrorNumber */
        public virErrorDomain domain;	/* What part of the library raised this error */

        public IntPtr message;/* human-readable informative error message */
        public virErrorLevel level;/* how consequent is the error */
        public IntPtr conn; /* DEPRECIATED DO NOT USE */
        public IntPtr dom; /* DEPRECIATED DO NOT USE */

        public IntPtr str1;	/* extra string information */
        public IntPtr str2;	/* extra string information */
        public IntPtr str3;	/* extra string information */
        public int int1;	/* extra number information */
        public int int2;	/* extra number information */
        public IntPtr net; /* network if available, deprecated see note above */
    };
    public struct virError
    {
        public int code;	/* The error code, a virErrorNumber */
        public virErrorDomain domain;	/* What part of the library raised this error */
        public string message;/* human-readable informative error message */
        public virErrorLevel level;/* how consequent is the error */
        public string str1;	/* extra string information */
        public string str2;	/* extra string information */
        public string str3;	/* extra string information */
        public int int1;	/* extra number information */
        public int int2;	/* extra number information */
    };
    public enum virErrorNumber : uint
    {

        VIR_ERR_OK = 0,
        VIR_ERR_INTERNAL_ERROR = 1,		/* internal error */
        VIR_ERR_NO_MEMORY = 2,		/* memory allocation failure */
        VIR_ERR_NO_SUPPORT = 3,		/* no support for this function */
        VIR_ERR_UNKNOWN_HOST = 4,		/* could not resolve hostname */
        VIR_ERR_NO_CONNECT = 5,		/* can't connect to hypervisor */
        VIR_ERR_INVALID_CONN = 6,		/* invalid connection object */
        VIR_ERR_INVALID_DOMAIN = 7,		/* invalid domain object */
        VIR_ERR_INVALID_ARG = 8,		/* invalid function argument */
        VIR_ERR_OPERATION_FAILED = 9,	/* a command to hypervisor failed */
        VIR_ERR_GET_FAILED = 10,		/* a HTTP GET command to failed */
        VIR_ERR_POST_FAILED = 11,		/* a HTTP POST command to failed */
        VIR_ERR_HTTP_ERROR = 12,		/* unexpected HTTP error code */
        VIR_ERR_SEXPR_SERIAL = 13,		/* failure to serialize an S-Expr */
        VIR_ERR_NO_XEN = 14,		/* could not open Xen hypervisor
                                           control */
        VIR_ERR_XEN_CALL = 15,		/* failure doing an hypervisor call */
        VIR_ERR_OS_TYPE = 16,		/* unknown OS type */
        VIR_ERR_NO_KERNEL = 17,		/* missing kernel information */
        VIR_ERR_NO_ROOT = 18,		/* missing root device information */
        VIR_ERR_NO_SOURCE = 19,		/* missing source device information */
        VIR_ERR_NO_TARGET = 20,		/* missing target device information */
        VIR_ERR_NO_NAME = 21,		/* missing domain name information */
        VIR_ERR_NO_OS = 22,			/* missing domain OS information */
        VIR_ERR_NO_DEVICE = 23,		/* missing domain devices information */
        VIR_ERR_NO_XENSTORE = 24,		/* could not open Xen Store control */
        VIR_ERR_DRIVER_FULL = 25,		/* too many drivers registered */
        VIR_ERR_CALL_FAILED = 26,		/* not supported by the drivers
                                           (DEPRECATED) */
        VIR_ERR_XML_ERROR = 27,		/* an XML description is not well
                                           formed or broken */
        VIR_ERR_DOM_EXIST = 28,		/* the domain already exist */
        VIR_ERR_OPERATION_DENIED = 29,	/* operation forbidden on read-only
                                           connections */
        VIR_ERR_OPEN_FAILED = 30,		/* failed to open a conf file */
        VIR_ERR_READ_FAILED = 31,		/* failed to read a conf file */
        VIR_ERR_PARSE_FAILED = 32,		/* failed to parse a conf file */
        VIR_ERR_CONF_SYNTAX = 33,		/* failed to parse the syntax of a
                                           conf file */
        VIR_ERR_WRITE_FAILED = 34,		/* failed to write a conf file */
        VIR_ERR_XML_DETAIL = 35,		/* detail of an XML error */
        VIR_ERR_INVALID_NETWORK = 36,	/* invalid network object */
        VIR_ERR_NETWORK_EXIST = 37,		/* the network already exist */
        VIR_ERR_SYSTEM_ERROR = 38,		/* general system call failure */
        VIR_ERR_RPC = 39,			/* some sort of RPC error */
        VIR_ERR_GNUTLS_ERROR = 40,		/* error from a GNUTLS call */
        VIR_WAR_NO_NETWORK = 41,		/* failed to start network */
        VIR_ERR_NO_DOMAIN = 42,		/* domain not found or unexpectedly
                                           disappeared */
        VIR_ERR_NO_NETWORK = 43,		/* network not found */
        VIR_ERR_INVALID_MAC = 44,		/* invalid MAC address */
        VIR_ERR_AUTH_FAILED = 45,		/* authentication failed */
        VIR_ERR_INVALID_STORAGE_POOL = 46,	/* invalid storage pool object */
        VIR_ERR_INVALID_STORAGE_VOL = 47,	/* invalid storage vol object */
        VIR_WAR_NO_STORAGE = 48,		/* failed to start storage */
        VIR_ERR_NO_STORAGE_POOL = 49,	/* storage pool not found */
        VIR_ERR_NO_STORAGE_VOL = 50,	/* storage volume not found */
        VIR_WAR_NO_NODE = 51,		/* failed to start node driver */
        VIR_ERR_INVALID_NODE_DEVICE = 52,	/* invalid node device object */
        VIR_ERR_NO_NODE_DEVICE = 53,	/* node device not found */
        VIR_ERR_NO_SECURITY_MODEL = 54,	/* security model not found */
        VIR_ERR_OPERATION_INVALID = 55,	/* operation is not applicable at this
                                           time */
        VIR_WAR_NO_INTERFACE = 56,		/* failed to start interface driver */
        VIR_ERR_NO_INTERFACE = 57,		/* interface driver not running */
        VIR_ERR_INVALID_INTERFACE = 58,	/* invalid interface object */
        VIR_ERR_MULTIPLE_INTERFACES = 59,	/* more than one matching interface
                                           found */
        VIR_WAR_NO_NWFILTER = 60,		/* failed to start nwfilter driver */
        VIR_ERR_INVALID_NWFILTER = 61,	/* invalid nwfilter object */
        VIR_ERR_NO_NWFILTER = 62,		/* nw filter pool not found */
        VIR_ERR_BUILD_FIREWALL = 63,	/* nw filter pool not found */
        VIR_WAR_NO_SECRET = 64,		/* failed to start secret storage */
        VIR_ERR_INVALID_SECRET = 65,	/* invalid secret */
        VIR_ERR_NO_SECRET = 66,		/* secret not found */
        VIR_ERR_CONFIG_UNSUPPORTED = 67,	/* unsupported configuration
                                           construct */
        VIR_ERR_OPERATION_TIMEOUT = 68,	/* timeout occurred during operation */
        VIR_ERR_MIGRATE_PERSIST_FAILED = 69,/* a migration worked, but making the
                                           VM persist on the dest host failed */
        VIR_ERR_HOOK_SCRIPT_FAILED = 70,	/* a synchronous hook script failed */
        VIR_ERR_INVALID_DOMAIN_SNAPSHOT = 71,/* invalid domain snapshot */
        VIR_ERR_NO_DOMAIN_SNAPSHOT = 72,	/* domain snapshot not found */
        VIR_ERR_INVALID_STREAM = 73,	/* stream pointer not valid */
        VIR_ERR_ARGUMENT_UNSUPPORTED = 74,	/* valid API use but unsupported by
                                           the given driver */
        VIR_ERR_STORAGE_PROBE_FAILED = 75,	/* storage pool probe failed */
        VIR_ERR_STORAGE_POOL_BUILT = 76,	/* storage pool already built */
        VIR_ERR_SNAPSHOT_REVERT_RISKY = 77,	/* force was not requested for a
                                           risky domain snapshot revert */
        VIR_ERR_OPERATION_ABORTED = 78,     /* operation on a domain was
                                           canceled/aborted by user */
        VIR_ERR_AUTH_CANCELLED = 79,        /* authentication cancelled */
        VIR_ERR_NO_DOMAIN_METADATA = 80,    /* The metadata is not present */
        VIR_ERR_MIGRATE_UNSAFE = 81,        /* Migration is not safe */
        VIR_ERR_OVERFLOW = 82,              /* integer overflow */
        VIR_ERR_BLOCK_COPY_ACTIVE = 83,     /* action prevented by block copy job */
        VIR_ERR_OPERATION_UNSUPPORTED = 84, /* The requested operation is not
                                           supported */
        VIR_ERR_SSH = 85,                   /* error in ssh transport driver */
        VIR_ERR_AGENT_UNRESPONSIVE = 86,    /* guest agent is unresponsive,
                                           not running or not usable */
        VIR_ERR_RESOURCE_BUSY = 87,         /* resource is already in use */
        VIR_ERR_ACCESS_DENIED = 88,         /* operation on the object/resource
                                           was denied */
        VIR_ERR_DBUS_SERVICE = 89,          /* error from a dbus service */
        VIR_ERR_STORAGE_VOL_EXIST = 90,     /* the storage vol already exists */
        VIR_ERR_CPU_INCOMPATIBLE = 91,      /* given CPU is incompatible with host
                                           CPU*/
        VIR_ERR_XML_INVALID_SCHEMA = 92,    /* XML document doesn't validate against schema */
    };

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virErrorFunc(IntPtr userData, virErrorPtr error);

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virConnect
    {
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virStream
    {
    }


    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virSecurityLabel
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 4097)]
        public string @label;
        public int @enforcing;
    }


    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virSecurityModel
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 257)]
        public string @model;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 257)]
        public string @doi;
    }



    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virTypedParameter
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 80), FieldOffset(0)]
        public string @field;
        [FieldOffset(80)]
        public virTypedParameterType @type;
        [FieldOffset(84)]
        public int i;
        [FieldOffset(84)]
        public uint ui;
        [FieldOffset(84)]
        public long l;
        [FieldOffset(84)]
        public ulong ul;
        [FieldOffset(84)]
        public double d;
        [FieldOffset(84)]
        public byte b;
        [FieldOffset(84)]
        public IntPtr s;
    }
    public struct virTypedParameter
    {
        public string @field;
        public virTypedParameterType @type;

        public int i;
        public uint ui;
        public long l;
        public ulong ul;
        public double d;
        public byte b;
        public string s;
    }



    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virNodeInfo
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string @model;
        public int @memory;
        public uint @cpus;
        public uint @mhz;
        public uint @nodes;
        public uint @sockets;
        public uint @cores;
        public uint @threads;
    }


    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virNodeCPUStats
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string @field;
        public ulong @value;
    }


    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virNodeMemoryStats
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string @field;
        public ulong @value;
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virConnectCredential
    {
        public virConnectCredentialType @type;
        [MarshalAs(UnmanagedType.LPStr)]
        public string @prompt;
        [MarshalAs(UnmanagedType.LPStr)]
        public string @challenge;
        [MarshalAs(UnmanagedType.LPStr)]
        public string @defresult;
        [MarshalAs(UnmanagedType.LPStr)]
        public string @result;
        public uint @resultlen;
    }
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int virConnectAuthCallback(ref _virConnectCredential[] cred, uint ncred, IntPtr cbdata);


    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virConnectAuth
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public virConnectCredentialType[] @credtype;
        public int @ncredtype;//size in bytes of the credtype structure
        public virConnectAuthCallback @cb;
        public IntPtr @cbdata;
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virDomain
    {
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virDomainControlInfo
    {
        public uint @state;
        public uint @details;
        public ulong @stateTime;
    }
    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virDomainIOThreadInfo
    {
        public uint iothread_id;
        public IntPtr cpumap;
        public int cpumaplen;
    }
    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virDomainIPAddress
    {
        public int type;
        public IntPtr addr;
        public uint prefix;
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virDomainInfo
    {
        public virDomainState @state;
        public int @maxMem;
        public int @memory;
        public ushort @nrVirtCpu;
        public ulong @cpuTime;
    }


    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virDomainBlockStats
    {
        public long @rd_req;
        public long @rd_bytes;
        public long @wr_req;
        public long @wr_bytes;
        public long @errs;
    }


    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virDomainInterfaceStats
    {
        public long @rx_bytes;
        public long @rx_packets;
        public long @rx_errs;
        public long @rx_drop;
        public long @tx_bytes;
        public long @tx_packets;
        public long @tx_errs;
        public long @tx_drop;
    }


    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virDomainMemoryStat
    {
        public int @tag;
        public ulong @val;
    }


    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virDomainBlockInfo
    {
        public ulong @capacity;
        public ulong @allocation;
        public ulong @physical;
    }



    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virVcpuInfo
    {
        public uint @number;
        public int @state;
        public ulong @cpuTime;
        public int @cpu;
    }



    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virDomainStatsRecord
    {
        public virDomainPtr @dom;//DONT FREE THIS!!!!
        public IntPtr @params;
        public int @nparams;
    }
    public struct virDomainStatsRecord
    {
        public int domainuuid;
        public _virTypedParameter[] @params;
    }


    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virDomainBlockJobInfo
    {
        public int @type;
        public int @bandwidth;
        public ulong @cur;
        public ulong @end;
    }


    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct virDomainDiskError
    {
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Libvirt.PInvoke.StringWithNativeCleanUpMarshaler))]
        public string @disk;
        public virDomainDiskErrorCode @error;
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virDomainJobInfo
    {
        public int @type;
        public ulong @timeElapsed;
        public ulong @timeRemaining;
        public ulong @dataTotal;
        public ulong @dataProcessed;
        public ulong @dataRemaining;
        public ulong @memTotal;
        public ulong @memProcessed;
        public ulong @memRemaining;
        public ulong @fileTotal;
        public ulong @fileProcessed;
        public ulong @fileRemaining;
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virDomainEventGraphicsAddress
    {
        public int @family;
        [MarshalAs(UnmanagedType.LPStr)]
        public string @node;
        [MarshalAs(UnmanagedType.LPStr)]
        public string @service;
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virDomainEventGraphicsSubjectIdentity
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string @type;
        [MarshalAs(UnmanagedType.LPStr)]
        public string @name;
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virDomainEventGraphicsSubject
    {
        public int @nidentity;
        public IntPtr @identities;
    }


    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virDomainFSInfo
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string @mountpoint;
        [MarshalAs(UnmanagedType.LPStr)]
        public string @name;
        [MarshalAs(UnmanagedType.LPStr)]
        public string @fstype;
        public uint @ndevAlias;
        public IntPtr @devAlias;
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virDomainSnapshot
    {
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virInterface
    {
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virNetwork
    {
    }



    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virNetworkDHCPLease
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string @iface;
        public long @expirytime;
        public int @type;
        [MarshalAs(UnmanagedType.LPStr)]
        public string @mac;
        [MarshalAs(UnmanagedType.LPStr)]
        public string @iaid;
        [MarshalAs(UnmanagedType.LPStr)]
        public string @ipaddr;
        public uint @prefix;
        [MarshalAs(UnmanagedType.LPStr)]
        public string @hostname;
        [MarshalAs(UnmanagedType.LPStr)]
        public string @clientid;
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virNodeDevice
    {
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virNWFilter
    {
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virSecret
    {
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virStoragePool
    {
    }


    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virStoragePoolInfo
    {
        public virStoragePoolState @state;
        public ulong @capacity;
        public ulong @allocation;
        public ulong @available;
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virStorageVol
    {
    }


    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _virStorageVolInfo
    {
        public virStorageVolType @type;
        public ulong @capacity;
        public ulong @allocation;
    }


    public struct virConnectPtr : IDisposable
    {
        public IntPtr Pointer;
        public void Dispose()
        {
            Debug.WriteLine("Disposing");
            if (Pointer != IntPtr.Zero)
                PInvoke.virConnectClose(this);
            Pointer = IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }

    public struct virStreamPtr : IDisposable
    {
        public IntPtr Pointer;
        public void Dispose()
        {
            if (Pointer != IntPtr.Zero)
                PInvoke.virStreamFree(this);
            Pointer = IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }

    public partial struct virSecurityLabelPtr
    {
        public virSecurityLabelPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virSecurityModelPtr
    {
        public virSecurityModelPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virTypedParameterPtr
    {
        public virTypedParameterPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virNodeInfoPtr
    {
        public virNodeInfoPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virNodeCPUStatsPtr
    {
        public virNodeCPUStatsPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virNodeMemoryStatsPtr
    {
        public virNodeMemoryStatsPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virConnectCredentialPtr
    {
        public virConnectCredentialPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int virConnectAuthCallbackPtr(IntPtr @cred, uint @ncred, IntPtr @cbdata);

    public partial struct virConnectAuthPtr
    {
        public virConnectAuthPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectCloseFunc(IntPtr @conn, int @reason, IntPtr @opaque);

    public struct virDomainPtr : IDisposable
    {
        public virDomainPtr(IntPtr ptr)
        {
            Pointer = ptr;
        }
        public IntPtr Pointer;
        public void Dispose()
        {
            if (Pointer != IntPtr.Zero)
                PInvoke.virDomainFree(this);
            Pointer = IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }

    public partial struct virDomainControlInfoPtr
    {
        public virDomainControlInfoPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virDomainInfoPtr
    {
        public virDomainInfoPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virDomainBlockStatsPtr
    {
        public virDomainBlockStatsPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virDomainInterfaceStatsPtr
    {
        public virDomainInterfaceStatsPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virDomainMemoryStatPtr
    {
        public virDomainMemoryStatPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virDomainBlockInfoPtr
    {
        public virDomainBlockInfoPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virVcpuInfoPtr
    {
        public virVcpuInfoPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virDomainStatsRecordPtr
    {
        public virDomainStatsRecordPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virDomainBlockJobCursor
    {
        public virDomainBlockJobCursor(ulong value)
        {
            this.Value = value;
        }

        public ulong Value;
    }

    public partial struct virDomainBlockJobInfoPtr
    {
        public virDomainBlockJobInfoPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virDomainDiskErrorPtr
    {
        public virDomainDiskErrorPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int virConnectDomainEventCallback(IntPtr @conn, IntPtr @dom, int @event, int @detail, IntPtr @opaque);

    public partial struct virDomainJobInfoPtr
    {
        public virDomainJobInfoPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectDomainEventGenericCallback(IntPtr @conn, IntPtr @dom, IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectDomainEventRTCChangeCallback(IntPtr @conn, IntPtr @dom, long @utcoffset, IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectDomainEventWatchdogCallback(IntPtr @conn, IntPtr @dom, int @action, IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectDomainEventIOErrorCallback(IntPtr @conn, IntPtr @dom, [MarshalAs(UnmanagedType.LPStr)] string @srcPath, [MarshalAs(UnmanagedType.LPStr)] string @devAlias, int @action, IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectDomainEventIOErrorReasonCallback(IntPtr @conn, IntPtr @dom, [MarshalAs(UnmanagedType.LPStr)] string @srcPath, [MarshalAs(UnmanagedType.LPStr)] string @devAlias, int @action, [MarshalAs(UnmanagedType.LPStr)] string @reason, IntPtr @opaque);

    public partial struct virDomainEventGraphicsAddressPtr
    {
        public virDomainEventGraphicsAddressPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virDomainEventGraphicsSubjectIdentityPtr
    {
        public virDomainEventGraphicsSubjectIdentityPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virDomainEventGraphicsSubjectPtr
    {
        public virDomainEventGraphicsSubjectPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectDomainEventGraphicsCallback(virConnectPtr @conn, virDomainPtr @dom, int @phase, ref _virDomainEventGraphicsAddress @local, ref _virDomainEventGraphicsAddress @remote, [MarshalAs(UnmanagedType.LPStr)] string @authScheme, IntPtr @subject, IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectDomainEventBlockJobCallback(IntPtr @conn, IntPtr @dom, [MarshalAs(UnmanagedType.LPStr)] string @disk, int @type, int @status, IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectDomainEventDiskChangeCallback(IntPtr @conn, IntPtr @dom, [MarshalAs(UnmanagedType.LPStr)] string @oldSrcPath, [MarshalAs(UnmanagedType.LPStr)] string @newSrcPath, [MarshalAs(UnmanagedType.LPStr)] string @devAlias, int @reason, IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectDomainEventTrayChangeCallback(IntPtr @conn, IntPtr @dom, [MarshalAs(UnmanagedType.LPStr)] string @devAlias, int @reason, IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectDomainEventPMWakeupCallback(IntPtr @conn, IntPtr @dom, int @reason, IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectDomainEventPMSuspendCallback(IntPtr @conn, IntPtr @dom, int @reason, IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectDomainEventBalloonChangeCallback(IntPtr @conn, IntPtr @dom, ulong @actual, IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectDomainEventPMSuspendDiskCallback(IntPtr @conn, IntPtr @dom, int @reason, IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectDomainEventDeviceRemovedCallback(IntPtr @conn, IntPtr @dom, [MarshalAs(UnmanagedType.LPStr)] string @devAlias, IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectDomainEventTunableCallback(IntPtr @conn, IntPtr @dom, IntPtr @params, int @nparams, IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectDomainEventAgentLifecycleCallback(IntPtr @conn, IntPtr @dom, int @state, int @reason, IntPtr @opaque);

    public partial struct virDomainFSInfoPtr
    {
        public virDomainFSInfoPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virSchedParameterPtr
    {
        public virSchedParameterPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virBlkioParameterPtr
    {
        public virBlkioParameterPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virMemoryParameterPtr
    {
        public virMemoryParameterPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virDomainSnapshotPtr
    {
        public virDomainSnapshotPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virEventHandleCallback(int @watch, int @fd, int @events, IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int virEventAddHandleFunc(int @fd, int @event, virEventHandleCallback @cb, IntPtr @opaque, virFreeCallback @ff);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virEventUpdateHandleFunc(int @watch, int @event);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int virEventRemoveHandleFunc(int @watch);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virEventTimeoutCallback(int @timer, IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int virEventAddTimeoutFunc(int @timeout, virEventTimeoutCallback @cb, IntPtr @opaque, virFreeCallback @ff);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virEventUpdateTimeoutFunc(int @timer, int @timeout);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int virEventRemoveTimeoutFunc(int @timer);

    public struct virInterfacePtr : IDisposable
    {
        public IntPtr Pointer;
        public void Dispose()
        {
            if (Pointer != IntPtr.Zero)
                PInvoke.virInterfaceFree(this);
            Pointer = IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }

    public partial struct virNetworkPtr
    {
        public virNetworkPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectNetworkEventLifecycleCallback(IntPtr @conn, IntPtr @net, int @event, int @detail, IntPtr @opaque);

    public partial struct virNetworkDHCPLeasePtr
    {
        public virNetworkDHCPLeasePtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virConnectNetworkEventGenericCallback(IntPtr @conn, IntPtr @net, IntPtr @opaque);

    public partial struct virNodeDevicePtr
    {
        public virNodeDevicePtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virNWFilterPtr
    {
        public virNWFilterPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct virSecretPtr
    {
        public virSecretPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public struct virStoragePoolPtr : IDisposable
    {
        public IntPtr Pointer;
        public void Dispose()
        {
            if (Pointer != IntPtr.Zero)
                PInvoke.virStoragePoolFree(this);
            Pointer = IntPtr.Zero;
            GC.SuppressFinalize(this);
        }

    }

    public partial struct virStoragePoolInfoPtr
    {
        public virStoragePoolInfoPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public struct virStorageVolPtr : IDisposable
    {
        public IntPtr Pointer;
        public void Dispose()
        {
            if (Pointer != IntPtr.Zero)
                PInvoke.virStorageVolFree(this);
            Pointer = IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }

    public partial struct virStorageVolInfoPtr
    {
        public virStorageVolInfoPtr(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virFreeCallback(IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int virStreamSourceFunc(virStreamPtr @st, IntPtr @data, uint @nbytes, IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int virStreamSinkFunc(IntPtr @st, [MarshalAs(UnmanagedType.LPStr)] string @data, uint @nbytes, IntPtr @opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void virStreamEventCallback(IntPtr @stream, int @events, IntPtr @opaque);

    public enum virNodeSuspendTarget : uint
    {
        @VIR_NODE_SUSPEND_TARGET_MEM = 0,
        @VIR_NODE_SUSPEND_TARGET_DISK = 1,
        @VIR_NODE_SUSPEND_TARGET_HYBRID = 2,
    }

    public enum virTypedParameterType : uint
    {
        @VIR_TYPED_PARAM_INT = 1,
        @VIR_TYPED_PARAM_UINT = 2,
        @VIR_TYPED_PARAM_LLONG = 3,
        @VIR_TYPED_PARAM_ULLONG = 4,
        @VIR_TYPED_PARAM_DOUBLE = 5,
        @VIR_TYPED_PARAM_BOOLEAN = 6,
        @VIR_TYPED_PARAM_STRING = 7,
    }

    public enum virTypedParameterFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_TYPED_PARAM_STRING_OKAY = 4,
    }

    public enum virNodeGetCPUStatsAllCPUs : int
    {
        @VIR_DEFAULT = 0,
        @VIR_NODE_CPU_STATS_ALL_CPUS = -1,
    }

    public enum virNodeGetMemoryStatsAllCells : int
    {
        @VIR_DEFAULT = 0,
        @VIR_NODE_MEMORY_STATS_ALL_CELLS = -1,
    }

    public enum virConnectFlags : uint
    {
        @VIR_DEFAULT = 0,//use this for normal connect attempts
        @VIR_CONNECT_RO = 1,
        @VIR_CONNECT_NO_ALIASES = 2,
    }

    public enum virConnectCredentialType : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_CRED_USERNAME = 1,
        @VIR_CRED_AUTHNAME = 2,
        @VIR_CRED_LANGUAGE = 3,
        @VIR_CRED_CNONCE = 4,
        @VIR_CRED_PASSPHRASE = 5,
        @VIR_CRED_ECHOPROMPT = 6,
        @VIR_CRED_NOECHOPROMPT = 7,
        @VIR_CRED_REALM = 8,
        @VIR_CRED_EXTERNAL = 9,
    }

    public enum virConnectCloseReason : int
    {
        @VIR_CONNECT_CLOSE_REASON_ERROR = 0,
        @VIR_CONNECT_CLOSE_REASON_EOF = 1,
        @VIR_CONNECT_CLOSE_REASON_KEEPALIVE = 2,
        @VIR_CONNECT_CLOSE_REASON_CLIENT = 3,
    }

    public enum virCPUCompareResult : int
    {
        @VIR_CPU_COMPARE_ERROR = -1,
        @VIR_CPU_COMPARE_INCOMPATIBLE = 0,
        @VIR_CPU_COMPARE_IDENTICAL = 1,
        @VIR_CPU_COMPARE_SUPERSET = 2,
    }

    public enum virConnectCompareCPUFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_CONNECT_COMPARE_CPU_FAIL_INCOMPATIBLE = 1,
    }

    public enum virConnectBaselineCPUFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_CONNECT_BASELINE_CPU_EXPAND_FEATURES = 1,
    }

    public enum virNodeAllocPagesFlags : uint
    {
        @VIR_NODE_ALLOC_PAGES_ADD = 0,
        @VIR_NODE_ALLOC_PAGES_SET = 1,
    }

    public enum virDomainState : byte
    {
        @VIR_DOMAIN_NOSTATE = 0,
        @VIR_DOMAIN_RUNNING = 1,
        @VIR_DOMAIN_BLOCKED = 2,
        @VIR_DOMAIN_PAUSED = 3,
        @VIR_DOMAIN_SHUTDOWN = 4,
        @VIR_DOMAIN_SHUTOFF = 5,
        @VIR_DOMAIN_CRASHED = 6,
        @VIR_DOMAIN_PMSUSPENDED = 7,
    }

    public enum virDomainNostateReason : uint
    {
        @VIR_DOMAIN_NOSTATE_UNKNOWN = 0,
    }

    public enum virDomainRunningReason : uint
    {
        @VIR_DOMAIN_RUNNING_UNKNOWN = 0,
        @VIR_DOMAIN_RUNNING_BOOTED = 1,
        @VIR_DOMAIN_RUNNING_MIGRATED = 2,
        @VIR_DOMAIN_RUNNING_RESTORED = 3,
        @VIR_DOMAIN_RUNNING_FROM_SNAPSHOT = 4,
        @VIR_DOMAIN_RUNNING_UNPAUSED = 5,
        @VIR_DOMAIN_RUNNING_MIGRATION_CANCELED = 6,
        @VIR_DOMAIN_RUNNING_SAVE_CANCELED = 7,
        @VIR_DOMAIN_RUNNING_WAKEUP = 8,
        @VIR_DOMAIN_RUNNING_CRASHED = 9,
    }

    public enum virDomainBlockedReason : uint
    {
        @VIR_DOMAIN_BLOCKED_UNKNOWN = 0,
    }

    public enum virDomainPausedReason : uint
    {
        @VIR_DOMAIN_PAUSED_UNKNOWN = 0,
        @VIR_DOMAIN_PAUSED_USER = 1,
        @VIR_DOMAIN_PAUSED_MIGRATION = 2,
        @VIR_DOMAIN_PAUSED_SAVE = 3,
        @VIR_DOMAIN_PAUSED_DUMP = 4,
        @VIR_DOMAIN_PAUSED_IOERROR = 5,
        @VIR_DOMAIN_PAUSED_WATCHDOG = 6,
        @VIR_DOMAIN_PAUSED_FROM_SNAPSHOT = 7,
        @VIR_DOMAIN_PAUSED_SHUTTING_DOWN = 8,
        @VIR_DOMAIN_PAUSED_SNAPSHOT = 9,
        @VIR_DOMAIN_PAUSED_CRASHED = 10,
    }

    public enum virDomainShutdownReason : uint
    {
        @VIR_DOMAIN_SHUTDOWN_UNKNOWN = 0,
        @VIR_DOMAIN_SHUTDOWN_USER = 1,
    }

    public enum virDomainShutoffReason : uint
    {
        @VIR_DOMAIN_SHUTOFF_UNKNOWN = 0,
        @VIR_DOMAIN_SHUTOFF_SHUTDOWN = 1,
        @VIR_DOMAIN_SHUTOFF_DESTROYED = 2,
        @VIR_DOMAIN_SHUTOFF_CRASHED = 3,
        @VIR_DOMAIN_SHUTOFF_MIGRATED = 4,
        @VIR_DOMAIN_SHUTOFF_SAVED = 5,
        @VIR_DOMAIN_SHUTOFF_FAILED = 6,
        @VIR_DOMAIN_SHUTOFF_FROM_SNAPSHOT = 7,
    }

    public enum virDomainCrashedReason : uint
    {
        @VIR_DOMAIN_CRASHED_UNKNOWN = 0,
        @VIR_DOMAIN_CRASHED_PANICKED = 1,
    }

    public enum virDomainPMSuspendedReason : uint
    {
        @VIR_DOMAIN_PMSUSPENDED_UNKNOWN = 0,
    }

    public enum virDomainPMSuspendedDiskReason : uint
    {
        @VIR_DOMAIN_PMSUSPENDED_DISK_UNKNOWN = 0,
    }

    public enum virDomainControlState : uint
    {
        @VIR_DOMAIN_CONTROL_OK = 0,
        @VIR_DOMAIN_CONTROL_JOB = 1,
        @VIR_DOMAIN_CONTROL_OCCUPIED = 2,
        @VIR_DOMAIN_CONTROL_ERROR = 3,
    }

    public enum virDomainModificationImpact : uint
    {
        @VIR_DOMAIN_AFFECT_CURRENT = 0,
        @VIR_DOMAIN_AFFECT_LIVE = 1,
        @VIR_DOMAIN_AFFECT_CONFIG = 2,
    }

    public enum virDomainCreateFlags : uint
    {
        @VIR_DOMAIN_NONE = 0,
        @VIR_DOMAIN_START_PAUSED = 1,
        @VIR_DOMAIN_START_AUTODESTROY = 2,
        @VIR_DOMAIN_START_BYPASS_CACHE = 4,
        @VIR_DOMAIN_START_FORCE_BOOT = 8,
        @VIR_DOMAIN_START_VALIDATE = 16,
    }

    public enum virDomainMemoryStatTags : uint
    {
        @VIR_DOMAIN_MEMORY_STAT_SWAP_IN = 0,
        @VIR_DOMAIN_MEMORY_STAT_SWAP_OUT = 1,
        @VIR_DOMAIN_MEMORY_STAT_MAJOR_FAULT = 2,
        @VIR_DOMAIN_MEMORY_STAT_MINOR_FAULT = 3,
        @VIR_DOMAIN_MEMORY_STAT_UNUSED = 4,
        @VIR_DOMAIN_MEMORY_STAT_AVAILABLE = 5,
        @VIR_DOMAIN_MEMORY_STAT_ACTUAL_BALLOON = 6,
        @VIR_DOMAIN_MEMORY_STAT_RSS = 7,
        @VIR_DOMAIN_MEMORY_STAT_NR = 8,
    }

    public enum virDomainCoreDumpFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DUMP_CRASH = 1,
        @VIR_DUMP_LIVE = 2,
        @VIR_DUMP_BYPASS_CACHE = 4,
        @VIR_DUMP_RESET = 8,
        @VIR_DUMP_MEMORY_ONLY = 16,
    }

    public enum virDomainCoreDumpFormat : uint
    {
        @VIR_DOMAIN_CORE_DUMP_FORMAT_RAW = 0,
        @VIR_DOMAIN_CORE_DUMP_FORMAT_KDUMP_ZLIB = 1,
        @VIR_DOMAIN_CORE_DUMP_FORMAT_KDUMP_LZO = 2,
        @VIR_DOMAIN_CORE_DUMP_FORMAT_KDUMP_SNAPPY = 3,
    }

    public enum virDomainMigrateFlags : uint
    {
        @VIR_MIGRATE_LIVE = 1,
        @VIR_MIGRATE_PEER2PEER = 2,
        @VIR_MIGRATE_TUNNELLED = 4,
        @VIR_MIGRATE_PERSIST_DEST = 8,
        @VIR_MIGRATE_UNDEFINE_SOURCE = 16,
        @VIR_MIGRATE_PAUSED = 32,
        @VIR_MIGRATE_NON_SHARED_DISK = 64,
        @VIR_MIGRATE_NON_SHARED_INC = 128,
        @VIR_MIGRATE_CHANGE_PROTECTION = 256,
        @VIR_MIGRATE_UNSAFE = 512,
        @VIR_MIGRATE_OFFLINE = 1024,
        @VIR_MIGRATE_COMPRESSED = 2048,
        @VIR_MIGRATE_ABORT_ON_ERROR = 4096,
        @VIR_MIGRATE_AUTO_CONVERGE = 8192,
        @VIR_MIGRATE_RDMA_PIN_ALL = 16384,
    }

    public enum virDomainShutdownFlagValues : uint
    {
        @VIR_DOMAIN_SHUTDOWN_DEFAULT = 0,
        @VIR_DOMAIN_SHUTDOWN_ACPI_POWER_BTN = 1,
        @VIR_DOMAIN_SHUTDOWN_GUEST_AGENT = 2,
        @VIR_DOMAIN_SHUTDOWN_INITCTL = 4,
        @VIR_DOMAIN_SHUTDOWN_SIGNAL = 8,
        @VIR_DOMAIN_SHUTDOWN_PARAVIRT = 16,
    }

    public enum virDomainRebootFlagValues : uint
    {
        @VIR_DOMAIN_REBOOT_DEFAULT = 0,
        @VIR_DOMAIN_REBOOT_ACPI_POWER_BTN = 1,
        @VIR_DOMAIN_REBOOT_GUEST_AGENT = 2,
        @VIR_DOMAIN_REBOOT_INITCTL = 4,
        @VIR_DOMAIN_REBOOT_SIGNAL = 8,
        @VIR_DOMAIN_REBOOT_PARAVIRT = 16,
    }

    public enum virDomainDestroyFlagsValues : uint
    {
        @VIR_DOMAIN_DESTROY_DEFAULT = 0,
        @VIR_DOMAIN_DESTROY_GRACEFUL = 1,
    }

    public enum virDomainSaveRestoreFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_SAVE_BYPASS_CACHE = 1,
        @VIR_DOMAIN_SAVE_RUNNING = 2,
        @VIR_DOMAIN_SAVE_PAUSED = 4,
    }

    public enum virDomainMemoryModFlags : uint
    {
        @VIR_DOMAIN_MEM_CURRENT = 0,
        @VIR_DOMAIN_MEM_LIVE = 1,
        @VIR_DOMAIN_MEM_CONFIG = 2,
        @VIR_DOMAIN_MEM_MAXIMUM = 4,
    }

    public enum virDomainNumatuneMemMode : uint
    {
        @VIR_DOMAIN_NUMATUNE_MEM_STRICT = 0,
        @VIR_DOMAIN_NUMATUNE_MEM_PREFERRED = 1,
        @VIR_DOMAIN_NUMATUNE_MEM_INTERLEAVE = 2,
    }

    public enum virDomainMetadataType : int
    {
        @VIR_DOMAIN_METADATA_DESCRIPTION = 0,
        @VIR_DOMAIN_METADATA_TITLE = 1,
        @VIR_DOMAIN_METADATA_ELEMENT = 2,
    }

    public enum virDomainXMLFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_XML_SECURE = 1,
        @VIR_DOMAIN_XML_INACTIVE = 2,
        @VIR_DOMAIN_XML_UPDATE_CPU = 4,
        @VIR_DOMAIN_XML_MIGRATABLE = 8,
    }

    public enum virDomainBlockResizeFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_BLOCK_RESIZE_BYTES = 1,
    }

    public enum virDomainMemoryFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_MEMORY_VIRTUAL = 1,
        @VIR_MEMORY_PHYSICAL = 2,
    }

    public enum virDomainDefineFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_DEFINE_VALIDATE = 1,
    }

    public enum virDomainUndefineFlagsValues : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_UNDEFINE_MANAGED_SAVE = 1,
        @VIR_DOMAIN_UNDEFINE_SNAPSHOTS_METADATA = 2,
        @VIR_DOMAIN_UNDEFINE_NVRAM = 4,
    }

    public enum virConnectListAllDomainsFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_CONNECT_LIST_DOMAINS_ACTIVE = 1,
        @VIR_CONNECT_LIST_DOMAINS_INACTIVE = 2,
        @VIR_CONNECT_LIST_DOMAINS_PERSISTENT = 4,
        @VIR_CONNECT_LIST_DOMAINS_TRANSIENT = 8,
        @VIR_CONNECT_LIST_DOMAINS_RUNNING = 16,
        @VIR_CONNECT_LIST_DOMAINS_PAUSED = 32,
        @VIR_CONNECT_LIST_DOMAINS_SHUTOFF = 64,
        @VIR_CONNECT_LIST_DOMAINS_OTHER = 128,
        @VIR_CONNECT_LIST_DOMAINS_MANAGEDSAVE = 256,
        @VIR_CONNECT_LIST_DOMAINS_NO_MANAGEDSAVE = 512,
        @VIR_CONNECT_LIST_DOMAINS_AUTOSTART = 1024,
        @VIR_CONNECT_LIST_DOMAINS_NO_AUTOSTART = 2048,
        @VIR_CONNECT_LIST_DOMAINS_HAS_SNAPSHOT = 4096,
        @VIR_CONNECT_LIST_DOMAINS_NO_SNAPSHOT = 8192,
    }

    public enum virVcpuState : uint
    {
        @VIR_VCPU_OFFLINE = 0,
        @VIR_VCPU_RUNNING = 1,
        @VIR_VCPU_BLOCKED = 2,
    }

    public enum virDomainVcpuFlags : uint
    {
        @VIR_DOMAIN_VCPU_CURRENT = 0,
        @VIR_DOMAIN_VCPU_LIVE = 1,
        @VIR_DOMAIN_VCPU_CONFIG = 2,
        @VIR_DOMAIN_VCPU_MAXIMUM = 4,
        @VIR_DOMAIN_VCPU_GUEST = 8,
    }

    public enum virDomainDeviceModifyFlags : uint
    {
        @VIR_DOMAIN_DEVICE_MODIFY_CURRENT = 0,
        @VIR_DOMAIN_DEVICE_MODIFY_LIVE = 1,
        @VIR_DOMAIN_DEVICE_MODIFY_CONFIG = 2,
        @VIR_DOMAIN_DEVICE_MODIFY_FORCE = 4,
    }

    public enum virDomainStatsTypes : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_STATS_STATE = 1,
        @VIR_DOMAIN_STATS_CPU_TOTAL = 2,
        @VIR_DOMAIN_STATS_BALLOON = 4,
        @VIR_DOMAIN_STATS_VCPU = 8,
        @VIR_DOMAIN_STATS_INTERFACE = 16,
        @VIR_DOMAIN_STATS_BLOCK = 32,
    }

    public enum virConnectGetAllDomainStatsFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_CONNECT_GET_ALL_DOMAINS_STATS_ACTIVE = 1,
        @VIR_CONNECT_GET_ALL_DOMAINS_STATS_INACTIVE = 2,
        @VIR_CONNECT_GET_ALL_DOMAINS_STATS_PERSISTENT = 4,
        @VIR_CONNECT_GET_ALL_DOMAINS_STATS_TRANSIENT = 8,
        @VIR_CONNECT_GET_ALL_DOMAINS_STATS_RUNNING = 16,
        @VIR_CONNECT_GET_ALL_DOMAINS_STATS_PAUSED = 32,
        @VIR_CONNECT_GET_ALL_DOMAINS_STATS_SHUTOFF = 64,
        @VIR_CONNECT_GET_ALL_DOMAINS_STATS_OTHER = 128,
        @VIR_CONNECT_GET_ALL_DOMAINS_STATS_BACKING = 1073741824,
        //  @VIR_CONNECT_GET_ALL_DOMAINS_STATS_ENFORCE_STATS = -2147483648,
    }

    public enum virDomainBlockJobType : uint
    {
        @VIR_DOMAIN_BLOCK_JOB_TYPE_UNKNOWN = 0,
        @VIR_DOMAIN_BLOCK_JOB_TYPE_PULL = 1,
        @VIR_DOMAIN_BLOCK_JOB_TYPE_COPY = 2,
        @VIR_DOMAIN_BLOCK_JOB_TYPE_COMMIT = 3,
        @VIR_DOMAIN_BLOCK_JOB_TYPE_ACTIVE_COMMIT = 4,
    }

    public enum virDomainBlockJobAbortFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_BLOCK_JOB_ABORT_ASYNC = 1,
        @VIR_DOMAIN_BLOCK_JOB_ABORT_PIVOT = 2,
    }

    public enum virDomainBlockJobInfoFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_BLOCK_JOB_INFO_BANDWIDTH_BYTES = 1,
    }

    public enum virDomainBlockJobSetSpeedFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_BLOCK_JOB_SPEED_BANDWIDTH_BYTES = 1,
    }

    public enum virDomainBlockPullFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_BLOCK_PULL_BANDWIDTH_BYTES = 64,
    }

    public enum virDomainBlockRebaseFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_BLOCK_REBASE_SHALLOW = 1,
        @VIR_DOMAIN_BLOCK_REBASE_REUSE_EXT = 2,
        @VIR_DOMAIN_BLOCK_REBASE_COPY_RAW = 4,
        @VIR_DOMAIN_BLOCK_REBASE_COPY = 8,
        @VIR_DOMAIN_BLOCK_REBASE_RELATIVE = 16,
        @VIR_DOMAIN_BLOCK_REBASE_COPY_DEV = 32,
        @VIR_DOMAIN_BLOCK_REBASE_BANDWIDTH_BYTES = 64,
    }

    public enum virDomainBlockCopyFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_BLOCK_COPY_SHALLOW = 1,
        @VIR_DOMAIN_BLOCK_COPY_REUSE_EXT = 2,
    }

    public enum virDomainBlockCommitFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_BLOCK_COMMIT_SHALLOW = 1,
        @VIR_DOMAIN_BLOCK_COMMIT_DELETE = 2,
        @VIR_DOMAIN_BLOCK_COMMIT_ACTIVE = 4,
        @VIR_DOMAIN_BLOCK_COMMIT_RELATIVE = 8,
        @VIR_DOMAIN_BLOCK_COMMIT_BANDWIDTH_BYTES = 16,
    }

    public enum virDomainDiskErrorCode : uint
    {
        @VIR_DOMAIN_DISK_ERROR_NONE = 0,
        @VIR_DOMAIN_DISK_ERROR_UNSPEC = 1,
        @VIR_DOMAIN_DISK_ERROR_NO_SPACE = 2,
    }

    public enum virKeycodeSet : uint
    {
        @VIR_KEYCODE_SET_LINUX = 0,
        @VIR_KEYCODE_SET_XT = 1,
        @VIR_KEYCODE_SET_ATSET1 = 2,
        @VIR_KEYCODE_SET_ATSET2 = 3,
        @VIR_KEYCODE_SET_ATSET3 = 4,
        @VIR_KEYCODE_SET_OSX = 5,
        @VIR_KEYCODE_SET_XT_KBD = 6,
        @VIR_KEYCODE_SET_USB = 7,
        @VIR_KEYCODE_SET_WIN32 = 8,
        @VIR_KEYCODE_SET_RFB = 9,
    }

    public enum virDomainProcessSignal : uint
    {
        @VIR_DOMAIN_PROCESS_SIGNAL_NOP = 0,
        @VIR_DOMAIN_PROCESS_SIGNAL_HUP = 1,
        @VIR_DOMAIN_PROCESS_SIGNAL_INT = 2,
        @VIR_DOMAIN_PROCESS_SIGNAL_QUIT = 3,
        @VIR_DOMAIN_PROCESS_SIGNAL_ILL = 4,
        @VIR_DOMAIN_PROCESS_SIGNAL_TRAP = 5,
        @VIR_DOMAIN_PROCESS_SIGNAL_ABRT = 6,
        @VIR_DOMAIN_PROCESS_SIGNAL_BUS = 7,
        @VIR_DOMAIN_PROCESS_SIGNAL_FPE = 8,
        @VIR_DOMAIN_PROCESS_SIGNAL_KILL = 9,
        @VIR_DOMAIN_PROCESS_SIGNAL_USR1 = 10,
        @VIR_DOMAIN_PROCESS_SIGNAL_SEGV = 11,
        @VIR_DOMAIN_PROCESS_SIGNAL_USR2 = 12,
        @VIR_DOMAIN_PROCESS_SIGNAL_PIPE = 13,
        @VIR_DOMAIN_PROCESS_SIGNAL_ALRM = 14,
        @VIR_DOMAIN_PROCESS_SIGNAL_TERM = 15,
        @VIR_DOMAIN_PROCESS_SIGNAL_STKFLT = 16,
        @VIR_DOMAIN_PROCESS_SIGNAL_CHLD = 17,
        @VIR_DOMAIN_PROCESS_SIGNAL_CONT = 18,
        @VIR_DOMAIN_PROCESS_SIGNAL_STOP = 19,
        @VIR_DOMAIN_PROCESS_SIGNAL_TSTP = 20,
        @VIR_DOMAIN_PROCESS_SIGNAL_TTIN = 21,
        @VIR_DOMAIN_PROCESS_SIGNAL_TTOU = 22,
        @VIR_DOMAIN_PROCESS_SIGNAL_URG = 23,
        @VIR_DOMAIN_PROCESS_SIGNAL_XCPU = 24,
        @VIR_DOMAIN_PROCESS_SIGNAL_XFSZ = 25,
        @VIR_DOMAIN_PROCESS_SIGNAL_VTALRM = 26,
        @VIR_DOMAIN_PROCESS_SIGNAL_PROF = 27,
        @VIR_DOMAIN_PROCESS_SIGNAL_WINCH = 28,
        @VIR_DOMAIN_PROCESS_SIGNAL_POLL = 29,
        @VIR_DOMAIN_PROCESS_SIGNAL_PWR = 30,
        @VIR_DOMAIN_PROCESS_SIGNAL_SYS = 31,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT0 = 32,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT1 = 33,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT2 = 34,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT3 = 35,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT4 = 36,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT5 = 37,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT6 = 38,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT7 = 39,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT8 = 40,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT9 = 41,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT10 = 42,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT11 = 43,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT12 = 44,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT13 = 45,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT14 = 46,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT15 = 47,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT16 = 48,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT17 = 49,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT18 = 50,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT19 = 51,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT20 = 52,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT21 = 53,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT22 = 54,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT23 = 55,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT24 = 56,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT25 = 57,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT26 = 58,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT27 = 59,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT28 = 60,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT29 = 61,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT30 = 62,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT31 = 63,
        @VIR_DOMAIN_PROCESS_SIGNAL_RT32 = 64,
    }

    public enum virDomainEventType : uint
    {
        @VIR_DOMAIN_EVENT_DEFINED = 0,
        @VIR_DOMAIN_EVENT_UNDEFINED = 1,
        @VIR_DOMAIN_EVENT_STARTED = 2,
        @VIR_DOMAIN_EVENT_SUSPENDED = 3,
        @VIR_DOMAIN_EVENT_RESUMED = 4,
        @VIR_DOMAIN_EVENT_STOPPED = 5,
        @VIR_DOMAIN_EVENT_SHUTDOWN = 6,
        @VIR_DOMAIN_EVENT_PMSUSPENDED = 7,
        @VIR_DOMAIN_EVENT_CRASHED = 8,
    }

    public enum virDomainEventDefinedDetailType : uint
    {
        @VIR_DOMAIN_EVENT_DEFINED_ADDED = 0,
        @VIR_DOMAIN_EVENT_DEFINED_UPDATED = 1,
    }

    public enum virDomainEventUndefinedDetailType : uint
    {
        @VIR_DOMAIN_EVENT_UNDEFINED_REMOVED = 0,
    }

    public enum virDomainEventStartedDetailType : uint
    {
        @VIR_DOMAIN_EVENT_STARTED_BOOTED = 0,
        @VIR_DOMAIN_EVENT_STARTED_MIGRATED = 1,
        @VIR_DOMAIN_EVENT_STARTED_RESTORED = 2,
        @VIR_DOMAIN_EVENT_STARTED_FROM_SNAPSHOT = 3,
        @VIR_DOMAIN_EVENT_STARTED_WAKEUP = 4,
    }

    public enum virDomainEventSuspendedDetailType : uint
    {
        @VIR_DOMAIN_EVENT_SUSPENDED_PAUSED = 0,
        @VIR_DOMAIN_EVENT_SUSPENDED_MIGRATED = 1,
        @VIR_DOMAIN_EVENT_SUSPENDED_IOERROR = 2,
        @VIR_DOMAIN_EVENT_SUSPENDED_WATCHDOG = 3,
        @VIR_DOMAIN_EVENT_SUSPENDED_RESTORED = 4,
        @VIR_DOMAIN_EVENT_SUSPENDED_FROM_SNAPSHOT = 5,
        @VIR_DOMAIN_EVENT_SUSPENDED_API_ERROR = 6,
    }

    public enum virDomainEventResumedDetailType : uint
    {
        @VIR_DOMAIN_EVENT_RESUMED_UNPAUSED = 0,
        @VIR_DOMAIN_EVENT_RESUMED_MIGRATED = 1,
        @VIR_DOMAIN_EVENT_RESUMED_FROM_SNAPSHOT = 2,
    }

    public enum virDomainEventStoppedDetailType : uint
    {
        @VIR_DOMAIN_EVENT_STOPPED_SHUTDOWN = 0,
        @VIR_DOMAIN_EVENT_STOPPED_DESTROYED = 1,
        @VIR_DOMAIN_EVENT_STOPPED_CRASHED = 2,
        @VIR_DOMAIN_EVENT_STOPPED_MIGRATED = 3,
        @VIR_DOMAIN_EVENT_STOPPED_SAVED = 4,
        @VIR_DOMAIN_EVENT_STOPPED_FAILED = 5,
        @VIR_DOMAIN_EVENT_STOPPED_FROM_SNAPSHOT = 6,
    }

    public enum virDomainEventShutdownDetailType : uint
    {
        @VIR_DOMAIN_EVENT_SHUTDOWN_FINISHED = 0,
    }

    public enum virDomainEventPMSuspendedDetailType : uint
    {
        @VIR_DOMAIN_EVENT_PMSUSPENDED_MEMORY = 0,
        @VIR_DOMAIN_EVENT_PMSUSPENDED_DISK = 1,
    }

    public enum virDomainEventCrashedDetailType : uint
    {
        @VIR_DOMAIN_EVENT_CRASHED_PANICKED = 0,
    }

    public enum virDomainJobType : int
    {
        @VIR_DOMAIN_JOB_NONE = 0,
        @VIR_DOMAIN_JOB_BOUNDED = 1,
        @VIR_DOMAIN_JOB_UNBOUNDED = 2,
        @VIR_DOMAIN_JOB_COMPLETED = 3,
        @VIR_DOMAIN_JOB_FAILED = 4,
        @VIR_DOMAIN_JOB_CANCELLED = 5,
    }

    public enum virDomainGetJobStatsFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_JOB_STATS_COMPLETED = 1,
    }

    public enum virDomainEventWatchdogAction : uint
    {
        @VIR_DOMAIN_EVENT_WATCHDOG_NONE = 0,
        @VIR_DOMAIN_EVENT_WATCHDOG_PAUSE = 1,
        @VIR_DOMAIN_EVENT_WATCHDOG_RESET = 2,
        @VIR_DOMAIN_EVENT_WATCHDOG_POWEROFF = 3,
        @VIR_DOMAIN_EVENT_WATCHDOG_SHUTDOWN = 4,
        @VIR_DOMAIN_EVENT_WATCHDOG_DEBUG = 5,
    }

    public enum virDomainEventIOErrorAction : uint
    {
        @VIR_DOMAIN_EVENT_IO_ERROR_NONE = 0,
        @VIR_DOMAIN_EVENT_IO_ERROR_PAUSE = 1,
        @VIR_DOMAIN_EVENT_IO_ERROR_REPORT = 2,
    }

    public enum virDomainEventGraphicsPhase : uint
    {
        @VIR_DOMAIN_EVENT_GRAPHICS_CONNECT = 0,
        @VIR_DOMAIN_EVENT_GRAPHICS_INITIALIZE = 1,
        @VIR_DOMAIN_EVENT_GRAPHICS_DISCONNECT = 2,
    }

    public enum virDomainEventGraphicsAddressType : uint
    {
        @VIR_DOMAIN_EVENT_GRAPHICS_ADDRESS_IPV4 = 0,
        @VIR_DOMAIN_EVENT_GRAPHICS_ADDRESS_IPV6 = 1,
        @VIR_DOMAIN_EVENT_GRAPHICS_ADDRESS_UNIX = 2,
    }

    public enum virConnectDomainEventBlockJobStatus : uint
    {
        @VIR_DOMAIN_BLOCK_JOB_COMPLETED = 0,
        @VIR_DOMAIN_BLOCK_JOB_FAILED = 1,
        @VIR_DOMAIN_BLOCK_JOB_CANCELED = 2,
        @VIR_DOMAIN_BLOCK_JOB_READY = 3,
    }

    public enum virConnectDomainEventDiskChangeReason : uint
    {
        @VIR_DOMAIN_EVENT_DISK_CHANGE_MISSING_ON_START = 0,
        @VIR_DOMAIN_EVENT_DISK_DROP_MISSING_ON_START = 1,
    }

    public enum virDomainEventTrayChangeReason : uint
    {
        @VIR_DOMAIN_EVENT_TRAY_CHANGE_OPEN = 0,
        @VIR_DOMAIN_EVENT_TRAY_CHANGE_CLOSE = 1,
    }

    public enum virConnectDomainEventAgentLifecycleState : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_CONNECT_DOMAIN_EVENT_AGENT_LIFECYCLE_STATE_CONNECTED = 1,
        @VIR_CONNECT_DOMAIN_EVENT_AGENT_LIFECYCLE_STATE_DISCONNECTED = 2,
    }

    public enum virConnectDomainEventAgentLifecycleReason : uint
    {
        @VIR_CONNECT_DOMAIN_EVENT_AGENT_LIFECYCLE_REASON_UNKNOWN = 0,
        @VIR_CONNECT_DOMAIN_EVENT_AGENT_LIFECYCLE_REASON_DOMAIN_STARTED = 1,
        @VIR_CONNECT_DOMAIN_EVENT_AGENT_LIFECYCLE_REASON_CHANNEL = 2,
    }

    public enum virDomainEventID : int
    {
        @VIR_DOMAIN_EVENT_ID_LIFECYCLE = 0,
        @VIR_DOMAIN_EVENT_ID_REBOOT = 1,
        @VIR_DOMAIN_EVENT_ID_RTC_CHANGE = 2,
        @VIR_DOMAIN_EVENT_ID_WATCHDOG = 3,
        @VIR_DOMAIN_EVENT_ID_IO_ERROR = 4,
        @VIR_DOMAIN_EVENT_ID_GRAPHICS = 5,
        @VIR_DOMAIN_EVENT_ID_IO_ERROR_REASON = 6,
        @VIR_DOMAIN_EVENT_ID_CONTROL_ERROR = 7,
        @VIR_DOMAIN_EVENT_ID_BLOCK_JOB = 8,
        @VIR_DOMAIN_EVENT_ID_DISK_CHANGE = 9,
        @VIR_DOMAIN_EVENT_ID_TRAY_CHANGE = 10,
        @VIR_DOMAIN_EVENT_ID_PMWAKEUP = 11,
        @VIR_DOMAIN_EVENT_ID_PMSUSPEND = 12,
        @VIR_DOMAIN_EVENT_ID_BALLOON_CHANGE = 13,
        @VIR_DOMAIN_EVENT_ID_PMSUSPEND_DISK = 14,
        @VIR_DOMAIN_EVENT_ID_DEVICE_REMOVED = 15,
        @VIR_DOMAIN_EVENT_ID_BLOCK_JOB_2 = 16,
        @VIR_DOMAIN_EVENT_ID_TUNABLE = 17,
        @VIR_DOMAIN_EVENT_ID_AGENT_LIFECYCLE = 18,
    }

    public enum virDomainConsoleFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_CONSOLE_FORCE = 1,
        @VIR_DOMAIN_CONSOLE_SAFE = 2,
    }

    public enum virDomainChannelFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_CHANNEL_FORCE = 1,
    }

    public enum virDomainOpenGraphicsFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_OPEN_GRAPHICS_SKIPAUTH = 1,
    }

    public enum virDomainSetTimeFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_TIME_SYNC = 1,
    }
    public enum virDomainSetUserPasswordFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_PASSWORD_ENCRYPTED = 1	//the password is already encrypted
    }
    public enum virSchedParameterType : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_SCHED_FIELD_INT = 1,
        @VIR_DOMAIN_SCHED_FIELD_UINT = 2,
        @VIR_DOMAIN_SCHED_FIELD_LLONG = 3,
        @VIR_DOMAIN_SCHED_FIELD_ULLONG = 4,
        @VIR_DOMAIN_SCHED_FIELD_DOUBLE = 5,
        @VIR_DOMAIN_SCHED_FIELD_BOOLEAN = 6,
    }

    public enum virBlkioParameterType : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_BLKIO_PARAM_INT = 1,
        @VIR_DOMAIN_BLKIO_PARAM_UINT = 2,
        @VIR_DOMAIN_BLKIO_PARAM_LLONG = 3,
        @VIR_DOMAIN_BLKIO_PARAM_ULLONG = 4,
        @VIR_DOMAIN_BLKIO_PARAM_DOUBLE = 5,
        @VIR_DOMAIN_BLKIO_PARAM_BOOLEAN = 6,
    }

    public enum virMemoryParameterType : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_MEMORY_PARAM_INT = 1,
        @VIR_DOMAIN_MEMORY_PARAM_UINT = 2,
        @VIR_DOMAIN_MEMORY_PARAM_LLONG = 3,
        @VIR_DOMAIN_MEMORY_PARAM_ULLONG = 4,
        @VIR_DOMAIN_MEMORY_PARAM_DOUBLE = 5,
        @VIR_DOMAIN_MEMORY_PARAM_BOOLEAN = 6,
    }

    public enum virDomainSnapshotCreateFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_SNAPSHOT_CREATE_REDEFINE = 1,
        @VIR_DOMAIN_SNAPSHOT_CREATE_CURRENT = 2,
        @VIR_DOMAIN_SNAPSHOT_CREATE_NO_METADATA = 4,
        @VIR_DOMAIN_SNAPSHOT_CREATE_HALT = 8,
        @VIR_DOMAIN_SNAPSHOT_CREATE_DISK_ONLY = 16,
        @VIR_DOMAIN_SNAPSHOT_CREATE_REUSE_EXT = 32,
        @VIR_DOMAIN_SNAPSHOT_CREATE_QUIESCE = 64,
        @VIR_DOMAIN_SNAPSHOT_CREATE_ATOMIC = 128,
        @VIR_DOMAIN_SNAPSHOT_CREATE_LIVE = 256,
    }

    public enum virDomainSnapshotListFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_SNAPSHOT_LIST_ROOTS = 1,
        @VIR_DOMAIN_SNAPSHOT_LIST_DESCENDANTS = 1,
        @VIR_DOMAIN_SNAPSHOT_LIST_LEAVES = 4,
        @VIR_DOMAIN_SNAPSHOT_LIST_NO_LEAVES = 8,
        @VIR_DOMAIN_SNAPSHOT_LIST_METADATA = 2,
        @VIR_DOMAIN_SNAPSHOT_LIST_NO_METADATA = 16,
        @VIR_DOMAIN_SNAPSHOT_LIST_INACTIVE = 32,
        @VIR_DOMAIN_SNAPSHOT_LIST_ACTIVE = 64,
        @VIR_DOMAIN_SNAPSHOT_LIST_DISK_ONLY = 128,
        @VIR_DOMAIN_SNAPSHOT_LIST_INTERNAL = 256,
        @VIR_DOMAIN_SNAPSHOT_LIST_EXTERNAL = 512,
    }

    public enum virDomainSnapshotRevertFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_SNAPSHOT_REVERT_RUNNING = 1,
        @VIR_DOMAIN_SNAPSHOT_REVERT_PAUSED = 2,
        @VIR_DOMAIN_SNAPSHOT_REVERT_FORCE = 4,
    }

    public enum virDomainSnapshotDeleteFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_DOMAIN_SNAPSHOT_DELETE_CHILDREN = 1,
        @VIR_DOMAIN_SNAPSHOT_DELETE_METADATA_ONLY = 2,
        @VIR_DOMAIN_SNAPSHOT_DELETE_CHILDREN_ONLY = 4,
    }

    public enum virEventHandleType : int
    {
        @VIR_DEFAULT = 0,
        @VIR_EVENT_HANDLE_READABLE = 1,
        @VIR_EVENT_HANDLE_WRITABLE = 2,
        @VIR_EVENT_HANDLE_ERROR = 4,
        @VIR_EVENT_HANDLE_HANGUP = 8,
    }

    public enum virConnectListAllInterfacesFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_CONNECT_LIST_INTERFACES_INACTIVE = 1,
        @VIR_CONNECT_LIST_INTERFACES_ACTIVE = 2,
    }

    public enum virInterfaceXMLFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_INTERFACE_XML_INACTIVE = 1,
    }

    public enum virNetworkXMLFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_NETWORK_XML_INACTIVE = 1,
    }

    public enum virConnectListAllNetworksFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_CONNECT_LIST_NETWORKS_INACTIVE = 1,
        @VIR_CONNECT_LIST_NETWORKS_ACTIVE = 2,
        @VIR_CONNECT_LIST_NETWORKS_PERSISTENT = 4,
        @VIR_CONNECT_LIST_NETWORKS_TRANSIENT = 8,
        @VIR_CONNECT_LIST_NETWORKS_AUTOSTART = 16,
        @VIR_CONNECT_LIST_NETWORKS_NO_AUTOSTART = 32,
    }

    public enum virNetworkUpdateCommand : uint
    {
        @VIR_NETWORK_UPDATE_COMMAND_NONE = 0,
        @VIR_NETWORK_UPDATE_COMMAND_MODIFY = 1,
        @VIR_NETWORK_UPDATE_COMMAND_DELETE = 2,
        @VIR_NETWORK_UPDATE_COMMAND_ADD_LAST = 3,
        @VIR_NETWORK_UPDATE_COMMAND_ADD_FIRST = 4,
    }

    public enum virNetworkUpdateSection : uint
    {
        @VIR_NETWORK_SECTION_NONE = 0,
        @VIR_NETWORK_SECTION_BRIDGE = 1,
        @VIR_NETWORK_SECTION_DOMAIN = 2,
        @VIR_NETWORK_SECTION_IP = 3,
        @VIR_NETWORK_SECTION_IP_DHCP_HOST = 4,
        @VIR_NETWORK_SECTION_IP_DHCP_RANGE = 5,
        @VIR_NETWORK_SECTION_FORWARD = 6,
        @VIR_NETWORK_SECTION_FORWARD_INTERFACE = 7,
        @VIR_NETWORK_SECTION_FORWARD_PF = 8,
        @VIR_NETWORK_SECTION_PORTGROUP = 9,
        @VIR_NETWORK_SECTION_DNS_HOST = 10,
        @VIR_NETWORK_SECTION_DNS_TXT = 11,
        @VIR_NETWORK_SECTION_DNS_SRV = 12,
    }

    public enum virNetworkUpdateFlags : uint
    {
        @VIR_NETWORK_UPDATE_AFFECT_CURRENT = 0,
        @VIR_NETWORK_UPDATE_AFFECT_LIVE = 1,
        @VIR_NETWORK_UPDATE_AFFECT_CONFIG = 2,
    }

    public enum virNetworkEventLifecycleType : uint
    {
        @VIR_NETWORK_EVENT_DEFINED = 0,
        @VIR_NETWORK_EVENT_UNDEFINED = 1,
        @VIR_NETWORK_EVENT_STARTED = 2,
        @VIR_NETWORK_EVENT_STOPPED = 3,
    }

    public enum virNetworkEventID : uint
    {
        @VIR_NETWORK_EVENT_ID_LIFECYCLE = 0,
    }

    public enum virIPAddrType : uint
    {
        @VIR_IP_ADDR_TYPE_IPV4 = 0,
        @VIR_IP_ADDR_TYPE_IPV6 = 1,
    }

    public enum virConnectListAllNodeDeviceFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_CONNECT_LIST_NODE_DEVICES_CAP_SYSTEM = 1,
        @VIR_CONNECT_LIST_NODE_DEVICES_CAP_PCI_DEV = 2,
        @VIR_CONNECT_LIST_NODE_DEVICES_CAP_USB_DEV = 4,
        @VIR_CONNECT_LIST_NODE_DEVICES_CAP_USB_INTERFACE = 8,
        @VIR_CONNECT_LIST_NODE_DEVICES_CAP_NET = 16,
        @VIR_CONNECT_LIST_NODE_DEVICES_CAP_SCSI_HOST = 32,
        @VIR_CONNECT_LIST_NODE_DEVICES_CAP_SCSI_TARGET = 64,
        @VIR_CONNECT_LIST_NODE_DEVICES_CAP_SCSI = 128,
        @VIR_CONNECT_LIST_NODE_DEVICES_CAP_STORAGE = 256,
        @VIR_CONNECT_LIST_NODE_DEVICES_CAP_FC_HOST = 512,
        @VIR_CONNECT_LIST_NODE_DEVICES_CAP_VPORTS = 1024,
        @VIR_CONNECT_LIST_NODE_DEVICES_CAP_SCSI_GENERIC = 2048,
    }

    public enum virSecretUsageType : uint
    {
        @VIR_SECRET_USAGE_TYPE_NONE = 0,
        @VIR_SECRET_USAGE_TYPE_VOLUME = 1,
        @VIR_SECRET_USAGE_TYPE_CEPH = 2,
        @VIR_SECRET_USAGE_TYPE_ISCSI = 3,
    }

    public enum virConnectListAllSecretsFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_CONNECT_LIST_SECRETS_EPHEMERAL = 1,
        @VIR_CONNECT_LIST_SECRETS_NO_EPHEMERAL = 2,
        @VIR_CONNECT_LIST_SECRETS_PRIVATE = 4,
        @VIR_CONNECT_LIST_SECRETS_NO_PRIVATE = 8,
    }

    public enum virStoragePoolState : uint
    {
        @VIR_STORAGE_POOL_INACTIVE = 0,
        @VIR_STORAGE_POOL_BUILDING = 1,
        @VIR_STORAGE_POOL_RUNNING = 2,
        @VIR_STORAGE_POOL_DEGRADED = 3,
        @VIR_STORAGE_POOL_INACCESSIBLE = 4,
    }

    public enum virStoragePoolBuildFlags : uint
    {
        @VIR_STORAGE_POOL_BUILD_NEW = 0,
        @VIR_STORAGE_POOL_BUILD_REPAIR = 1,
        @VIR_STORAGE_POOL_BUILD_RESIZE = 2,
        @VIR_STORAGE_POOL_BUILD_NO_OVERWRITE = 4,
        @VIR_STORAGE_POOL_BUILD_OVERWRITE = 8,
    }

    public enum virStoragePoolDeleteFlags : uint
    {
        @VIR_STORAGE_POOL_DELETE_NORMAL = 0,
        @VIR_STORAGE_POOL_DELETE_ZEROED = 1,
    }

    public enum virStorageVolType : uint
    {
        @VIR_STORAGE_VOL_FILE = 0,
        @VIR_STORAGE_VOL_BLOCK = 1,
        @VIR_STORAGE_VOL_DIR = 2,
        @VIR_STORAGE_VOL_NETWORK = 3,
        @VIR_STORAGE_VOL_NETDIR = 4,
    }

    public enum virStorageVolDeleteFlags : uint
    {
        @VIR_STORAGE_VOL_DELETE_NORMAL = 0,
        @VIR_STORAGE_VOL_DELETE_ZEROED = 1,
    }

    public enum virStorageVolWipeAlgorithm : uint
    {
        @VIR_STORAGE_VOL_WIPE_ALG_ZERO = 0,
        @VIR_STORAGE_VOL_WIPE_ALG_NNSA = 1,
        @VIR_STORAGE_VOL_WIPE_ALG_DOD = 2,
        @VIR_STORAGE_VOL_WIPE_ALG_BSI = 3,
        @VIR_STORAGE_VOL_WIPE_ALG_GUTMANN = 4,
        @VIR_STORAGE_VOL_WIPE_ALG_SCHNEIER = 5,
        @VIR_STORAGE_VOL_WIPE_ALG_PFITZNER7 = 6,
        @VIR_STORAGE_VOL_WIPE_ALG_PFITZNER33 = 7,
        @VIR_STORAGE_VOL_WIPE_ALG_RANDOM = 8,
    }

    public enum virStorageXMLFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_STORAGE_XML_INACTIVE = 1,
    }

    public enum virConnectListAllStoragePoolsFlags : uint
    {
        @VIR_CONNECT_LIST_STORAGE_POOLS_DEFAULT = 0,
        @VIR_CONNECT_LIST_STORAGE_POOLS_INACTIVE = 1,
        @VIR_CONNECT_LIST_STORAGE_POOLS_ACTIVE = 2,
        @VIR_CONNECT_LIST_STORAGE_POOLS_PERSISTENT = 4,
        @VIR_CONNECT_LIST_STORAGE_POOLS_TRANSIENT = 8,
        @VIR_CONNECT_LIST_STORAGE_POOLS_AUTOSTART = 16,
        @VIR_CONNECT_LIST_STORAGE_POOLS_NO_AUTOSTART = 32,
        @VIR_CONNECT_LIST_STORAGE_POOLS_DIR = 64,
        @VIR_CONNECT_LIST_STORAGE_POOLS_FS = 128,
        @VIR_CONNECT_LIST_STORAGE_POOLS_NETFS = 256,
        @VIR_CONNECT_LIST_STORAGE_POOLS_LOGICAL = 512,
        @VIR_CONNECT_LIST_STORAGE_POOLS_DISK = 1024,
        @VIR_CONNECT_LIST_STORAGE_POOLS_ISCSI = 2048,
        @VIR_CONNECT_LIST_STORAGE_POOLS_SCSI = 4096,
        @VIR_CONNECT_LIST_STORAGE_POOLS_MPATH = 8192,
        @VIR_CONNECT_LIST_STORAGE_POOLS_RBD = 16384,
        @VIR_CONNECT_LIST_STORAGE_POOLS_SHEEPDOG = 32768,
        @VIR_CONNECT_LIST_STORAGE_POOLS_GLUSTER = 65536,
        @VIR_CONNECT_LIST_STORAGE_POOLS_ZFS = 131072,
    }

    public enum virStorageVolCreateFlags : uint
    {
        @VIR_DEFAULT = 0,//use this for regular storage creation
        @VIR_STORAGE_VOL_CREATE_PREALLOC_METADATA = 1,
        @VIR_STORAGE_VOL_CREATE_REFLINK = 2,
    }

    public enum virStorageVolResizeFlags : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_STORAGE_VOL_RESIZE_ALLOCATE = 1,
        @VIR_STORAGE_VOL_RESIZE_DELTA = 2,
        @VIR_STORAGE_VOL_RESIZE_SHRINK = 4,
    }

    public enum virStreamFlags : uint
    {
        @VIR_STREAM_BLOCK = 0,
        @VIR_STREAM_NONBLOCK = 1,
    }

    public enum virStreamEventType : uint
    {
        @VIR_DEFAULT = 0,
        @VIR_STREAM_EVENT_READABLE = 1,
        @VIR_STREAM_EVENT_WRITABLE = 2,
        @VIR_STREAM_EVENT_ERROR = 4,
        @VIR_STREAM_EVENT_HANGUP = 8,
    }
    public static class API
    {
        public static readonly int MaxStringLength = 1024;
        public static readonly int VIR_UUID_BUFLEN = 16;
        public static readonly int VIR_UUID_STRING_BUFLEN = 37;
        public static virFreeCallback _Dummy_virFreeCallback;//dummy variable to prevent the GC from collecting the function
        static API()
        {
            _Dummy_virFreeCallback = DummyvirFreeCallback_Func;//will be assigned once on first static function call
        }
        public static string[] ptrToStringArray(IntPtr stringPtr, int stringCount, Action<IntPtr> func)
        {
            string[] members = new string[stringCount];
            for (int i = 0; i < stringCount; ++i)
            {
                IntPtr s = Marshal.ReadIntPtr(stringPtr, i * IntPtr.Size);
                members[i] = Marshal.PtrToStringAnsi(s);
                func(s);
            }
            return members;
        }
        public static virTypedParameter[] MarshalvirTypedParameters(_virTypedParameter[] inpars, int nparms)
        {
            if (inpars == null) return new virTypedParameter[0];
            if (inpars.Length == 0) return new virTypedParameter[0];
            if (nparms <= 0) return new virTypedParameter[0];
            virTypedParameter[] ret = null;
            if (nparms == inpars.Length) ret = new virTypedParameter[inpars.Length];
            else ret = new virTypedParameter[nparms];
            for (var i = 0; i < ret.Length; i++)
            {
                ret[i] = new virTypedParameter();
                ret[i].field = inpars[i].field;
                ret[i].type = inpars[i].type;
                ret[i].b = inpars[i].b;
                ret[i].d = inpars[i].d;
                ret[i].i = inpars[i].i;
                ret[i].l = inpars[i].l;
                ret[i].ui = inpars[i].ui;
                ret[i].ul = inpars[i].ul;
                if (inpars[i].type == virTypedParameterType.VIR_TYPED_PARAM_STRING)
                {
                    ret[i].s = Marshal.PtrToStringAnsi(inpars[i].s);
                    PInvoke.free(inpars[i].s);
                }
            }
            return ret;
        }
        public static void DummyvirFreeCallback_Func(IntPtr dummy)
        {

        }
        public static int NameArrayHandler(virConnectPtr conn, out string[] @names, int @maxnames, Func<virConnectPtr, IntPtr, int, int> func)
        {
            IntPtr namesPtr = Marshal.AllocHGlobal(MaxStringLength);
            int count = func(conn, namesPtr, maxnames);
            if (count > 0)
                names = ptrToStringArray(namesPtr, count, a => { PInvoke.free(a); });
            else
            {
                names = new string[0];
            }
            Marshal.FreeHGlobal(namesPtr);
            return count;
        }
        public static int NameArrayHandler(virStoragePoolPtr conn, out string[] @names, int @maxnames, Func<virStoragePoolPtr, IntPtr, int, int> func)
        {
            IntPtr namesPtr = Marshal.AllocHGlobal(MaxStringLength);
            int count = func(conn, namesPtr, maxnames);
            if (count > 0)
                names = ptrToStringArray(namesPtr, count, a => { PInvoke.free(a); });
            else
            {
                names = new string[0];
            }
            Marshal.FreeHGlobal(namesPtr);
            return count;
        }
        public static bool IsBitSet(byte b, int pos)
        {
            return (b & (1 << pos)) != 0;
        }
        public static virError MarshalErrorPtr(virErrorPtr ptr)
        {
            if (ptr.Pointer == IntPtr.Zero)
                return new virError();
            var olderr = (_virError)Marshal.PtrToStructure(ptr.Pointer, typeof(_virError));
            var nerror = new virError();
            nerror.code = olderr.code;
            nerror.domain = olderr.domain;
            nerror.message = Marshal.PtrToStringAnsi(olderr.message);
            nerror.level = olderr.level;
            nerror.str1 = Marshal.PtrToStringAnsi(olderr.str1);
            nerror.str2 = Marshal.PtrToStringAnsi(olderr.str2);
            nerror.str3 = Marshal.PtrToStringAnsi(olderr.str3);
            nerror.int1 = olderr.int1;
            nerror.int2 = olderr.int2;
            return nerror;
        }
        public static string virConnectBaselineCPU(virConnectPtr conn, string[] xmlCPUs, uint ncpus, virConnectBaselineCPUFlags flags)
        {
            return PInvoke.virConnectBaselineCPU(conn, xmlCPUs, ncpus, (uint)flags);
        }

        public static int virConnectClose(virConnectPtr @conn)
        {
            return PInvoke.virConnectClose(@conn);
        }
        public static int virConnectCompareCPU(virConnectPtr @conn, out string @xmlDesc, virConnectCompareCPUFlags @flags)
        {
            return PInvoke.virConnectCompareCPU(@conn, out @xmlDesc, (uint)@flags);
        }
        public static int virConnectGetCPUModelNames(virConnectPtr conn, string arch, out string[] models, uint flags = 0)
        {
            throw new NotImplementedException();

        }

        public static string virConnectGetCapabilities(virConnectPtr @conn)
        {
            return PInvoke.virConnectGetCapabilities(conn);
        }
        public static string virConnectGetHostname(virConnectPtr @conn)
        {
            return PInvoke.virConnectGetHostname(conn);
        }

        public static int virConnectGetLibVersion(virConnectPtr @conn, out uint libVer)
        {
            libVer = 0;
            return PInvoke.virConnectGetLibVersion(conn, ref libVer);
        }
        public static int virConnectGetMaxVcpus(virConnectPtr conn, string type)
        {
            return PInvoke.virConnectGetMaxVcpus(conn, type);
        }

        public static string virConnectGetSysinfo(virConnectPtr @conn, uint @flags = 0)
        {
            return PInvoke.virConnectGetSysinfo(@conn, @flags);
        }
        public static string virConnectGetType(virConnectPtr @conn)
        {
            return PInvoke.virConnectGetType(@conn);
        }
        public static string virConnectGetURI(virConnectPtr @conn)
        {
            return PInvoke.virConnectGetURI(conn);
        }
        public static int virConnectGetVersion(virConnectPtr @conn, ref int @hvVer)
        {
            @hvVer = 0;
            return PInvoke.virConnectGetVersion(conn, ref @hvVer);
        }
        public static int virConnectIsAlive(virConnectPtr @conn)
        {
            return PInvoke.virConnectIsAlive(conn);
        }
        public static int virConnectIsEncrypted(virConnectPtr @conn)
        {
            return PInvoke.virConnectIsEncrypted(conn);
        }

        public static int virConnectIsSecure(virConnectPtr @conn)
        {
            return PInvoke.virConnectIsSecure(conn);
        }

        public static virConnectPtr virConnectOpen(string @name)
        {
            return PInvoke.virConnectOpen(name);
        }
        public static virConnectPtr virConnectOpenReadOnly(string @name)
        {
            return PInvoke.virConnectOpenReadOnly(name); 
        }
        public static virConnectPtr virConnectOpenAuth(string @name, _virConnectAuth @auth, virConnectFlags @flags)
        {
            return PInvoke.virConnectOpenAuth(@name, @auth, (uint)@flags);
        }
        public static int virConnectRef(virConnectPtr @conn)
        {
            return PInvoke.virConnectRef(@conn);
        }
        public static int virConnectRegisterCloseCallback(virConnectPtr conn, virConnectCloseFunc cb, IntPtr opaque, virFreeCallback freecb)
        {
            return PInvoke.virConnectRegisterCloseCallback(conn, cb, opaque, freecb);
        }
        public static int virConnectSetKeepAlive(virConnectPtr conn, int interval, uint count)
        {
            return PInvoke.virConnectSetKeepAlive(conn, interval, count);
        }
        public static int virConnectUnregisterCloseCallback(virConnectPtr conn, virConnectCloseFunc cb)
        {
            return PInvoke.virConnectUnregisterCloseCallback(conn, cb);
        }
        public static int virGetVersion(ref uint[] libVer, string type = null, uint[] typeVer = null)
        {
            return PInvoke.virGetVersion(ref libVer, type, ref typeVer);
        }
        public static int virNodeAllocPages(virConnectPtr conn, uint npages, uint[] pageSizes, ulong[] pageCounts, int startCell, uint cellCount, virNodeAllocPagesFlags flags)
        {
            Debug.Assert(pageSizes.Length == pageCounts.Length && pageSizes.Length == npages);
            return PInvoke.virNodeAllocPages(conn, npages, pageSizes, pageCounts, startCell, cellCount, (uint)flags);

        }
        public static int virNodeGetCPUMap(virConnectPtr @conn, out bool[] cpumap, out int cpucount, uint flags = 0)
        {
            IntPtr cpumapptr = IntPtr.Zero;
            cpucount = 0;
            var succ = PInvoke.virNodeGetCPUMap(@conn, ref cpumapptr, ref cpucount, 0);
            var slots = (cpucount / 8);
            if (slots * 8 != cpucount)
                slots += 1;
            var by = new byte[slots];
            Marshal.Copy(cpumapptr, by, 0, slots);
            cpumap = new bool[slots];
            for (var i = 0; i < cpucount; i++)
            {
                var bytepos = i / 8;
                var outarrpos = i - (bytepos * 8);
                cpumap[outarrpos] = IsBitSet(by[bytepos], outarrpos);
            }
            PInvoke.free(cpumapptr);
            return succ;

        }
        public static int virNodeGetCPUStats(virConnectPtr @conn, int @cpuNum /*-1 for all cpus on host */, out _virNodeCPUStats[] @params, int @nparams, uint @flags = 0)
        {
            //allocate enough space for all cpus
            if (cpuNum == (int)virNodeGetCPUStatsAllCPUs.VIR_NODE_CPU_STATS_ALL_CPUS)
            {
                @nparams = 0;//just in case
                if (PInvoke.virNodeGetCPUStats(@conn, @cpuNum, IntPtr.Zero, ref @nparams, 0) == -1)
                    @nparams = 0;

            }
            else if (@cpuNum > 0)
            {
                @nparams = 1;
            }
            else
            {
                @nparams = 0;
            }
            if (@nparams > 0)
            {
                @params = new _virNodeCPUStats[@nparams];
                return PInvoke.virNodeGetCPUStats(@conn, @cpuNum, @params, ref @nparams, 0);
            }
            else
            {
                @params = new _virNodeCPUStats[0];
                return -1;
            }
        }
        public static int virNodeGetCellsFreeMemory(virConnectPtr conn, ulong[] freeMems, int startCell, int maxCells)
        {
            return PInvoke.virNodeGetCellsFreeMemory(conn, freeMems, startCell, maxCells);
        }
        public static ulong virNodeGetFreeMemory(virConnectPtr @conn)
        {
            return PInvoke.virNodeGetFreeMemory(conn);
        }
        public static int virNodeGetFreePages(virConnectPtr conn, uint npages, uint[] pages, int startCell, uint cellCount, ulong[] counts, uint flags = 0)
        {
            return PInvoke.virNodeGetFreePages(conn, npages, pages, startCell, cellCount, counts, flags);
        }

        public static int virNodeGetInfo(virConnectPtr @conn, out _virNodeInfo @info)
        {
            @info = new _virNodeInfo();
            return PInvoke.virNodeGetInfo(@conn, ref info);
        }




        public static int virNodeGetMemoryParameters(virConnectPtr conn, out virTypedParameter[] pars, ref int nparams, uint flags = 0)
        {
            nparams = 0;
            var ret = PInvoke.virNodeGetMemoryParameters(conn, IntPtr.Zero, ref nparams, flags);
            _virTypedParameter[] outpars = null;
            if (nparams > 0)
            {
                outpars = new _virTypedParameter[nparams];
                ret = PInvoke.virNodeGetMemoryParameters(conn, outpars, ref nparams, flags);
            }
            else
            {
                nparams = 0;
            }
            pars = MarshalvirTypedParameters(outpars, nparams);
            return ret;
        }
        public static int virNodeGetMemoryStats(virConnectPtr @conn, int @cellNum/*-1 for all memory info on host */, out _virNodeMemoryStats[] @params, ref int @nparams, uint @flags = 0)
        {
            if (@cellNum == (int)virNodeGetMemoryStatsAllCells.VIR_NODE_MEMORY_STATS_ALL_CELLS)
            {
                @nparams = 0;//just in case
                if (PInvoke.virNodeGetMemoryStats(@conn, @cellNum, IntPtr.Zero, ref @nparams, 0) == -1)
                    @nparams = 0;

            }
            else if (@cellNum > 0)
            {
                @nparams = 1;

            }
            else
            {
                @nparams = 0;
            }

            if (@nparams > 0)
            {
                @params = new _virNodeMemoryStats[@nparams];
                return PInvoke.virNodeGetMemoryStats(@conn, @cellNum, @params, ref @nparams, 0);
            }
            else
            {
                @params = new _virNodeMemoryStats[0];
                return -1;
            }
        }
        public static int virNodeGetSecurityModel(virConnectPtr conn, out _virSecurityModel secmodel)
        {
            secmodel = new _virSecurityModel();
            return PInvoke.virNodeGetSecurityModel(conn, ref secmodel);
        }
        public static int virNodeSetMemoryParameters(virConnectPtr conn, _virTypedParameter[] pars, int nparams, uint flags = 0)
        {
            return PInvoke.virNodeSetMemoryParameters(conn, pars, nparams, flags);
        }
        public static int virNodeSuspendForDuration(virConnectPtr conn, uint target, ulong duration, uint flags = 0)
        {
            return PInvoke.virNodeSuspendForDuration(conn, target, duration, flags);
        }



        //INTERFACES

        public static int virConnectListAllInterfaces(virConnectPtr conn, out virInterfacePtr[] ifaces, virConnectListAllInterfacesFlags flags)
        {
            IntPtr faces = IntPtr.Zero;
            var ret = PInvoke.virConnectListAllInterfaces(conn, ref faces, (uint)flags);
            if (ret > -1)
            {
                ifaces = new virInterfacePtr[ret];
                for (var i = 0; i < ret; i++)
                {
                    ifaces[i] = new virInterfacePtr();
                    ifaces[i].Pointer = Marshal.ReadIntPtr(faces, i * IntPtr.Size);
                }
            }
            else
            {
                ifaces = new virInterfacePtr[0];
            }
            return ret;
        }

        public static int virConnectListDefinedInterfaces(virConnectPtr @conn, out string[] @names, int @maxnames)
        {
            return NameArrayHandler(conn, out @names, @maxnames, PInvoke.virConnectListDefinedInterfaces);
        }
        public static int virConnectListInterfaces(virConnectPtr @conn, out string[] @names, int @maxnames)
        {
            return NameArrayHandler(conn, out @names, @maxnames, PInvoke.virConnectListInterfaces);
        }

        public static int virConnectNumOfDefinedInterfaces(virConnectPtr conn)
        {
            return PInvoke.virConnectNumOfDefinedInterfaces(conn);
        }
        public static int virConnectNumOfInterfaces(virConnectPtr conn)
        {
            return PInvoke.virConnectNumOfInterfaces(conn);
        }
        public static int virInterfaceChangeBegin(virConnectPtr @conn, uint @flags = 0)
        {
            return PInvoke.virInterfaceChangeBegin(@conn, @flags);
        }

        public static int virInterfaceChangeCommit(virConnectPtr @conn, uint @flags = 0)
        {
            return PInvoke.virInterfaceChangeCommit(@conn, @flags);
        }
        public static int virInterfaceChangeRollback(virConnectPtr @conn, uint @flags = 0)
        {
            return PInvoke.virInterfaceChangeRollback(@conn, @flags);
        }
        public static int virInterfaceCreate(virInterfacePtr @iface, uint @flags = 0)
        {
            return PInvoke.virInterfaceCreate(@iface, @flags);
        }

        public static virInterfacePtr virInterfaceDefineXML(virConnectPtr conn, string xml, uint flags = 0)
        {
            return PInvoke.virInterfaceDefineXML(conn, xml, flags);
        }
        public static int virInterfaceDestroy(virInterfacePtr @iface, uint @flags = 0)
        {
            return PInvoke.virInterfaceDestroy(@iface, @flags);
        }

        public static int virInterfaceFree(virInterfacePtr @iface)
        {
            return PInvoke.virInterfaceFree(@iface);
        }

        public static string virInterfaceGetMACString(virInterfacePtr @iface)
        {
            return PInvoke.virInterfaceGetMACString(@iface);
        }
        public static string virInterfaceGetName(virInterfacePtr @iface)
        {
            return PInvoke.virInterfaceGetName(@iface);
        }
        public static string virInterfaceGetXMLDesc(virInterfacePtr @iface, virInterfaceXMLFlags @flags)
        {
            return PInvoke.virInterfaceGetXMLDesc(@iface, (uint)@flags);
        }
        public static int virInterfaceIsActive(virInterfacePtr @iface)
        {
            return PInvoke.virInterfaceIsActive(@iface);
        }
        public static virInterfacePtr virInterfaceLookupByMACString(virConnectPtr @conn, string @mac)
        {
            return PInvoke.virInterfaceLookupByMACString(@conn, @mac);
        }
        public static virInterfacePtr virInterfaceLookupByName(virConnectPtr @conn, string @name)
        {
            return PInvoke.virInterfaceLookupByName(@conn, @name);
        }
        public static int virInterfaceUndefine(virInterfacePtr @conn)
        {
            return PInvoke.virInterfaceUndefine(@conn);
        }

        ///////STORAGE
        public static string virConnectFindStoragePoolSources(virConnectPtr conn, string type, string srcSpec, uint flags = 0)
        {
            return PInvoke.virConnectFindStoragePoolSources(conn, type, srcSpec, flags);
        }

        public static int virConnectListAllStoragePools(virConnectPtr @conn, out virStoragePoolPtr[] @pools, virConnectListAllStoragePoolsFlags @flags)
        {
            var ptr = IntPtr.Zero;
            var numofpools = PInvoke.virConnectListAllStoragePools(@conn, out ptr, (uint)@flags);
            if (numofpools > 0)
            {
                pools = new virStoragePoolPtr[numofpools];
                for (var i = 0; i < numofpools; i++)
                {
                    pools[i].Pointer = Marshal.ReadIntPtr(ptr, i * IntPtr.Size);
                }
                PInvoke.free(ptr);//free the array
            }
            else
            {
                pools = new virStoragePoolPtr[0];
            }
            return numofpools;
        }
        public static int virConnectListDefinedStoragePools(virConnectPtr @conn, out string[] @names, int @maxnames)
        {
            return NameArrayHandler(conn, out @names, @maxnames, PInvoke.virConnectListDefinedStoragePools);
        }
        public static int virConnectListStoragePools(virConnectPtr @conn, out string[] @names, int @maxnames)
        {
            return NameArrayHandler(conn, out @names, @maxnames, PInvoke.virConnectListStoragePools);
        }
        public static int virConnectNumOfDefinedStoragePools(virConnectPtr @conn)
        {
            return PInvoke.virConnectNumOfDefinedStoragePools(@conn);
        }
        public static int virConnectNumOfStoragePools(virConnectPtr @conn)
        {
            return PInvoke.virConnectNumOfStoragePools(@conn);
        }
        public static int virStoragePoolBuild(virStoragePoolPtr @conn, virStoragePoolBuildFlags @flags)
        {
            return PInvoke.virStoragePoolBuild(@conn, (uint)@flags);
        }
        public static int virStoragePoolCreate(virStoragePoolPtr @conn, uint @flags = 0)
        {
            return PInvoke.virStoragePoolCreate(@conn, @flags);
        }
        public static virStoragePoolPtr virStoragePoolCreateXML(virConnectPtr @conn, string xmldesc, uint @flags = 0)
        {
            return PInvoke.virStoragePoolCreateXML(@conn, xmldesc, @flags);
        }
        public static virStoragePoolPtr virStoragePoolDefineXML(virConnectPtr @conn, string xmldesc, uint @flags = 0)
        {
            return PInvoke.virStoragePoolDefineXML(@conn, xmldesc, @flags);
        }
        public static int virStoragePoolDelete(virStoragePoolPtr @conn, virStoragePoolDeleteFlags @flags)
        {
            return PInvoke.virStoragePoolDelete(@conn, (uint)@flags);
        }
        public static int virStoragePoolDestroy(virStoragePoolPtr @conn)
        {
            return PInvoke.virStoragePoolDestroy(@conn);
        }
        public static int virStoragePoolFree(virStoragePoolPtr @conn)
        {
            return PInvoke.virStoragePoolFree(@conn);
        }
        public static int virStoragePoolGetAutostart(virStoragePoolPtr @conn, out int autostart)
        {
            autostart = 0;
            return PInvoke.virStoragePoolGetAutostart(@conn, ref autostart);
        }
        public static int virStoragePoolGetInfo(virStoragePoolPtr @conn, out _virStoragePoolInfo info)
        {
            info = new _virStoragePoolInfo();
            return PInvoke.virStoragePoolGetInfo(@conn, ref info);
        }
        public static string virStoragePoolGetName(virStoragePoolPtr @conn)
        {
            return PInvoke.virStoragePoolGetName(@conn);
        }
        public static int virStoragePoolGetUUID(virStoragePoolPtr @conn, out byte[] uuid)
        {
            uuid = new byte[VIR_UUID_BUFLEN];
            return PInvoke.virStoragePoolGetUUID(@conn, uuid);
        }
        public static int virStoragePoolGetUUIDString(virStoragePoolPtr @conn, out string uuid)
        {
            var bytes = new byte[VIR_UUID_BUFLEN];
            var rret = PInvoke.virStoragePoolGetUUIDString(@conn, bytes);
            uuid = System.Text.Encoding.UTF8.GetString(bytes);
            return rret;
        }
        public static string virStoragePoolGetXMLDesc(virStoragePoolPtr @iface, virStorageXMLFlags @flags)
        {
            return PInvoke.virStoragePoolGetXMLDesc(@iface, (uint)@flags);
        }
        public static int virStoragePoolIsActive(virStoragePoolPtr @iface)
        {
            return PInvoke.virStoragePoolIsActive(@iface);
        }
        public static int virStoragePoolIsPersistent(virStoragePoolPtr @iface)
        {
            return PInvoke.virStoragePoolIsPersistent(@iface);
        }
        public static int virStoragePoolListAllVolumes(virStoragePoolPtr @conn, out virStorageVolPtr[] @vols, uint @flags = 0)
        {
            var ptr = IntPtr.Zero;
            var numofvols = PInvoke.virStoragePoolListAllVolumes(@conn, out ptr, @flags);
            if (numofvols > 0)
            {
                @vols = new virStorageVolPtr[numofvols];
                for (var i = 0; i < numofvols; i++)
                {
                    @vols[i].Pointer = Marshal.ReadIntPtr(ptr, i * IntPtr.Size);
                }
                PInvoke.free(ptr);//free the array
            }
            else
            {
                @vols = new virStorageVolPtr[0];
            }
            return numofvols;
        }
        public static int virStoragePoolListVolumes(virStoragePoolPtr pool, out string[] names, int maxnames)
        {
            return NameArrayHandler(pool, out names, maxnames, PInvoke.virStoragePoolListVolumes);
        }

        public static virStoragePoolPtr virStoragePoolLookupByName(virConnectPtr @conn, string @name)
        {
            return PInvoke.virStoragePoolLookupByName(@conn, @name);
        }
        public static virStoragePoolPtr virStoragePoolLookupByUUID(virConnectPtr @conn, byte[] uuid)
        {
            return PInvoke.virStoragePoolLookupByUUID(@conn, uuid);
        }
        public static virStoragePoolPtr virStoragePoolLookupByUUIDString(virConnectPtr @conn, string uuid)
        {
            return PInvoke.virStoragePoolLookupByUUIDString(@conn, uuid);
        }
        public static virStoragePoolPtr virStoragePoolLookupByVolume(virStorageVolPtr @conn)
        {
            return PInvoke.virStoragePoolLookupByVolume(@conn);
        }
        public static int virStoragePoolNumOfVolumes(virStoragePoolPtr @conn)
        {
            return PInvoke.virStoragePoolNumOfVolumes(@conn);
        }
        public static int virStoragePoolRef(virStoragePoolPtr @conn)
        {
            return PInvoke.virStoragePoolRef(@conn);
        }
        public static int virStoragePoolRefresh(virStoragePoolPtr @conn, uint flags = 0)
        {
            return PInvoke.virStoragePoolRefresh(@conn, flags);
        }
        public static int virStoragePoolSetAutostart(virStoragePoolPtr @conn, int autostart)
        {
            return PInvoke.virStoragePoolSetAutostart(@conn, autostart);
        }
        public static int virStoragePoolUndefine(virStoragePoolPtr @conn)
        {
            return PInvoke.virStoragePoolUndefine(@conn);
        }
        public static virStorageVolPtr virStorageVolCreateXML(virStoragePoolPtr @pool, string @xmldesc, virStorageVolCreateFlags @flags)
        {
            return PInvoke.virStorageVolCreateXML(@pool, @xmldesc, (uint)@flags);
        }
        public static virStorageVolPtr virStorageVolCreateXMLFrom(virStoragePoolPtr @pool, string @xmldesc, virStorageVolPtr clonevol, virStorageVolCreateFlags @flags)
        {
            return PInvoke.virStorageVolCreateXMLFrom(@pool, @xmldesc, clonevol, (uint)@flags);
        }

        public static int virStorageVolDelete(virStorageVolPtr @conn, uint flags = 0)
        {
            return PInvoke.virStorageVolDelete(@conn, flags);
        }
        public static int virStorageVolDownload(virStorageVolPtr vol, virStreamPtr stream, ulong offset, ulong length, uint flags = 0)
        {
            return PInvoke.virStorageVolDownload(vol, stream, offset, length, flags);
        }



        public static int virStorageVolFree(virStorageVolPtr @conn)
        {
            return PInvoke.virStorageVolFree(@conn);
        }
        public static int virStorageVolGetInfo(virStorageVolPtr @conn, out _virStorageVolInfo info)
        {
            info = new _virStorageVolInfo();
            return PInvoke.virStorageVolGetInfo(@conn, ref info);
        }
        public static string virStorageVolGetKey(virStorageVolPtr @conn)
        {
            return PInvoke.virStorageVolGetKey(@conn);
        }
        public static string virStorageVolGetName(virStorageVolPtr @conn)
        {
            return PInvoke.virStorageVolGetName(@conn);
        }
        public static string virStorageVolGetPath(virStorageVolPtr @conn)
        {
            return PInvoke.virStorageVolGetPath(@conn);
        }

        public static string virStorageVolGetXMLDesc(virStorageVolPtr @conn, uint flags = 0)
        {
            return PInvoke.virStorageVolGetXMLDesc(@conn, flags);
        }
        public static virStorageVolPtr virStorageVolLookupByKey(virConnectPtr @conn, string key)
        {
            return PInvoke.virStorageVolLookupByKey(@conn, key);
        }
        public static virStorageVolPtr virStorageVolLookupByName(virStoragePoolPtr @conn, string name)
        {
            return PInvoke.virStorageVolLookupByName(@conn, name);
        }
        public static virStorageVolPtr virStorageVolLookupByPath(virConnectPtr @conn, string path)
        {
            return PInvoke.virStorageVolLookupByPath(@conn, path);
        }
        public static int virStorageVolRef(virStorageVolPtr @conn)
        {
            return PInvoke.virStorageVolRef(@conn);
        }
        public static int virStorageVolResize(virStorageVolPtr @conn, ulong @capacity, virStorageVolResizeFlags @flags)
        {
            return PInvoke.virStorageVolResize(@conn, @capacity, (uint)@flags);
        }
        public static int virStorageVolUpload(virStorageVolPtr @vol, virStreamPtr @stream, ulong @offset, ulong @length, uint @flags = 0)
        {
            return PInvoke.virStorageVolUpload(@vol, @stream, @offset, @length, @flags);
        }

   
        public static int virStorageVolWipe(virStorageVolPtr @conn, uint flags = 0)
        {
            return PInvoke.virStorageVolWipe(@conn, flags);
        }
        public static int virStorageVolWipePattern(virStorageVolPtr @conn, virStorageVolWipeAlgorithm @algorithm, uint @flags = 0)
        {
            return PInvoke.virStorageVolWipePattern(@conn, (uint)@algorithm, flags);
        }
        /////////STREAM


        public static int virStreamAbort(virStreamPtr stream)
        {
            return PInvoke.virStreamAbort(stream);
        }

        public static int virStreamEventAddCallback(virStreamPtr stream, int events, virStreamEventCallback cb, IntPtr opaque, virFreeCallback ff)
        {
            return PInvoke.virStreamEventAddCallback(stream, events, cb, opaque, ff);
        }
        public static int virStreamEventRemoveCallback(virStreamPtr stream)
        {
            return PInvoke.virStreamEventRemoveCallback(stream);
        }
        public static int virStreamEventUpdateCallback(virStreamPtr stream, int events)
        {
            return PInvoke.virStreamEventUpdateCallback(stream, events);
        }

        public static int virStreamFinish(virStreamPtr stream)
        {
            return PInvoke.virStreamFinish(stream);
        }
        public static int virStreamFree(virStreamPtr stream)
        {
            return PInvoke.virStreamFree(stream);
        }
        public static virStreamPtr virStreamNew(virConnectPtr conn, virStreamFlags flags)
        {
            return PInvoke.virStreamNew(conn, (uint)flags);
        }
        public static int virStreamRecv(virStreamPtr @st, byte[] @data, UIntPtr @nbytes)
        {
            return PInvoke.virStreamRecv(@st, @data, @nbytes);
        }
        public static int virStreamRecvAll(virStreamPtr @st, virStreamSinkFunc handler)
        {
            return PInvoke.virStreamRecvAll(@st, handler, IntPtr.Zero);
        }


        public static int virStreamSend(virStreamPtr @st, byte[] @data, UIntPtr @nbytes)
        {
            return PInvoke.virStreamSend(@st, @data, @nbytes);
        }
        public static int virStreamSendAll(virStreamPtr @st, virStreamSourceFunc handler)
        {
            return PInvoke.virStreamSendAll(@st, handler, IntPtr.Zero);
        }


        //ERROR

        public static int virConnCopyLastError(virConnectPtr @conn, out virError newerror)
        {
            var errorptr = new virErrorPtr();
            var ret = PInvoke.virConnCopyLastError(@conn, errorptr);
            newerror = MarshalErrorPtr(errorptr);
            PInvoke.virResetError(errorptr);
            return ret;
        }

        public static virError virConnGetLastError(virConnectPtr @conn)
        {
            return MarshalErrorPtr(PInvoke.virConnGetLastError(@conn));
        }
        public static void virConnResetLastError(virConnectPtr @conn)
        {
            PInvoke.virConnResetLastError(@conn);
        }
        public static void virConnSetErrorFunc(virConnectPtr @conn, IntPtr userData, virErrorFunc handler)
        {
            PInvoke.virConnSetErrorFunc(@conn, userData, handler);
        }
        public static int virCopyLastError(out virError toptr)
        {
            var newerror = new virErrorPtr();
            var ret = PInvoke.virCopyLastError(newerror);
            toptr = MarshalErrorPtr(newerror);
            PInvoke.virResetError(newerror);
            return ret;
        }
        public static void virDefaultErrorFunc(virErrorPtr err)
        {
            PInvoke.virDefaultErrorFunc(err);
        }
        public static void virFreeError(virErrorPtr err)
        {
            PInvoke.virFreeError(err);
        }
        public static virError virGetLastError()
        {
            return MarshalErrorPtr(PInvoke.virGetLastError());
        }
        public static string virGetLastErrorMessage()
        {
            return PInvoke.virGetLastErrorMessage();
        }
        public static void virResetError(virErrorPtr err)
        {
            PInvoke.virResetError(err);
        }
        public static void virResetLastError()
        {
            PInvoke.virResetLastError();
        }
        public static virErrorPtr virSaveLastError()
        {
            return PInvoke.virSaveLastError();
        }
        public static void virSetErrorFunc(IntPtr userData, virErrorFunc handler)
        {
            PInvoke.virSetErrorFunc(userData, handler);
        }
        //DOMAIN


        public static int virConnectDomainEventDeregister(virConnectPtr conn, virConnectDomainEventCallback cb)
        {
            return PInvoke.virConnectDomainEventDeregister(conn, cb);
        }
        public static int virConnectDomainEventDeregisterAny(virConnectPtr conn, int callbackID)
        {
            return PInvoke.virConnectDomainEventDeregisterAny(conn, callbackID);
        }
        public static int virConnectDomainEventRegister(virConnectPtr conn, virConnectDomainEventCallback cb, IntPtr opaque, virFreeCallback freecb)
        {
            return PInvoke.virConnectDomainEventRegister(conn, cb, opaque, freecb);
        }
        public static int virConnectDomainEventRegisterAny(virConnectPtr conn, virDomainPtr dom, virDomainEventID eventID, virConnectDomainEventGraphicsCallback cb, IntPtr opaque, virFreeCallback freecb)
        {
            return PInvoke.virConnectDomainEventRegisterAny(conn, dom, (int)eventID, cb, opaque, freecb);
        }

        public static string virConnectDomainXMLFromNative(virConnectPtr conn, string nativeFormat, string nativeConfig, uint flags = 0)
        {
            return PInvoke.virConnectDomainXMLFromNative(conn, nativeFormat, nativeConfig, flags);
        }
        public static string virConnectDomainXMLToNative(virConnectPtr conn, string nativeFormat, string domainXml, uint flags = 0)
        {
            return PInvoke.virConnectDomainXMLToNative(conn, nativeFormat, domainXml, flags);
        }

        public static int virConnectGetAllDomainStats(virConnectPtr conn, virDomainStatsTypes stats, out virDomainStatsRecord[] retStats, virConnectGetAllDomainStatsFlags flags)
        {

            IntPtr ptr = IntPtr.Zero;
            var ret = PInvoke.virConnectGetAllDomainStats(conn, (uint)stats, ref ptr, (uint)flags);
            if (ret >= 0)
            {
                var tmpretStats = new _virDomainStatsRecord[ret];
                retStats = new virDomainStatsRecord[ret];
                //for(var i = 0; i < ret; i++)
                //{
                //    tmpretStats[i] = (_virDomainStatsRecord)Marshal.PtrToStructure(ptr, i * IntPtr.Size, typeof(_virDomainStatsRecord));
                //}

                // for(var i = 0; i < ret; i++){
                //     retStats[i].domainuuid = PInvoke.virDomainGetUUID(tmpretStats[i].dom);
                //     retStats[i].@params = new _virTypedParameter[tmpretStats[i].nparams];
                //     for(var j = 0; j < 0; j++)
                //     {
                //         retStats[i].@params[j] = (_virTypedParameter)Marshal.PtrToStructure(tmpretStats[i].@params, j * IntPtr.Size, typeof(_virTypedParameter));
                //     }
                //}
                //Libvirt.PInvoke.virDomainStatsRecordListFree(ptr);//free the array,
            }
            else
            {

                retStats = new virDomainStatsRecord[0];
            }
            return ret;
        }

        public static string virConnectGetDomainCapabilities(virConnectPtr conn, string emulatorbin, string arch, string machine, string virttype, uint flags = 0)
        {
            return PInvoke.virConnectGetDomainCapabilities(conn, emulatorbin, arch, machine, virttype, flags);
        }

        public static int virConnectListAllDomains(virConnectPtr conn, out virDomainPtr[] domains, virConnectListAllDomainsFlags flags)
        {
            IntPtr ptr = IntPtr.Zero;
            var ret = PInvoke.virConnectListAllDomains(conn, ref ptr, (uint)flags);
            if (ret >= 0)
            {
                domains = new virDomainPtr[ret];
                for (var i = 0; i < ret; i++)
                {
                    domains[i] = new virDomainPtr(Marshal.ReadIntPtr(ptr, i * IntPtr.Size));
                }
                PInvoke.free(ptr);//free the array, but not the domain objects, use dispose for that
            }
            else
            {
                domains = new virDomainPtr[0];
            }
            return ret;
        }
        //DOMAINS
        public static int virConnectListDefinedDomains(virConnectPtr @conn, out string[] @names, int @maxnames)
        {
            return NameArrayHandler(conn, out @names, @maxnames, PInvoke.virConnectListDefinedDomains);
        }
        public static int virConnectListDomains(virConnectPtr @conn, out int[] @names, int @maxnames)
        {
            @names = new int[maxnames];
            return PInvoke.virConnectListDomains(conn, names, maxnames);
        }
        public static int virConnectNumOfDefinedDomains(virConnectPtr conn)
        {
            return PInvoke.virConnectNumOfDefinedDomains(@conn);
        }
        public static int virConnectNumOfDomains(virConnectPtr conn)
        {
            return PInvoke.virConnectNumOfDomains(@conn);
        }
        public static int virDomainAbortJob(virDomainPtr domain)
        {
            return PInvoke.virDomainAbortJob(domain);
        }
        public static int virDomainAddIOThread(virDomainPtr domain, uint iothread_id, virDomainModificationImpact flags)
        {
            return PInvoke.virDomainAddIOThread(domain, iothread_id, (uint)flags);
        }
        public static int virDomainAttachDevice(virDomainPtr domain, string xml)
        {
            return PInvoke.virDomainAttachDevice(domain, xml);
        }
        public static int virDomainAttachDeviceFlags(virDomainPtr domain, string xml, virDomainDeviceModifyFlags flags)
        {
            return PInvoke.virDomainAttachDeviceFlags(domain, xml, (uint)flags);
        }

        public static int virDomainBlockCommit(virDomainPtr dom, string disk, string stringbase, string top, uint bandwidth, virDomainBlockCommitFlags flags)
        {
            return PInvoke.virDomainBlockCommit(dom, disk, stringbase, top, bandwidth, (uint)flags);
        }
        public static int virDomainBlockCopy(virDomainPtr dom, string disk, string destxml, virTypedParameterPtr paras, int nparams, virDomainBlockCopyFlags flags)
        {
            return PInvoke.virDomainBlockCopy(dom, disk, destxml, paras, nparams, (uint)flags);
        }
        public static int virDomainBlockJobAbort(virDomainPtr dom, string disk, virDomainBlockJobAbortFlags flags)
        {
            return PInvoke.virDomainBlockJobAbort(dom, disk, (uint)flags);
        }
        public static int virDomainBlockJobSetSpeed(virDomainPtr dom, string disk, uint bandwidth, virDomainBlockJobSetSpeedFlags flags)
        {
            return PInvoke.virDomainBlockJobSetSpeed(dom, disk, bandwidth, (uint)flags);
        }
        public static int virDomainBlockPeek(virDomainPtr dom, string disk, ulong offset, UIntPtr size, byte[] buffer, uint flags = 0)
        {
            return PInvoke.virDomainBlockPeek(dom, disk, offset, size, buffer, (uint)flags);
        }

        public static int virDomainBlockPull(virDomainPtr dom, string disk, uint bandwidth, virDomainBlockPullFlags flags)
        {
            return PInvoke.virDomainBlockPull(dom, disk, bandwidth, (uint)flags);
        }
        public static int virDomainBlockRebase(virDomainPtr dom, string disk, string b, uint bandwidth, virDomainBlockRebaseFlags flags)
        {
            return PInvoke.virDomainBlockRebase(dom, disk, b, bandwidth, (uint)flags);
        }
        public static int virDomainBlockResize(virDomainPtr dom, string disk, ulong size, virDomainBlockResizeFlags flags)
        {
            return PInvoke.virDomainBlockResize(dom, disk, size, (uint)flags);
        }
        public static int virDomainBlockStats(virDomainPtr dom, string disk, out _virDomainBlockStats stats, UIntPtr size)
        {
            stats = new _virDomainBlockStats();
            return PInvoke.virDomainBlockStats(dom, disk, ref stats, size);
        }
        public static int virDomainBlockStatsFlags(virDomainPtr dom, string disk, out virTypedParameter[] pars, ref int nparams, virTypedParameterFlags flags)
        {
            nparams = 0;
            var ret = PInvoke.virDomainBlockStatsFlags(dom, disk, IntPtr.Zero, ref nparams, (uint)flags);
            _virTypedParameter[] outpars = null;
            if (ret > -1)
            {
                outpars = new _virTypedParameter[nparams];
                ret = PInvoke.virDomainBlockStatsFlags(dom, disk, outpars, ref nparams, (uint)flags);
            }
            else
            {
                nparams = 0;
            }
            pars = MarshalvirTypedParameters(outpars, nparams);
            return ret;
        }
        public static int virDomainCoreDump(virDomainPtr domain, string to, virDomainCoreDumpFlags flags)
        {
            return PInvoke.virDomainCoreDump(domain, to, (uint)flags);
        }
        public static int virDomainCoreDumpWithFormat(virDomainPtr domain, string to, uint dumpformat, virDomainCoreDumpFlags flags)
        {
            return PInvoke.virDomainCoreDumpWithFormat(domain, to, dumpformat, (uint)flags);
        }
        public static int virDomainCreate(virDomainPtr domain)
        {
            return PInvoke.virDomainCreate(domain);
        }
        public static virDomainPtr virDomainCreateLinux(virConnectPtr conn, string xmlDesc, uint flags = 0)
        {
            return PInvoke.virDomainCreateLinux(conn, xmlDesc, flags);
        }
        public static int virDomainCreateWithFiles(virDomainPtr domain, uint nfiles, int[] files, virDomainCreateFlags flags)
        {
            return PInvoke.virDomainCreateWithFiles(domain, nfiles, files, (uint)flags);
        }
        public static int virDomainCreateWithFlags(virDomainPtr domain, virDomainCreateFlags flags)
        {
            return PInvoke.virDomainCreateWithFlags(domain, (uint)flags);
        }
        public static virDomainPtr virDomainCreateXML(virConnectPtr conn, string xmlDesc, virDomainCreateFlags flags)
        {
            return PInvoke.virDomainCreateXML(conn, xmlDesc, (uint)flags);
        }

        public static virDomainPtr virDomainCreateXMLWithFiles(virConnectPtr conn, string xmlDesc, uint nfiles, int[] files, virDomainCreateFlags flags)
        {
            return PInvoke.virDomainCreateXMLWithFiles(conn, xmlDesc, nfiles, files, (uint)flags);
        }
        public static virDomainPtr virDomainDefineXML(virConnectPtr @conn, string xml)
        {
            return PInvoke.virDomainDefineXML(@conn, xml);
        }
        public static virDomainPtr virDomainDefineXMLFlags(virConnectPtr conn, string xml, virDomainDefineFlags flags)
        {
            return PInvoke.virDomainDefineXMLFlags(conn, xml, (uint)flags);
        }
        public static int virDomainDelIOThread(virDomainPtr domain, uint iothread_id, virDomainModificationImpact flags)
        {
            return PInvoke.virDomainDelIOThread(domain, iothread_id, (uint)flags);
        }
        public static int virDomainDestroy(virDomainPtr domain)
        {
            return PInvoke.virDomainDestroy(domain);
        }
        public static int virDomainDestroyFlags(virDomainPtr domain, virDomainDestroyFlagsValues flags)
        {
            return PInvoke.virDomainDestroyFlags(domain, (uint)flags);
        }
        public static int virDomainDetachDevice(virDomainPtr domain, string xml)
        {
            return PInvoke.virDomainDetachDevice(domain, xml);
        }
        public static int virDomainDetachDeviceFlags(virDomainPtr domain, string xml, virDomainDeviceModifyFlags flags)
        {
            return PInvoke.virDomainDetachDeviceFlags(domain, xml, (uint)flags);
        }
        public static int virDomainFSFreeze(virDomainPtr dom, string[] mountpoints, uint nmountpoints, uint flags = 0)
        {
            return PInvoke.virDomainFSFreeze(dom, mountpoints, nmountpoints, flags);
        }
        public static void virDomainFSInfoFree(virDomainFSInfoPtr info)
        {
            PInvoke.virDomainFSInfoFree(info);
        }
        public static int virDomainFSThaw(virDomainPtr dom, string[] mountpoints, uint nmountpoints, uint flags = 0)
        {
            return PInvoke.virDomainFSThaw(dom, mountpoints, nmountpoints, flags);
        }
        public static int virDomainFSTrim(virDomainPtr dom, string mountPoint, ulong minimum, uint flags = 0)
        {
            return PInvoke.virDomainFSTrim(dom, mountPoint, minimum, flags);
        }

        public static int virDomainFree(virDomainPtr @domain)
        {
            return PInvoke.virDomainFree(@domain);
        }
        public static int virDomainGetAutostart(virDomainPtr @domain, ref int autostart)
        {
            return PInvoke.virDomainGetAutostart(@domain, ref autostart);
        }

        public static int virDomainGetBlkioParameters(virDomainPtr domain, out virTypedParameter[] pars, ref int nparams, uint flags)
        {
            nparams = 0;
            var ret = PInvoke.virDomainGetBlkioParameters(domain, IntPtr.Zero, ref nparams, (uint)flags);
            _virTypedParameter[] outpars = null;
            if (ret > -1)
            {
                outpars = new _virTypedParameter[nparams];
                ret = PInvoke.virDomainGetBlkioParameters(domain, outpars, ref nparams, (uint)flags);
            }
            else
            {
                nparams = 0;
            }
            pars = MarshalvirTypedParameters(outpars, nparams);
            return ret;
        }
        public static int virDomainGetBlockInfo(virDomainPtr domain, string disk, out _virDomainBlockInfo info, uint flags = 0)
        {
            info = new _virDomainBlockInfo();
            return PInvoke.virDomainGetBlockInfo(domain, disk, ref info, flags);
        }

        public static int virDomainGetBlockIoTune(virDomainPtr domain, string disk, out virTypedParameter[] pars, ref int nparams, uint flags)
        {
            nparams = 0;
            var ret = PInvoke.virDomainGetBlockIoTune(domain, disk, IntPtr.Zero, ref nparams, flags);
            _virTypedParameter[] outpars = null;
            if (ret > -1)
            {
                outpars = new _virTypedParameter[nparams];
                ret = PInvoke.virDomainGetBlockIoTune(domain, disk, outpars, ref nparams, flags);
            }
            else
            {
                nparams = 0;
            }
            pars = MarshalvirTypedParameters(outpars, nparams);
            return ret;
        }
        public static int virDomainGetBlockJobInfo(virDomainPtr dom, string disk, out _virDomainBlockJobInfo info, virDomainBlockJobInfoFlags flags)
        {
            info = new _virDomainBlockJobInfo();
            return PInvoke.virDomainGetBlockJobInfo(dom, disk, ref info, (uint)flags);
        }
        public static int virDomainGetCPUStats(virDomainPtr domain, out virTypedParameter[] pars, uint nparams, int start_cpu, uint ncpus, virTypedParameterFlags flags)
        {
            var ret = -1;
            _virTypedParameter[] outpars = null;
            if (start_cpu == -1)
            {//total stats
                nparams = Convert.ToUInt32(-1);//must be -1 in this case
                ret = PInvoke.virDomainGetCPUStats(domain, IntPtr.Zero, nparams, start_cpu, ncpus, 0);
                if (ret != -1)
                {
                    outpars = new _virTypedParameter[ret];
                    ret = PInvoke.virDomainGetCPUStats(domain, outpars, nparams, start_cpu, ncpus, 0);
                }
            }
            else if (nparams == 0 && ncpus == 0)
            {//per-cpu stats
                start_cpu = 0;
                ret = PInvoke.virDomainGetCPUStats(domain, IntPtr.Zero, nparams, start_cpu, ncpus, 0);
                if (ret != -1)
                {
                    var retnpars = PInvoke.virDomainGetCPUStats(domain, outpars, nparams, start_cpu, 1, 0);
                    if (retnpars != -1)
                    {
                        ncpus = Convert.ToUInt32(ret);
                        nparams = Convert.ToUInt32(retnpars);
                        outpars = new _virTypedParameter[ncpus * nparams];
                        ret = PInvoke.virDomainGetCPUStats(domain, outpars, nparams, start_cpu, ncpus, 0);
                    }
                }
            }
            else
            {//regular call, use parameters passed and go!
                outpars = new _virTypedParameter[ncpus * nparams];
                ret = PInvoke.virDomainGetCPUStats(domain, outpars, nparams, start_cpu, ncpus, 0);
            }
            pars = MarshalvirTypedParameters(outpars, Convert.ToInt32(nparams));
            return ret;
        }
        public static int virDomainGetControlInfo(virDomainPtr domain, out _virDomainControlInfo info, uint flags = 0)
        {
            info = new _virDomainControlInfo();
            return PInvoke.virDomainGetControlInfo(domain, ref info, flags);
        }
        public static int virDomainGetDiskErrors(virDomainPtr dom, out virDomainDiskError[] errors, uint maxerrors, uint flags = 0)
        {
            errors = new virDomainDiskError[maxerrors];
            return PInvoke.virDomainGetDiskErrors(dom, errors, maxerrors, flags);
        }
        public static int virDomainGetEmulatorPinInfo(virDomainPtr domain, out byte[] cpumap, int maplen, virDomainModificationImpact flags)
        {
            throw new NotImplementedException();
        }
        public static int virDomainGetFSInfo(virDomainPtr dom, out _virDomainFSInfo[] info, uint flags = 0)
        {
            throw new NotImplementedException();
        }
        public static string virDomainGetHostname(virDomainPtr domain, uint flags = 0)
        {
            return PInvoke.virDomainGetHostname(domain, flags);
        }
        public static uint virDomainGetID(virDomainPtr @conn)
        {
            return PInvoke.virDomainGetID(@conn);
        }
        public static int virDomainGetIOThreadInfo(virDomainPtr dom, out _virDomainIOThreadInfo[] info, virDomainModificationImpact flags)
        {
            throw new NotImplementedException();
        }

        public static int virDomainGetInfo(virDomainPtr @domain, out _virDomainInfo info)
        {
            info = new _virDomainInfo();
            return PInvoke.virDomainGetInfo(@domain, ref info);
        }

        public static int virDomainGetInterfaceParameters(virDomainPtr domain, string device, out virTypedParameter[] pars, ref int nparams, uint flags)
        {
            var ret = -1;
            _virTypedParameter[] outpars = null;
            if (nparams == 0)
            {
                ret = PInvoke.virDomainGetInterfaceParameters(@domain, device, IntPtr.Zero, ref nparams, flags);
                if (ret != -1)
                {
                    outpars = new _virTypedParameter[nparams];
                }
            }
            else
            {
                outpars = new _virTypedParameter[nparams];
            }
            ret = PInvoke.virDomainGetInterfaceParameters(@domain, device, outpars, ref nparams, flags);
            pars = MarshalvirTypedParameters(outpars, nparams);
            return ret;
        }

        public static int virDomainGetJobInfo(virDomainPtr domain, out _virDomainJobInfo info)
        {
            info = new _virDomainJobInfo();
            return PInvoke.virDomainGetJobInfo(@domain, ref info);
        }
        public static int virDomainGetJobStats(virDomainPtr domain, virDomainJobType type, out virTypedParameter[] pars, ref int nparams, virDomainGetJobStatsFlags flags)
        {
            int retype = (int)type;
            _virTypedParameter[] outpars = new _virTypedParameter[nparams];
            var ret = PInvoke.virDomainGetJobStats(@domain, ref retype, outpars, ref nparams, (uint)flags);
            pars = MarshalvirTypedParameters(outpars, nparams);
            return ret;
        }

        public static uint virDomainGetMaxMemory(virDomainPtr domain)
        {
            return PInvoke.virDomainGetMaxMemory(@domain);
        }
        public static int virDomainGetMaxVcpus(virDomainPtr domain)
        {
            return PInvoke.virDomainGetMaxVcpus(@domain);
        }
        public static int virDomainGetMemoryParameters(virDomainPtr domain, out virTypedParameter[] pars, ref int nparams, uint flags)
        {
            nparams = 0;
            var ret = PInvoke.virDomainGetMemoryParameters(domain, IntPtr.Zero, ref nparams, flags);
            _virTypedParameter[] outpars = null;
            if (nparams > 0)
            {
                outpars = new _virTypedParameter[nparams];
                ret = PInvoke.virDomainGetMemoryParameters(domain, outpars, ref nparams, flags);
            }
            else
            {
                nparams = 0;
            }
            pars = MarshalvirTypedParameters(outpars, nparams);
            return ret;
        }

        public static string virDomainGetMetadata(virDomainPtr domain, virDomainMetadataType type, string uri, virDomainModificationImpact flags)
        {
            return PInvoke.virDomainGetMetadata(domain, (int)type, uri, (uint)flags);

        }
        public static string virDomainGetName(virDomainPtr @conn)
        {
            return PInvoke.virDomainGetName(@conn);
        }
        public static int virDomainGetNumaParameters(virDomainPtr domain, out virTypedParameter[] pars, ref int nparams, uint flags)
        {
            nparams = 0;
            var ret = PInvoke.virDomainGetNumaParameters(domain, IntPtr.Zero, ref nparams, flags);
            _virTypedParameter[] outpars = null;
            if (nparams > 0)
            {
                outpars = new _virTypedParameter[nparams];
                ret = PInvoke.virDomainGetNumaParameters(domain, outpars, ref nparams, flags);
            }
            else
            {
                nparams = 0;
            }
            pars = MarshalvirTypedParameters(outpars, nparams);
            return ret;

        }
        public static string virDomainGetOSType(virDomainPtr domain)
        {
            return PInvoke.virDomainGetOSType(domain);
        }
        public static int virDomainGetSchedulerParameters(virDomainPtr domain, out virTypedParameter[] pars, ref int nparams)
        {
            var outpars = new _virTypedParameter[nparams];
            var ret = PInvoke.virDomainGetSchedulerParameters(domain, outpars, ref nparams);
            if (ret == -1) outpars = new _virTypedParameter[0];
            pars = MarshalvirTypedParameters(outpars, nparams);
            return ret;
        }
        public static int virDomainGetSchedulerParametersFlags(virDomainPtr domain, out virTypedParameter[] pars, ref int nparams, uint flags)
        {
            var outpars = new _virTypedParameter[nparams];
            var ret = PInvoke.virDomainGetSchedulerParametersFlags(domain, outpars, ref nparams, flags);
            if (ret == -1) outpars = new _virTypedParameter[0];
            pars = MarshalvirTypedParameters(outpars, nparams);
            return ret;
        }
        public static string virDomainGetSchedulerType(virDomainPtr domain, ref int nparams)
        {
            return PInvoke.virDomainGetSchedulerType(domain, ref nparams);
        }
        public static int virDomainGetSecurityLabel(virDomainPtr domain, out _virSecurityLabel seclabel)
        {
            seclabel = new _virSecurityLabel();
            return PInvoke.virDomainGetSecurityLabel(domain, ref seclabel);
        }
        public static int virDomainGetSecurityLabelList(virDomainPtr domain, out _virSecurityLabel[] seclabels)
        {
            IntPtr arr = IntPtr.Zero;
            var ret = PInvoke.virDomainGetSecurityLabelList(domain, arr);
            if (ret == -1)
            {
                seclabels = new _virSecurityLabel[0];
                return ret;
            }
            seclabels = new _virSecurityLabel[ret];
            for (var i = 0; i < seclabels.Length; i++)
            {
                seclabels[i] = (_virSecurityLabel)Marshal.PtrToStructure(arr + (i * Marshal.SizeOf(seclabels[i])), typeof(_virSecurityLabel));
            }
            PInvoke.free(arr);
            return ret;
        }
        public static int virDomainGetState(virDomainPtr domain, out virDomainState state, out int reason, uint flags = 0)
        {
            var retstate = -1;
            reason = 0;
            var ret = PInvoke.virDomainGetState(domain, ref retstate, ref reason, flags);
            state = (virDomainState)retstate;
            return ret;
        }

        public static int virDomainGetTime(virDomainPtr dom, out long seconds, out uint nseconds, uint flags = 0)
        {
            seconds = 0;
            nseconds = 0;
            return PInvoke.virDomainGetTime(dom, ref seconds, ref nseconds, flags);
        }
        public static int virDomainGetUUID(virDomainPtr domain, out byte[] uuid)
        {
            uuid = new byte[VIR_UUID_BUFLEN];
            return PInvoke.virDomainGetUUID(domain, uuid);
        }
        public static int virDomainGetUUIDString(virDomainPtr domain, out string buf)
        {
            byte[] by = new byte[VIR_UUID_STRING_BUFLEN];
            var ret = PInvoke.virDomainGetUUIDString(domain, by);
            buf = System.Text.Encoding.UTF8.GetString(by);
            return ret;
        }
        public static int virDomainGetVcpuPinInfo(virDomainPtr domain, int ncpumaps, out byte[] cpumaps, int maplen, uint flags)
        {
            cpumaps = new byte[ncpumaps * maplen];
            return PInvoke.virDomainGetVcpuPinInfo(domain, ncpumaps, cpumaps, maplen, flags);
        }
        public static int virDomainGetVcpus(virDomainPtr domain, out _virVcpuInfo[] info, int maxinfo, out byte[] cpumaps, int maplen)
        {
            info = new _virVcpuInfo[maxinfo];
            cpumaps = new byte[maxinfo * maplen];
            return PInvoke.virDomainGetVcpus(domain, info, maxinfo, cpumaps, maplen);
        }
        public static int virDomainGetVcpusFlags(virDomainPtr domain, virDomainVcpuFlags flags)
        {
            return PInvoke.virDomainGetVcpusFlags(domain, (uint)flags);
        }
        public static string virDomainGetXMLDesc(virDomainPtr domain, virDomainXMLFlags flags)
        {
            return PInvoke.virDomainGetXMLDesc(domain, (uint)flags);
        }
        public static int virDomainHasManagedSaveImage(virDomainPtr domain, uint flags = 0)
        {
            return PInvoke.virDomainHasManagedSaveImage(domain, flags);
        }
        public static void virDomainIOThreadInfoFree(IntPtr info)
        {
            throw new NotImplementedException();
        }
        public static int virDomainInjectNMI(virDomainPtr domain, uint flags = 0)
        {
            return PInvoke.virDomainInjectNMI(domain, flags);
        }
        public static int virDomainInterfaceAddresses(virDomainPtr dom, IntPtr ifaces, uint source, uint flags = 0)
        {
            throw new NotImplementedException();
        }
        public static void virDomainInterfaceFree(IntPtr iface)
        {
            throw new NotImplementedException();
        }
        public static int virDomainInterfaceStats(virDomainPtr dom, string path, out _virDomainInterfaceStats stats, UIntPtr size)
        {
            stats = new _virDomainInterfaceStats();
            return PInvoke.virDomainInterfaceStats(dom, path, ref stats, size);
        }
        public static int virDomainIsActive(virDomainPtr dom)
        {
            return PInvoke.virDomainIsActive(dom);
        }
        public static int virDomainIsPersistent(virDomainPtr dom)
        {
            return PInvoke.virDomainIsPersistent(dom);
        }
        public static int virDomainIsUpdated(virDomainPtr dom)
        {
            return PInvoke.virDomainIsUpdated(dom);
        }
        public static int virDomainListGetStats(virDomainPtr[] doms, virDomainStatsTypes stats, out _virDomainStatsRecord[,] retStats, virConnectGetAllDomainStatsFlags flags)
        {
            throw new NotImplementedException();
        }

        public static virDomainPtr virDomainLookupByID(virConnectPtr @conn, int @id)
        {
            return PInvoke.virDomainLookupByID(@conn, @id);
        }
        public static virDomainPtr virDomainLookupByName(virConnectPtr @conn, string name)
        {
            return PInvoke.virDomainLookupByName(@conn, name);
        }
        public static virDomainPtr virDomainLookupByUUID(virConnectPtr @conn, byte[] name)
        {
            return PInvoke.virDomainLookupByUUID(@conn, name);
        }
        public static virDomainPtr virDomainLookupByUUIDString(virConnectPtr @conn, string name)
        {
            return PInvoke.virDomainLookupByUUIDString(@conn, name);
        }
        public static int virDomainManagedSave(virDomainPtr dom, virDomainSaveRestoreFlags flags)
        {
            return PInvoke.virDomainManagedSave(dom, (uint)flags);
        }
        public static int virDomainManagedSaveRemove(virDomainPtr dom, uint flags = 0)
        {
            return PInvoke.virDomainManagedSaveRemove(dom, flags);
        }
        public static int virDomainMemoryPeek(virDomainPtr dom, ulong start, UIntPtr size, byte[] buffer, virDomainMemoryFlags flags)
        {
            throw new NotImplementedException();
        }
        public static int virDomainMemoryStats(virDomainPtr dom, out _virDomainMemoryStat[] stats, uint nr_stats, uint flags = 0)
        {
            stats = new _virDomainMemoryStat[nr_stats];
            return PInvoke.virDomainMemoryStats(dom, stats, nr_stats, flags);
        }
        public static virDomainPtr virDomainMigrate(virDomainPtr domain, virConnectPtr dconn, virDomainMigrateFlags flags, string dname, string uri, uint bandwidth)
        {
            return PInvoke.virDomainMigrate(domain, dconn, (uint)flags, dname, uri, bandwidth);
        }
        public static virDomainPtr virDomainMigrate2(virDomainPtr domain, virConnectPtr dconn, string dxml, virDomainMigrateFlags flags, string dname, string uri, uint bandwidth)
        {
            return PInvoke.virDomainMigrate2(domain, dconn, dxml, (uint)flags, dname, uri, bandwidth);
        }
        public static virDomainPtr virDomainMigrate3(virDomainPtr domain, virConnectPtr dconn, _virTypedParameter[] pars, uint nparams, virDomainMigrateFlags flags)
        {
            throw new NotImplementedException();
            // return PInvoke.virDomainMigrate3(domain, dconn, pars, nparams, (uint)flags);
        }
        public static int virDomainMigrateGetCompressionCache(virDomainPtr domain, out ulong cacheSize, uint flags = 0)
        {
            cacheSize = 0;
            return PInvoke.virDomainMigrateGetCompressionCache(domain, ref cacheSize, flags);
        }
        public static int virDomainMigrateGetMaxSpeed(virDomainPtr domain, out uint bandwidth, uint flags = 0)
        {
            bandwidth = 0;
            return PInvoke.virDomainMigrateGetMaxSpeed(domain, ref bandwidth, flags);
        }
        public static int virDomainMigrateSetCompressionCache(virDomainPtr domain, ulong cacheSize, uint flags = 0)
        {
            return PInvoke.virDomainMigrateSetCompressionCache(domain, cacheSize, flags);
        }
        public static int virDomainMigrateSetMaxDowntime(virDomainPtr domain, ulong downtime, uint flags = 0)
        {
            return PInvoke.virDomainMigrateSetMaxDowntime(domain, downtime, flags);
        }
        public static int virDomainMigrateSetMaxSpeed(virDomainPtr domain, uint bandwidth, uint flags = 0)
        {
            return PInvoke.virDomainMigrateSetMaxSpeed(domain, bandwidth, flags);
        }
        public static int virDomainMigrateToURI(virDomainPtr domain, string duri, virDomainMigrateFlags flags, string dname, uint bandwidth)
        {
            return PInvoke.virDomainMigrateToURI(domain, duri, (uint)flags, dname, bandwidth);
        }
        public static int virDomainMigrateToURI2(virDomainPtr domain, string dconnuri, string miguri, string dxml, virDomainMigrateFlags flags, string dname, uint bandwidth)
        {
            return PInvoke.virDomainMigrateToURI2(domain, dconnuri, miguri, dxml, (uint)flags, dname, bandwidth);
        }
        public static int virDomainMigrateToURI3(virDomainPtr domain, string dconnuri, virTypedParameterPtr[] pars, uint nparams, virDomainMigrateFlags flags)
        {
            throw new NotImplementedException();
        }
        public static int virDomainOpenChannel(virDomainPtr dom, string name, virStreamPtr st, virDomainChannelFlags flags)
        {
            return PInvoke.virDomainOpenChannel(dom, name, st, (uint)flags);
        }
        public static int virDomainOpenConsole(virDomainPtr dom, string dev_name, virStreamPtr st, virDomainConsoleFlags flags)
        {
            return PInvoke.virDomainOpenConsole(dom, dev_name, st, (uint)flags);
        }
        public static int virDomainOpenGraphics(virDomainPtr dom, uint idx, int fd, virDomainOpenGraphicsFlags flags)
        {
            return PInvoke.virDomainOpenGraphics(dom, idx, fd, (uint)flags);
        }
        public static int virDomainOpenGraphicsFD(virDomainPtr dom, uint idx, virDomainOpenGraphicsFlags flags)
        {
            return PInvoke.virDomainOpenGraphicsFD(dom, idx, (uint)flags);
        }
        public static int virDomainPMSuspendForDuration(virDomainPtr dom, virNodeSuspendTarget target, ulong duration, uint flags = 0)
        {
            return PInvoke.virDomainPMSuspendForDuration(dom, (uint)target, duration, flags);
        }
        public static int virDomainPMWakeup(virDomainPtr dom, uint flags = 0)
        {
            return PInvoke.virDomainPMWakeup(dom, flags);
        }
        public static int virDomainPinEmulator(virDomainPtr domain, out byte[] cpumap, int maplen, virDomainModificationImpact flags)
        {
            throw new NotImplementedException();
        }
        public static int virDomainPinIOThread(virDomainPtr domain, uint iothread_id, out byte[] cpumap, int maplen, virDomainModificationImpact flags)
        {
            throw new NotImplementedException();
        }
        public static int virDomainPinVcpu(virDomainPtr domain, uint vcpu, out byte[] cpumap, int maplen)
        {
            throw new NotImplementedException();
        }
        public static int virDomainPinVcpuFlags(virDomainPtr domain, uint vcpu, out byte[] cpumap, int maplen, virDomainModificationImpact flags)
        {
            throw new NotImplementedException();
        }

        public static int virDomainReboot(virDomainPtr domain, virDomainRebootFlagValues flags)
        {
            return PInvoke.virDomainReboot(domain, (uint)flags);
        }
        public static int virDomainRef(virDomainPtr domain)
        {
            return PInvoke.virDomainRef(domain);
        }
        public static int virDomainReset(virDomainPtr domain, uint flags = 0)
        {
            return PInvoke.virDomainReset(domain, flags);
        }
        public static int virDomainRestore(virConnectPtr conn, string from)
        {
            return PInvoke.virDomainRestore(conn, from);
        }
        public static int virDomainRestoreFlags(virConnectPtr conn, string from, string dxml, virDomainSaveRestoreFlags flags)
        {
            return PInvoke.virDomainRestoreFlags(conn, from, dxml, (uint)flags);
        }

        public static int virDomainResume(virDomainPtr domain)
        {
            return PInvoke.virDomainResume(domain);
        }
        public static int virDomainSave(virDomainPtr domain, string to)
        {
            return PInvoke.virDomainSave(domain, to);
        }
        public static int virDomainSaveFlags(virDomainPtr domain, string to, string dxml, virDomainSaveRestoreFlags flags)
        {
            return PInvoke.virDomainSaveFlags(domain, to, dxml, (uint)flags);
        }
        public static int virDomainSaveImageDefineXML(virConnectPtr conn, string to, string dxml, virDomainSaveRestoreFlags flags)
        {
            return PInvoke.virDomainSaveImageDefineXML(conn, to, dxml, (uint)flags);
        }
        public static string virDomainSaveImageGetXMLDesc(virConnectPtr conn, string file, virDomainXMLFlags flags)
        {
            return PInvoke.virDomainSaveImageGetXMLDesc(conn, file, (uint)flags);
        }

        public static string virDomainScreenshot(virDomainPtr domain, virStreamPtr stream, uint screen, uint flags = 0)
        {
            return PInvoke.virDomainScreenshot(domain, stream, screen, flags);
        }
        public static int virDomainSendKey(virDomainPtr domain, virKeycodeSet codeset, uint holdtime, uint[] keycodes, int nkeycodes, uint flags = 0)
        {
            return PInvoke.virDomainSendKey(domain, (uint)codeset, holdtime, keycodes, nkeycodes, flags);
        }

        public static int virDomainSendProcessSignal(virDomainPtr domain, long pid_value, uint signum, virDomainProcessSignal flags)
        {
            return PInvoke.virDomainSendProcessSignal(domain, pid_value, signum, (uint)flags);
        }
        public static int virDomainSetBlkioParameters(virDomainPtr domain, virTypedParameter[] pars, int nparams, virDomainModificationImpact flags)
        {
            return PInvoke.virDomainSetBlkioParameters(domain, pars, nparams, (uint)flags);
        }
        public static int virDomainSetBlockIoTune(virDomainPtr domain, string disk, virTypedParameter[] pars, int nparams, virDomainModificationImpact flags)
        {
            return PInvoke.virDomainSetBlockIoTune(domain, disk, pars, nparams, (uint)flags);
        }
        public static int virDomainSetInterfaceParameters(virDomainPtr domain, string device, virTypedParameter[] pars, int nparams, virDomainModificationImpact flags)
        {
            return PInvoke.virDomainSetInterfaceParameters(domain, device, pars, nparams, (uint)flags);
        }

        public static int virDomainSetAutostart(virDomainPtr domain, int autostart)
        {
            return PInvoke.virDomainSetAutostart(domain, autostart);
        }
        public static int virDomainSetMaxMemory(virDomainPtr domain, uint memory)
        {
            return PInvoke.virDomainSetMaxMemory(domain, memory);
        }
        public static int virDomainSetMemory(virDomainPtr domain, uint memory)
        {
            return PInvoke.virDomainSetMemory(domain, memory);
        }
        public static int virDomainSetMemoryFlags(virDomainPtr domain, uint memory, virDomainMemoryModFlags flags)
        {
            return PInvoke.virDomainSetMemoryFlags(domain, memory, (uint)flags);
        }
        public static int virDomainSetMemoryParameters(virDomainPtr domain, virTypedParameter[] pars, int nparams, virDomainModificationImpact flags)
        {
            return PInvoke.virDomainSetMemoryParameters(domain, pars, nparams, (uint)flags);
        }
        public static int virDomainSetMemoryStatsPeriod(virDomainPtr domain, int period, virDomainMemoryModFlags flags)
        {
            return PInvoke.virDomainSetMemoryStatsPeriod(domain, period, (uint)flags);
        }

        public static int virDomainSetMetadata(virDomainPtr domain, virDomainMetadataType type, string metadata, string key, string uri, virDomainModificationImpact flags)
        {
            return PInvoke.virDomainSetMetadata(domain, (int)type, metadata, key, uri, (uint)flags);
        }
        public static int virDomainSetNumaParameters(virDomainPtr domain, virTypedParameter[] pars, int nparams, virDomainModificationImpact flags)
        {
            return PInvoke.virDomainSetNumaParameters(domain, pars, nparams, (uint)flags);
        }
        public static int virDomainSetSchedulerParameters(virDomainPtr domain, virTypedParameter[] pars, int nparams)
        {
            return PInvoke.virDomainSetSchedulerParameters(domain, pars, nparams);
        }
        public static int virDomainSetSchedulerParametersFlags(virDomainPtr domain, virTypedParameter[] pars, int nparams, virDomainModificationImpact flags)
        {
            return PInvoke.virDomainSetSchedulerParametersFlags(domain, pars, nparams, (uint)flags);
        }
        public static int virDomainSetTime(virDomainPtr dom, long seconds, uint nseconds, virDomainSetTimeFlags flags)
        {
            return PInvoke.virDomainSetTime(dom, seconds, nseconds, (uint)flags);
        }

        public static int virDomainSetUserPassword(virDomainPtr dom, string user, string password, virDomainSetUserPasswordFlags flags)
        {
            return PInvoke.virDomainSetUserPassword(dom, user, password, (uint)flags);
        }

        public static int virDomainSetVcpus(virDomainPtr domain, uint nvcpus)
        {
            return PInvoke.virDomainSetVcpus(domain, nvcpus);
        }
        public static int virDomainSetVcpusFlags(virDomainPtr domain, uint nvcpus, virDomainVcpuFlags flags)
        {
            return PInvoke.virDomainSetVcpusFlags(domain, nvcpus, (uint)flags);
        }
        public static int virDomainShutdown(virDomainPtr domain)
        {
            return PInvoke.virDomainShutdown(domain);
        }

        public static int virDomainShutdownFlags(virDomainPtr domain, virDomainShutdownFlagValues flags)
        {
            return PInvoke.virDomainShutdownFlags(domain, (uint)flags);
        }
        public static void virDomainStatsRecordListFree(virDomainStatsRecordPtr stats)
        {
            PInvoke.virDomainStatsRecordListFree(stats);
        }
        public static int virDomainSuspend(virDomainPtr domain)
        {
            return PInvoke.virDomainSuspend(domain);
        }
        public static int virDomainUndefine(virDomainPtr domain)
        {
            return PInvoke.virDomainUndefine(domain);
        }
        public static int virDomainUndefineFlags(virDomainPtr domain, virDomainUndefineFlagsValues flags)
        {
            return PInvoke.virDomainUndefineFlags(domain, (uint)flags);
        }
        public static int virDomainUpdateDeviceFlags(virDomainPtr domain, string xml, virDomainDeviceModifyFlags flags)
        {
            return PInvoke.virDomainUpdateDeviceFlags(domain, xml, (uint)flags);
        }

        //EVENT

        public static int virEventAddHandle(int fd, virEventHandleType events, virEventHandleCallback cb, IntPtr opaque, virFreeCallback ff)
        {
            return PInvoke.virEventAddHandle(fd, (int)events, cb, opaque, ff);
        }
        public static int virEventAddTimeout(int timeout, virEventTimeoutCallback cb, IntPtr opaque, virFreeCallback ff)
        {
            return PInvoke.virEventAddTimeout(timeout, cb, opaque, ff);
        }
        public static int virEventRegisterDefaultImpl()
        {
            return PInvoke.virEventRegisterDefaultImpl();
        }
        public static void virEventRegisterImpl(virEventAddHandleFunc addHandle,
                     virEventUpdateHandleFunc updateHandle,
                     virEventRemoveHandleFunc removeHandle,
                     virEventAddTimeoutFunc addTimeout,
                     virEventUpdateTimeoutFunc updateTimeout,
                     virEventRemoveTimeoutFunc removeTimeout)
        {
            PInvoke.virEventRegisterImpl(addHandle,
                     updateHandle,
                     removeHandle,
                     addTimeout,
                     updateTimeout,
                     removeTimeout);
        }
        public static int virEventRemoveHandle(int watch)
        {
            return PInvoke.virEventRemoveHandle(watch);
        }
        public static int virEventRemoveTimeout(int timer)
        {
            return PInvoke.virEventRemoveTimeout(timer);
        }
        public static int virEventRunDefaultImpl()
        {
            return PInvoke.virEventRunDefaultImpl();
        }
        public static void virEventUpdateHandle(int watch, int events)
        {
            PInvoke.virEventUpdateHandle(watch, events);
        }
        public static void virEventUpdateTimeout(int timer, int timeout)
        {
            PInvoke.virEventUpdateTimeout(timer, timeout);
        }

        //SNAPSHOTS
        public static int virDomainHasCurrentSnapshot(virDomainPtr domain, uint flags = 0)
        {
            return PInvoke.virDomainHasCurrentSnapshot(domain, flags);
        }

    }



    public static class PInvoke
    {
        private const string libraryPath = "libvirt-0.dll";

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr malloc(IntPtr size);

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void free(IntPtr ptr);

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr calloc(IntPtr num, IntPtr size);

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr realloc(IntPtr ptr, IntPtr size);

        public class StringWithoutNativeCleanUpMarshaler : ICustomMarshaler
        {
            public static ICustomMarshaler GetInstance(string cookie)
            {
                return new StringWithoutNativeCleanUpMarshaler();
            }

            public object MarshalNativeToManaged(IntPtr pNativeData)
            {
                return Marshal.PtrToStringAnsi(pNativeData);
            }

            public IntPtr MarshalManagedToNative(object ManagedObj)
            {
                return Marshal.StringToHGlobalAnsi((string)ManagedObj);
            }

            public void CleanUpNativeData(IntPtr pNativeData)
            {
            }

            public void CleanUpManagedData(object ManagedObj)
            {
            }

            public int GetNativeDataSize()
            {
                throw new NotImplementedException();
            }
        }
        public class StringWithNativeCleanUpMarshaler : ICustomMarshaler
        {
            [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern void free(IntPtr ptr);
            public static ICustomMarshaler GetInstance(string cookie)
            {
                return new StringWithNativeCleanUpMarshaler();
            }

            public object MarshalNativeToManaged(IntPtr pNativeData)
            {
                return Marshal.PtrToStringAnsi(pNativeData);
            }

            public IntPtr MarshalManagedToNative(object ManagedObj)
            {
                return Marshal.StringToHGlobalAnsi((string)ManagedObj);
            }
            public void CleanUpNativeData(IntPtr pNativeData)
            {
                free(pNativeData);
            }
            public void CleanUpManagedData(object ManagedObj)
            {
            }

            public int GetNativeDataSize()
            {
                throw new NotImplementedException();
            }
        }

        [DllImport(libraryPath, EntryPoint = "virTypedParamsGet", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virTypedParameterPtr virTypedParamsGet(virTypedParameterPtr @params, int @nparams, [MarshalAs(UnmanagedType.LPStr)] string @name);

        [DllImport(libraryPath, EntryPoint = "virTypedParamsGetInt", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virTypedParamsGetInt(virTypedParameterPtr @params, int @nparams, [MarshalAs(UnmanagedType.LPStr)] string @name, IntPtr @value);

        [DllImport(libraryPath, EntryPoint = "virTypedParamsGetUInt", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virTypedParamsGetUInt(virTypedParameterPtr @params, int @nparams, [MarshalAs(UnmanagedType.LPStr)] string @name, IntPtr @value);

        [DllImport(libraryPath, EntryPoint = "virTypedParamsGetLLong", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virTypedParamsGetLLong(virTypedParameterPtr @params, int @nparams, [MarshalAs(UnmanagedType.LPStr)] string @name, IntPtr @value);

        [DllImport(libraryPath, EntryPoint = "virTypedParamsGetULLong", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virTypedParamsGetULLong(virTypedParameterPtr @params, int @nparams, [MarshalAs(UnmanagedType.LPStr)] string @name, IntPtr @value);

        [DllImport(libraryPath, EntryPoint = "virTypedParamsGetDouble", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virTypedParamsGetDouble(virTypedParameterPtr @params, int @nparams, [MarshalAs(UnmanagedType.LPStr)] string @name, IntPtr @value);

        [DllImport(libraryPath, EntryPoint = "virTypedParamsGetBoolean", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virTypedParamsGetBoolean(virTypedParameterPtr @params, int @nparams, [MarshalAs(UnmanagedType.LPStr)] string @name, IntPtr @value);

        [DllImport(libraryPath, EntryPoint = "virTypedParamsGetString", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virTypedParamsGetString(virTypedParameterPtr @params, int @nparams, [MarshalAs(UnmanagedType.LPStr)] string @name, out IntPtr @value);

        [DllImport(libraryPath, EntryPoint = "virTypedParamsAddInt", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virTypedParamsAddInt(IntPtr @params, IntPtr @nparams, IntPtr @maxparams, [MarshalAs(UnmanagedType.LPStr)] string @name, int @value);

        [DllImport(libraryPath, EntryPoint = "virTypedParamsAddUInt", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virTypedParamsAddUInt(IntPtr @params, IntPtr @nparams, IntPtr @maxparams, [MarshalAs(UnmanagedType.LPStr)] string @name, uint @value);

        [DllImport(libraryPath, EntryPoint = "virTypedParamsAddLLong", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virTypedParamsAddLLong(IntPtr @params, IntPtr @nparams, IntPtr @maxparams, [MarshalAs(UnmanagedType.LPStr)] string @name, long @value);

        [DllImport(libraryPath, EntryPoint = "virTypedParamsAddULLong", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virTypedParamsAddULLong(IntPtr @params, IntPtr @nparams, IntPtr @maxparams, [MarshalAs(UnmanagedType.LPStr)] string @name, ulong @value);

        [DllImport(libraryPath, EntryPoint = "virTypedParamsAddDouble", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virTypedParamsAddDouble(IntPtr @params, IntPtr @nparams, IntPtr @maxparams, [MarshalAs(UnmanagedType.LPStr)] string @name, double @value);

        [DllImport(libraryPath, EntryPoint = "virTypedParamsAddBoolean", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virTypedParamsAddBoolean(IntPtr @params, IntPtr @nparams, IntPtr @maxparams, [MarshalAs(UnmanagedType.LPStr)] string @name, int @value);

        [DllImport(libraryPath, EntryPoint = "virTypedParamsAddString", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virTypedParamsAddString(IntPtr @params, IntPtr @nparams, IntPtr @maxparams, [MarshalAs(UnmanagedType.LPStr)] string @name, [MarshalAs(UnmanagedType.LPStr)] string @value);

        [DllImport(libraryPath, EntryPoint = "virTypedParamsAddFromString", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virTypedParamsAddFromString(IntPtr @params, IntPtr @nparams, IntPtr @maxparams, [MarshalAs(UnmanagedType.LPStr)] string @name, int @type, [MarshalAs(UnmanagedType.LPStr)] string @value);

        [DllImport(libraryPath, EntryPoint = "virTypedParamsClear", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern void virTypedParamsClear(virTypedParameterPtr @params, int @nparams);

        [DllImport(libraryPath, EntryPoint = "virTypedParamsFree", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern void virTypedParamsFree(virTypedParameterPtr @params, int @nparams);

        [DllImport(libraryPath, EntryPoint = "virNodeGetMemoryParameters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeGetMemoryParameters(virConnectPtr @conn, IntPtr @params, ref int @nparams, uint @flags);
        [DllImport(libraryPath, EntryPoint = "virNodeGetMemoryParameters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeGetMemoryParameters(virConnectPtr @conn, [Out] _virTypedParameter[] @params, ref int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNodeSetMemoryParameters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeSetMemoryParameters(virConnectPtr @conn, [Out] _virTypedParameter[] @params, int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNodeGetCPUMap", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeGetCPUMap(virConnectPtr @conn, ref IntPtr @cpumap, ref int @online, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virGetVersion", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virGetVersion(ref uint[] @libVer, [MarshalAs(UnmanagedType.LPStr), In] string @type, ref uint[] @typeVer);

        [DllImport(libraryPath, EntryPoint = "virInitialize", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virInitialize();

        [DllImport(libraryPath, EntryPoint = "virConnectOpen", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virConnectPtr virConnectOpen([MarshalAs(UnmanagedType.LPStr)] string @name);

        [DllImport(libraryPath, EntryPoint = "virConnectOpenReadOnly", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virConnectPtr virConnectOpenReadOnly([MarshalAs(UnmanagedType.LPStr)] string @name);

        [DllImport(libraryPath, EntryPoint = "virConnectOpenAuth", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virConnectPtr virConnectOpenAuth([MarshalAs(UnmanagedType.LPStr)] string @name, [In, Out] _virConnectAuth @auth, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virConnectRef", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectRef(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virConnectClose", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectClose(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virConnectGetType", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithoutNativeCleanUpMarshaler))]
        public static extern string virConnectGetType(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virConnectGetVersion", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectGetVersion(virConnectPtr @conn, ref int @hvVer);

        [DllImport(libraryPath, EntryPoint = "virConnectGetLibVersion", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectGetLibVersion(virConnectPtr @conn, ref uint @libVer);

        [DllImport(libraryPath, EntryPoint = "virConnectGetHostname", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virConnectGetHostname(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virConnectGetURI", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virConnectGetURI(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virConnectGetSysinfo", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virConnectGetSysinfo(virConnectPtr @conn, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virConnectSetKeepAlive", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectSetKeepAlive(virConnectPtr @conn, int @interval, uint @count);

        [DllImport(libraryPath, EntryPoint = "virConnectRegisterCloseCallback", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectRegisterCloseCallback(virConnectPtr @conn, virConnectCloseFunc @cb, IntPtr @opaque, virFreeCallback @freecb);

        [DllImport(libraryPath, EntryPoint = "virConnectUnregisterCloseCallback", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectUnregisterCloseCallback(virConnectPtr @conn, virConnectCloseFunc @cb);

        [DllImport(libraryPath, EntryPoint = "virConnectGetMaxVcpus", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectGetMaxVcpus(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @type);

        [DllImport(libraryPath, EntryPoint = "virNodeGetInfo", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeGetInfo(virConnectPtr @conn, ref _virNodeInfo @info);

        [DllImport(libraryPath, EntryPoint = "virConnectGetCapabilities", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virConnectGetCapabilities(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virNodeGetCPUStats", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeGetCPUStats(virConnectPtr @conn, int @cpuNum, [In, Out] _virNodeCPUStats[] @params, ref int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNodeGetCPUStats", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeGetCPUStats(virConnectPtr @conn, int @cpuNum, IntPtr @params, ref int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNodeGetMemoryStats", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeGetMemoryStats(virConnectPtr @conn, int @cellNum, IntPtr @params, ref int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNodeGetMemoryStats", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeGetMemoryStats(virConnectPtr @conn, int @cellNum, [In, Out] _virNodeMemoryStats[] @params, ref int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNodeGetFreeMemory", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern ulong virNodeGetFreeMemory(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virNodeGetSecurityModel", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeGetSecurityModel(virConnectPtr @conn, ref _virSecurityModel @secmodel);

        [DllImport(libraryPath, EntryPoint = "virNodeSuspendForDuration", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeSuspendForDuration(virConnectPtr @conn, uint @target, ulong @duration, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNodeGetCellsFreeMemory", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeGetCellsFreeMemory(virConnectPtr @conn, [In, Out] ulong[] @freeMems, int @startCell, int @maxCells);

        [DllImport(libraryPath, EntryPoint = "virConnectIsEncrypted", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectIsEncrypted(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virConnectIsSecure", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectIsSecure(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virConnectIsAlive", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectIsAlive(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virConnectCompareCPU", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectCompareCPU(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr)] out string @xmlDesc, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virConnectGetCPUModelNames", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectGetCPUModelNames(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @arch, IntPtr @models, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virConnectBaselineCPU", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virConnectBaselineCPU(virConnectPtr @conn, [In] string[] @xmlCPUs, uint @ncpus, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNodeGetFreePages", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeGetFreePages(virConnectPtr @conn, uint @npages, [In, Out] uint[] @pages, int @startcell, uint @cellcount, [In, Out] ulong[] @counts, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNodeAllocPages", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeAllocPages(virConnectPtr @conn, uint @npages, [In] uint[] @pageSizes, [In] ulong[] @pageCounts, int @startCell, uint @cellCount, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetSchedulerParameters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetSchedulerParameters(virDomainPtr @domain, [Out] _virTypedParameter[] @params, ref int @nparams);

        [DllImport(libraryPath, EntryPoint = "virDomainGetSchedulerParametersFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetSchedulerParametersFlags(virDomainPtr @domain, [Out] _virTypedParameter[] @params, ref int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSetSchedulerParameters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSetSchedulerParameters(virDomainPtr @domain, [In] virTypedParameter[] @params, int @nparams);

        [DllImport(libraryPath, EntryPoint = "virDomainSetSchedulerParametersFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSetSchedulerParametersFlags(virDomainPtr @domain, [In] virTypedParameter[] @params, int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainMigrate", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virDomainPtr virDomainMigrate(virDomainPtr @domain, virConnectPtr @dconn, uint @flags, [MarshalAs(UnmanagedType.LPStr), In] string @dname, [MarshalAs(UnmanagedType.LPStr), In] string @uri, uint @bandwidth);

        [DllImport(libraryPath, EntryPoint = "virDomainMigrate2", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virDomainPtr virDomainMigrate2(virDomainPtr @domain, virConnectPtr @dconn, [MarshalAs(UnmanagedType.LPStr), In] string @dxml, uint @flags, [MarshalAs(UnmanagedType.LPStr), In] string @dname, [MarshalAs(UnmanagedType.LPStr), In] string @uri, uint @bandwidth);

        [DllImport(libraryPath, EntryPoint = "virDomainMigrate3", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virDomainPtr virDomainMigrate3(virDomainPtr @domain, virConnectPtr @dconn, [In] virTypedParameter[] @params, uint @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainMigrateToURI", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainMigrateToURI(virDomainPtr @domain, [MarshalAs(UnmanagedType.LPStr), In] string @duri, uint @flags, [MarshalAs(UnmanagedType.LPStr), In] string @dname, uint @bandwidth);

        [DllImport(libraryPath, EntryPoint = "virDomainMigrateToURI2", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainMigrateToURI2(virDomainPtr @domain, [MarshalAs(UnmanagedType.LPStr), In] string @dconnuri, [MarshalAs(UnmanagedType.LPStr), In] string @miguri, [MarshalAs(UnmanagedType.LPStr), In] string @dxml, uint @flags, [MarshalAs(UnmanagedType.LPStr), In] string @dname, uint @bandwidth);

        [DllImport(libraryPath, EntryPoint = "virDomainMigrateToURI3", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainMigrateToURI3(virDomainPtr @domain, [MarshalAs(UnmanagedType.LPStr)] string @dconnuri, virTypedParameterPtr @params, uint @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainMigrateSetMaxDowntime", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainMigrateSetMaxDowntime(virDomainPtr @domain, ulong @downtime, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainMigrateGetCompressionCache", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainMigrateGetCompressionCache(virDomainPtr @domain, ref ulong @cacheSize, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainMigrateSetCompressionCache", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainMigrateSetCompressionCache(virDomainPtr @domain, ulong @cacheSize, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainMigrateSetMaxSpeed", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainMigrateSetMaxSpeed(virDomainPtr @domain, uint @bandwidth, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainMigrateGetMaxSpeed", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainMigrateGetMaxSpeed(virDomainPtr @domain, ref uint @bandwidth, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virConnectGetDomainCapabilities", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virConnectGetDomainCapabilities(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @emulatorbin, [MarshalAs(UnmanagedType.LPStr), In] string @arch, [MarshalAs(UnmanagedType.LPStr), In] string @machine, [MarshalAs(UnmanagedType.LPStr), In] string @virttype, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virConnectListDomains", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectListDomains(virConnectPtr @conn, [In, Out] int[] @ids, int @maxids);

        [DllImport(libraryPath, EntryPoint = "virConnectNumOfDomains", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectNumOfDomains(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virDomainGetConnect", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virConnectPtr virDomainGetConnect(virDomainPtr @domain);

        [DllImport(libraryPath, EntryPoint = "virDomainCreateXML", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virDomainPtr virDomainCreateXML(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @xmlDesc, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainCreateXMLWithFiles", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virDomainPtr virDomainCreateXMLWithFiles(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @xmlDesc, uint @nfiles, [In] int[] @files, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainLookupByName", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virDomainPtr virDomainLookupByName(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @name);

        [DllImport(libraryPath, EntryPoint = "virDomainLookupByID", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virDomainPtr virDomainLookupByID(virConnectPtr @conn, int @id);

        [DllImport(libraryPath, EntryPoint = "virDomainLookupByUUID", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virDomainPtr virDomainLookupByUUID(virConnectPtr @conn, [In] byte[] @uuid);

        [DllImport(libraryPath, EntryPoint = "virDomainLookupByUUIDString", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virDomainPtr virDomainLookupByUUIDString(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @uuid);

        [DllImport(libraryPath, EntryPoint = "virDomainShutdown", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainShutdown(virDomainPtr @domain);

        [DllImport(libraryPath, EntryPoint = "virDomainShutdownFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainShutdownFlags(virDomainPtr @domain, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainReboot", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainReboot(virDomainPtr @domain, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainReset", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainReset(virDomainPtr @domain, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainDestroy", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainDestroy(virDomainPtr @domain);

        [DllImport(libraryPath, EntryPoint = "virDomainDestroyFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainDestroyFlags(virDomainPtr @domain, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainRef", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainRef(virDomainPtr @domain);

        [DllImport(libraryPath, EntryPoint = "virDomainFree", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainFree(virDomainPtr @domain);

        [DllImport(libraryPath, EntryPoint = "virDomainSuspend", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSuspend(virDomainPtr @domain);

        [DllImport(libraryPath, EntryPoint = "virDomainResume", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainResume(virDomainPtr @domain);

        [DllImport(libraryPath, EntryPoint = "virDomainPMSuspendForDuration", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainPMSuspendForDuration(virDomainPtr @domain, uint @target, ulong @duration, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainPMWakeup", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainPMWakeup(virDomainPtr @domain, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSave", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSave(virDomainPtr @domain, [MarshalAs(UnmanagedType.LPStr), In] string @to);

        [DllImport(libraryPath, EntryPoint = "virDomainSaveFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSaveFlags(virDomainPtr @domain, [MarshalAs(UnmanagedType.LPStr), In] string @to, [MarshalAs(UnmanagedType.LPStr), In] string @dxml, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainRestore", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainRestore(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @from);

        [DllImport(libraryPath, EntryPoint = "virDomainRestoreFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainRestoreFlags(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @from, [MarshalAs(UnmanagedType.LPStr), In] string @dxml, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSaveImageGetXMLDesc", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virDomainSaveImageGetXMLDesc(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @file, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSaveImageDefineXML", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSaveImageDefineXML(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @file, [MarshalAs(UnmanagedType.LPStr), In] string @dxml, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainManagedSave", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainManagedSave(virDomainPtr @dom, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainHasManagedSaveImage", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainHasManagedSaveImage(virDomainPtr @dom, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainManagedSaveRemove", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainManagedSaveRemove(virDomainPtr @dom, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainCoreDump", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainCoreDump(virDomainPtr @domain, [MarshalAs(UnmanagedType.LPStr), In] string @to, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainCoreDumpWithFormat", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainCoreDumpWithFormat(virDomainPtr @domain, [MarshalAs(UnmanagedType.LPStr), In] string @to, uint @dumpformat, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainScreenshot", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virDomainScreenshot(virDomainPtr @domain, virStreamPtr @stream, uint @screen, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetInfo", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetInfo(virDomainPtr @domain, ref _virDomainInfo @info);

        [DllImport(libraryPath, EntryPoint = "virDomainGetState", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetState(virDomainPtr @domain, ref int @state, ref int @reason, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetCPUStats", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetCPUStats(virDomainPtr @domain, [Out] _virTypedParameter[] @params, uint @nparams, int @start_cpu, uint @ncpus, uint @flags);
        [DllImport(libraryPath, EntryPoint = "virDomainGetCPUStats", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetCPUStats(virDomainPtr @domain, IntPtr @params, uint @nparams, int @start_cpu, uint @ncpus, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetControlInfo", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetControlInfo(virDomainPtr @domain, ref _virDomainControlInfo @info, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetSchedulerType", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virDomainGetSchedulerType(virDomainPtr @domain, ref int @nparams);

        [DllImport(libraryPath, EntryPoint = "virDomainSetBlkioParameters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSetBlkioParameters(virDomainPtr @domain, [In] virTypedParameter[] @params, int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetBlkioParameters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetBlkioParameters(virDomainPtr @domain, [Out] _virTypedParameter[] @params, ref int @nparams, uint @flags);
        [DllImport(libraryPath, EntryPoint = "virDomainGetBlkioParameters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetBlkioParameters(virDomainPtr @domain, IntPtr @params, ref int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSetMemoryParameters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSetMemoryParameters(virDomainPtr @domain, [In] virTypedParameter[] @params, int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetMemoryParameters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetMemoryParameters(virDomainPtr @domain, IntPtr @params, ref int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetMemoryParameters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetMemoryParameters(virDomainPtr @domain, [Out] _virTypedParameter[] @params, ref int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSetNumaParameters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSetNumaParameters(virDomainPtr @domain, [In] virTypedParameter[] @params, int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetNumaParameters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetNumaParameters(virDomainPtr @domain, IntPtr @params, ref int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetNumaParameters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetNumaParameters(virDomainPtr @domain, [Out] _virTypedParameter[] @params, ref int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetName", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithoutNativeCleanUpMarshaler))]
        public static extern string virDomainGetName(virDomainPtr @domain);

        [DllImport(libraryPath, EntryPoint = "virDomainGetID", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern uint virDomainGetID(virDomainPtr @domain);

        [DllImport(libraryPath, EntryPoint = "virDomainGetUUID", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetUUID(virDomainPtr @domain, [Out] byte[] @uuid);

        [DllImport(libraryPath, EntryPoint = "virDomainGetUUIDString", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetUUIDString(virDomainPtr @domain, [Out] byte[] @buf);

        [DllImport(libraryPath, EntryPoint = "virDomainGetOSType", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virDomainGetOSType(virDomainPtr @domain);

        [DllImport(libraryPath, EntryPoint = "virDomainGetMaxMemory", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern uint virDomainGetMaxMemory(virDomainPtr @domain);

        [DllImport(libraryPath, EntryPoint = "virDomainSetMaxMemory", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSetMaxMemory(virDomainPtr @domain, uint @memory);

        [DllImport(libraryPath, EntryPoint = "virDomainSetMemory", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSetMemory(virDomainPtr @domain, uint @memory);

        [DllImport(libraryPath, EntryPoint = "virDomainSetMemoryFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSetMemoryFlags(virDomainPtr @domain, uint @memory, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSetMemoryStatsPeriod", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSetMemoryStatsPeriod(virDomainPtr @domain, int @period, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetMaxVcpus", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetMaxVcpus(virDomainPtr @domain);

        [DllImport(libraryPath, EntryPoint = "virDomainGetSecurityLabel", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetSecurityLabel(virDomainPtr @domain, ref _virSecurityLabel @seclabel);

        [DllImport(libraryPath, EntryPoint = "virDomainGetHostname", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virDomainGetHostname(virDomainPtr @domain, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetSecurityLabelList", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetSecurityLabelList(virDomainPtr @domain, IntPtr @seclabels);

        [DllImport(libraryPath, EntryPoint = "virDomainSetMetadata", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSetMetadata(virDomainPtr @domain, int @type, [MarshalAs(UnmanagedType.LPStr), In] string @metadata, [MarshalAs(UnmanagedType.LPStr), In] string @key, [MarshalAs(UnmanagedType.LPStr), In] string @uri, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetMetadata", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virDomainGetMetadata(virDomainPtr @domain, int @type, [MarshalAs(UnmanagedType.LPStr)] string @uri, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetXMLDesc", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virDomainGetXMLDesc(virDomainPtr @domain, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virConnectDomainXMLFromNative", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virConnectDomainXMLFromNative(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @nativeFormat, [MarshalAs(UnmanagedType.LPStr), In] string @nativeConfig, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virConnectDomainXMLToNative", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virConnectDomainXMLToNative(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @nativeFormat, [MarshalAs(UnmanagedType.LPStr), In] string @domainXml, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainBlockStats", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainBlockStats(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @disk, ref _virDomainBlockStats @stats, [Out] UIntPtr @size);

        [DllImport(libraryPath, EntryPoint = "virDomainBlockStatsFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainBlockStatsFlags(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @disk, IntPtr @params, ref int @nparams, uint @flags);
        [DllImport(libraryPath, EntryPoint = "virDomainBlockStatsFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainBlockStatsFlags(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @disk, [Out] _virTypedParameter[] @params, ref int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainInterfaceStats", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainInterfaceStats(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @path, ref _virDomainInterfaceStats @stats, UIntPtr @size);

        [DllImport(libraryPath, EntryPoint = "virDomainSetInterfaceParameters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSetInterfaceParameters(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @device, [In] virTypedParameter[] @params, int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetInterfaceParameters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetInterfaceParameters(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @device, [Out] _virTypedParameter[] @params, ref int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetInterfaceParameters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetInterfaceParameters(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @device, IntPtr @params, ref int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainBlockPeek", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainBlockPeek(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @disk, ulong @offset, UIntPtr @size, [Out] byte[] @buffer, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainBlockResize", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainBlockResize(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @disk, ulong @size, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetBlockInfo", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetBlockInfo(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @disk, ref _virDomainBlockInfo @info, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainMemoryStats", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainMemoryStats(virDomainPtr @dom, [Out] _virDomainMemoryStat[] @stats, uint @nr_stats, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainMemoryPeek", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainMemoryPeek(virDomainPtr @dom, ulong @start, UIntPtr @size, IntPtr @buffer, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainDefineXML", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virDomainPtr virDomainDefineXML(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @xml);

        [DllImport(libraryPath, EntryPoint = "virDomainDefineXMLFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virDomainPtr virDomainDefineXMLFlags(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @xml, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainDelIOThread", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainDelIOThread(virDomainPtr domain, uint iothread_id, uint flags);

        [DllImport(libraryPath, EntryPoint = "virDomainUndefine", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainUndefine(virDomainPtr @domain);

        [DllImport(libraryPath, EntryPoint = "virDomainUndefineFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainUndefineFlags(virDomainPtr @domain, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virConnectNumOfDefinedDomains", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectNumOfDefinedDomains(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virConnectListDefinedDomains", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectListDefinedDomains(virConnectPtr @conn, IntPtr @names, int @maxnames);

        [DllImport(libraryPath, EntryPoint = "virConnectListAllDomains", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectListAllDomains(virConnectPtr @conn, ref IntPtr @domains, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainCreate", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainCreate(virDomainPtr @domain);

        [DllImport(libraryPath, EntryPoint = "virDomainCreateWithFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainCreateWithFlags(virDomainPtr @domain, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainCreateWithFiles", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainCreateWithFiles(virDomainPtr @domain, uint @nfiles, [In] int[] @files, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetAutostart", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetAutostart(virDomainPtr @domain, ref int @autostart);

        [DllImport(libraryPath, EntryPoint = "virDomainSetAutostart", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSetAutostart(virDomainPtr @domain, int @autostart);

        [DllImport(libraryPath, EntryPoint = "virDomainSetVcpus", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSetVcpus(virDomainPtr @domain, uint @nvcpus);

        [DllImport(libraryPath, EntryPoint = "virDomainSetVcpusFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSetVcpusFlags(virDomainPtr @domain, uint @nvcpus, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetVcpusFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetVcpusFlags(virDomainPtr @domain, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainPinVcpu", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainPinVcpu(virDomainPtr @domain, uint @vcpu, IntPtr @cpumap, int @maplen);

        [DllImport(libraryPath, EntryPoint = "virDomainPinVcpuFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainPinVcpuFlags(virDomainPtr @domain, uint @vcpu, IntPtr @cpumap, int @maplen, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetVcpuPinInfo", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetVcpuPinInfo(virDomainPtr @domain, int @ncpumaps, [Out] byte[] @cpumaps, int @maplen, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainPinEmulator", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainPinEmulator(virDomainPtr @domain, IntPtr @cpumap, int @maplen, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetEmulatorPinInfo", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetEmulatorPinInfo(virDomainPtr @domain, IntPtr @cpumaps, int @maplen, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetVcpus", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetVcpus(virDomainPtr @domain, [Out] _virVcpuInfo[] @info, int @maxinfo, [Out] byte[] @cpumaps, int @maplen);

        [DllImport(libraryPath, EntryPoint = "virDomainAttachDevice", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainAttachDevice(virDomainPtr @domain, [MarshalAs(UnmanagedType.LPStr), In] string @xml);

        [DllImport(libraryPath, EntryPoint = "virDomainDetachDevice", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainDetachDevice(virDomainPtr @domain, [MarshalAs(UnmanagedType.LPStr), In] string @xml);

        [DllImport(libraryPath, EntryPoint = "virDomainAttachDeviceFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainAttachDeviceFlags(virDomainPtr @domain, [MarshalAs(UnmanagedType.LPStr), In] string @xml, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainDetachDeviceFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainDetachDeviceFlags(virDomainPtr @domain, [MarshalAs(UnmanagedType.LPStr), In] string @xml, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainUpdateDeviceFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainUpdateDeviceFlags(virDomainPtr @domain, [MarshalAs(UnmanagedType.LPStr), In] string @xml, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virConnectGetAllDomainStats", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectGetAllDomainStats(virConnectPtr @conn, uint @stats, ref IntPtr @retStats, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainListGetStats", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainListGetStats([In] virDomainPtr[] @doms, uint @stats, IntPtr @retStats, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainStatsRecordListFree", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern void virDomainStatsRecordListFree(virDomainStatsRecordPtr @stats);

        [DllImport(libraryPath, EntryPoint = "virDomainBlockJobAbort", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainBlockJobAbort(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @disk, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetBlockJobInfo", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetBlockJobInfo(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @disk, ref _virDomainBlockJobInfo @info, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainBlockJobSetSpeed", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainBlockJobSetSpeed(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @disk, uint @bandwidth, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainBlockPull", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainBlockPull(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @disk, uint @bandwidth, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainBlockRebase", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainBlockRebase(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @disk, [MarshalAs(UnmanagedType.LPStr), In] string @base, uint @bandwidth, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainBlockCopy", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainBlockCopy(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @disk, [MarshalAs(UnmanagedType.LPStr), In] string @destxml, virTypedParameterPtr @params, int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainBlockCommit", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainBlockCommit(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @disk, [MarshalAs(UnmanagedType.LPStr), In] string @base, [MarshalAs(UnmanagedType.LPStr), In] string @top, uint @bandwidth, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSetBlockIoTune", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSetBlockIoTune(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr)] string @disk, [In] virTypedParameter[] @params, int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetBlockIoTune", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetBlockIoTune(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @disk, [Out] _virTypedParameter[] @params, ref int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetBlockIoTune", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetBlockIoTune(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @disk, IntPtr @params, ref int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetDiskErrors", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetDiskErrors(virDomainPtr @dom, [Out] virDomainDiskError[] @errors, uint @maxerrors, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSendKey", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSendKey(virDomainPtr @domain, uint @codeset, uint @holdtime, [Out] uint[] @keycodes, int @nkeycodes, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSendProcessSignal", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSendProcessSignal(virDomainPtr @domain, long @pid_value, uint @signum, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainCreateLinux", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virDomainPtr virDomainCreateLinux(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @xmlDesc, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virConnectDomainEventRegister", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectDomainEventRegister(virConnectPtr @conn, virConnectDomainEventCallback @cb, IntPtr @opaque, virFreeCallback @freecb);

        [DllImport(libraryPath, EntryPoint = "virConnectDomainEventDeregister", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectDomainEventDeregister(virConnectPtr @conn, virConnectDomainEventCallback @cb);

        [DllImport(libraryPath, EntryPoint = "virDomainIsActive", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainIsActive(virDomainPtr @dom);

        [DllImport(libraryPath, EntryPoint = "virDomainIsPersistent", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainIsPersistent(virDomainPtr @dom);

        [DllImport(libraryPath, EntryPoint = "virDomainIsUpdated", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainIsUpdated(virDomainPtr @dom);

        [DllImport(libraryPath, EntryPoint = "virDomainGetJobInfo", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetJobInfo(virDomainPtr @dom, ref _virDomainJobInfo @info);

        [DllImport(libraryPath, EntryPoint = "virDomainGetJobStats", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetJobStats(virDomainPtr @domain, ref int @type, [Out] _virTypedParameter[] @params, ref int @nparams, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainAbortJob", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainAbortJob(virDomainPtr @dom);

        [DllImport(libraryPath, EntryPoint = "virDomainAddIOThread", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainAddIOThread(virDomainPtr domain, uint iothread_id, uint flags);

        [DllImport(libraryPath, EntryPoint = "virConnectDomainEventRegisterAny", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectDomainEventRegisterAny(virConnectPtr @conn, virDomainPtr @dom, int @eventID, virConnectDomainEventGraphicsCallback @cb, IntPtr @opaque, virFreeCallback @freecb);

        [DllImport(libraryPath, EntryPoint = "virConnectDomainEventDeregisterAny", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectDomainEventDeregisterAny(virConnectPtr @conn, int @callbackID);

        [DllImport(libraryPath, EntryPoint = "virDomainOpenConsole", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainOpenConsole(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr)] string @dev_name, virStreamPtr @st, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainOpenChannel", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainOpenChannel(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @name, virStreamPtr @st, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainOpenGraphics", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainOpenGraphics(virDomainPtr @dom, uint @idx, int @fd, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainOpenGraphicsFD", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainOpenGraphicsFD(virDomainPtr @dom, uint @idx, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainInjectNMI", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainInjectNMI(virDomainPtr @domain, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainFSTrim", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainFSTrim(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @mountPoint, ulong @minimum, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainFSFreeze", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainFSFreeze(virDomainPtr @dom, [In] string[] @mountpoints, uint @nmountpoints, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainFSThaw", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainFSThaw(virDomainPtr @dom, [In] string[] @mountpoints, uint @nmountpoints, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainFSInfoFree", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern void virDomainFSInfoFree(virDomainFSInfoPtr @info);

        [DllImport(libraryPath, EntryPoint = "virDomainGetFSInfo", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetFSInfo(virDomainPtr @dom, out IntPtr @info, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainGetTime", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainGetTime(virDomainPtr @dom, ref long @seconds, ref uint @nseconds, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSetTime", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSetTime(virDomainPtr @dom, long @seconds, uint @nseconds, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSetUserPassword", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSetUserPassword(virDomainPtr @dom, [MarshalAs(UnmanagedType.LPStr), In] string @user, [MarshalAs(UnmanagedType.LPStr), In] string @password, uint flags);


        [DllImport(libraryPath, EntryPoint = "virDomainSnapshotGetName", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern string virDomainSnapshotGetName(virDomainSnapshotPtr @snapshot);

        [DllImport(libraryPath, EntryPoint = "virDomainSnapshotGetDomain", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virDomainPtr virDomainSnapshotGetDomain(virDomainSnapshotPtr @snapshot);

        [DllImport(libraryPath, EntryPoint = "virDomainSnapshotGetConnect", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virConnectPtr virDomainSnapshotGetConnect(virDomainSnapshotPtr @snapshot);

        [DllImport(libraryPath, EntryPoint = "virDomainSnapshotCreateXML", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virDomainSnapshotPtr virDomainSnapshotCreateXML(virDomainPtr @domain, [MarshalAs(UnmanagedType.LPStr)] string @xmlDesc, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSnapshotGetXMLDesc", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern IntPtr virDomainSnapshotGetXMLDesc(virDomainSnapshotPtr @snapshot, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSnapshotNum", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSnapshotNum(virDomainPtr @domain, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSnapshotListNames", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSnapshotListNames(virDomainPtr @domain, out IntPtr @names, int @nameslen, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainListAllSnapshots", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainListAllSnapshots(virDomainPtr @domain, out IntPtr @snaps, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSnapshotNumChildren", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSnapshotNumChildren(virDomainSnapshotPtr @snapshot, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSnapshotListChildrenNames", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSnapshotListChildrenNames(virDomainSnapshotPtr @snapshot, out IntPtr @names, int @nameslen, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSnapshotListAllChildren", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSnapshotListAllChildren(virDomainSnapshotPtr @snapshot, out IntPtr @snaps, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSnapshotLookupByName", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virDomainSnapshotPtr virDomainSnapshotLookupByName(virDomainPtr @domain, [MarshalAs(UnmanagedType.LPStr)] string @name, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainHasCurrentSnapshot", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainHasCurrentSnapshot(virDomainPtr @domain, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSnapshotCurrent", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virDomainSnapshotPtr virDomainSnapshotCurrent(virDomainPtr @domain, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSnapshotGetParent", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virDomainSnapshotPtr virDomainSnapshotGetParent(virDomainSnapshotPtr @snapshot, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSnapshotIsCurrent", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSnapshotIsCurrent(virDomainSnapshotPtr @snapshot, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSnapshotHasMetadata", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSnapshotHasMetadata(virDomainSnapshotPtr @snapshot, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainRevertToSnapshot", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainRevertToSnapshot(virDomainSnapshotPtr @snapshot, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSnapshotDelete", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSnapshotDelete(virDomainSnapshotPtr @snapshot, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virDomainSnapshotRef", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSnapshotRef(virDomainSnapshotPtr @snapshot);

        [DllImport(libraryPath, EntryPoint = "virDomainSnapshotFree", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virDomainSnapshotFree(virDomainSnapshotPtr @snapshot);

        [DllImport(libraryPath, EntryPoint = "virEventRegisterImpl", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern void virEventRegisterImpl(virEventAddHandleFunc @addHandle, virEventUpdateHandleFunc @updateHandle, virEventRemoveHandleFunc @removeHandle, virEventAddTimeoutFunc @addTimeout, virEventUpdateTimeoutFunc @updateTimeout, virEventRemoveTimeoutFunc @removeTimeout);

        [DllImport(libraryPath, EntryPoint = "virEventRegisterDefaultImpl", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virEventRegisterDefaultImpl();

        [DllImport(libraryPath, EntryPoint = "virEventRunDefaultImpl", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virEventRunDefaultImpl();

        [DllImport(libraryPath, EntryPoint = "virEventAddHandle", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virEventAddHandle(int @fd, int @events, virEventHandleCallback @cb, IntPtr @opaque, virFreeCallback @ff);

        [DllImport(libraryPath, EntryPoint = "virEventUpdateHandle", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern void virEventUpdateHandle(int @watch, int @events);

        [DllImport(libraryPath, EntryPoint = "virEventRemoveHandle", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virEventRemoveHandle(int @watch);

        [DllImport(libraryPath, EntryPoint = "virEventAddTimeout", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virEventAddTimeout(int @frequency, virEventTimeoutCallback @cb, IntPtr @opaque, virFreeCallback @ff);

        [DllImport(libraryPath, EntryPoint = "virEventUpdateTimeout", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern void virEventUpdateTimeout(int @timer, int @frequency);

        [DllImport(libraryPath, EntryPoint = "virEventRemoveTimeout", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virEventRemoveTimeout(int @timer);

        [DllImport(libraryPath, EntryPoint = "virInterfaceGetConnect", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virConnectPtr virInterfaceGetConnect(virInterfacePtr @iface);

        [DllImport(libraryPath, EntryPoint = "virConnectNumOfInterfaces", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectNumOfInterfaces(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virConnectListInterfaces", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectListInterfaces(virConnectPtr @conn, IntPtr @names, int @maxnames);

        [DllImport(libraryPath, EntryPoint = "virConnectNumOfDefinedInterfaces", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectNumOfDefinedInterfaces(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virConnectListDefinedInterfaces", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectListDefinedInterfaces(virConnectPtr @conn, IntPtr @names, int @maxnames);

        [DllImport(libraryPath, EntryPoint = "virConnectListAllInterfaces", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectListAllInterfaces(virConnectPtr @conn, ref IntPtr @ifaces, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virInterfaceLookupByName", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virInterfacePtr virInterfaceLookupByName(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @name);

        [DllImport(libraryPath, EntryPoint = "virInterfaceLookupByMACString", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virInterfacePtr virInterfaceLookupByMACString(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @mac);

        [DllImport(libraryPath, EntryPoint = "virInterfaceGetName", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithoutNativeCleanUpMarshaler))]
        public static extern string virInterfaceGetName(virInterfacePtr @iface);

        [DllImport(libraryPath, EntryPoint = "virInterfaceGetMACString", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithoutNativeCleanUpMarshaler))]
        public static extern string virInterfaceGetMACString(virInterfacePtr @iface);

        [DllImport(libraryPath, EntryPoint = "virInterfaceGetXMLDesc", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virInterfaceGetXMLDesc(virInterfacePtr @iface, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virInterfaceDefineXML", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virInterfacePtr virInterfaceDefineXML(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr)] string @xmlDesc, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virInterfaceUndefine", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virInterfaceUndefine(virInterfacePtr @iface);

        [DllImport(libraryPath, EntryPoint = "virInterfaceCreate", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virInterfaceCreate(virInterfacePtr @iface, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virInterfaceDestroy", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virInterfaceDestroy(virInterfacePtr @iface, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virInterfaceRef", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virInterfaceRef(virInterfacePtr @iface);

        [DllImport(libraryPath, EntryPoint = "virInterfaceFree", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virInterfaceFree(virInterfacePtr @iface);

        [DllImport(libraryPath, EntryPoint = "virInterfaceChangeBegin", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virInterfaceChangeBegin(virConnectPtr @conn, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virInterfaceChangeCommit", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virInterfaceChangeCommit(virConnectPtr @conn, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virInterfaceChangeRollback", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virInterfaceChangeRollback(virConnectPtr @conn, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virInterfaceIsActive", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virInterfaceIsActive(virInterfacePtr @iface);

        [DllImport(libraryPath, EntryPoint = "virNetworkGetConnect", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virConnectPtr virNetworkGetConnect(virNetworkPtr @network);

        [DllImport(libraryPath, EntryPoint = "virConnectNumOfNetworks", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectNumOfNetworks(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virConnectListNetworks", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectListNetworks(virConnectPtr @conn, out IntPtr @names, int @maxnames);

        [DllImport(libraryPath, EntryPoint = "virConnectNumOfDefinedNetworks", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectNumOfDefinedNetworks(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virConnectListDefinedNetworks", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectListDefinedNetworks(virConnectPtr @conn, out IntPtr @names, int @maxnames);

        [DllImport(libraryPath, EntryPoint = "virConnectListAllNetworks", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectListAllNetworks(virConnectPtr @conn, out IntPtr @nets, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNetworkLookupByName", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virNetworkPtr virNetworkLookupByName(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr)] string @name);

        [DllImport(libraryPath, EntryPoint = "virNetworkLookupByUUID", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virNetworkPtr virNetworkLookupByUUID(virConnectPtr @conn, IntPtr @uuid);

        [DllImport(libraryPath, EntryPoint = "virNetworkLookupByUUIDString", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virNetworkPtr virNetworkLookupByUUIDString(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr)] string @uuid);

        [DllImport(libraryPath, EntryPoint = "virNetworkCreateXML", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virNetworkPtr virNetworkCreateXML(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr)] string @xmlDesc);

        [DllImport(libraryPath, EntryPoint = "virNetworkDefineXML", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virNetworkPtr virNetworkDefineXML(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr)] string @xmlDesc);

        [DllImport(libraryPath, EntryPoint = "virNetworkUndefine", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNetworkUndefine(virNetworkPtr @network);

        [DllImport(libraryPath, EntryPoint = "virNetworkUpdate", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNetworkUpdate(virNetworkPtr @network, uint @command, uint @section, int @parentIndex, [MarshalAs(UnmanagedType.LPStr)] string @xml, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNetworkCreate", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNetworkCreate(virNetworkPtr @network);

        [DllImport(libraryPath, EntryPoint = "virNetworkDestroy", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNetworkDestroy(virNetworkPtr @network);

        [DllImport(libraryPath, EntryPoint = "virNetworkRef", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNetworkRef(virNetworkPtr @network);

        [DllImport(libraryPath, EntryPoint = "virNetworkFree", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNetworkFree(virNetworkPtr @network);

        [DllImport(libraryPath, EntryPoint = "virNetworkGetName", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern string virNetworkGetName(virNetworkPtr @network);

        [DllImport(libraryPath, EntryPoint = "virNetworkGetUUID", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNetworkGetUUID(virNetworkPtr @network, IntPtr @uuid);

        [DllImport(libraryPath, EntryPoint = "virNetworkGetUUIDString", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNetworkGetUUIDString(virNetworkPtr @network, IntPtr @buf);

        [DllImport(libraryPath, EntryPoint = "virNetworkGetXMLDesc", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern IntPtr virNetworkGetXMLDesc(virNetworkPtr @network, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNetworkGetBridgeName", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern IntPtr virNetworkGetBridgeName(virNetworkPtr @network);

        [DllImport(libraryPath, EntryPoint = "virNetworkGetAutostart", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNetworkGetAutostart(virNetworkPtr @network, IntPtr @autostart);

        [DllImport(libraryPath, EntryPoint = "virNetworkSetAutostart", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNetworkSetAutostart(virNetworkPtr @network, int @autostart);

        [DllImport(libraryPath, EntryPoint = "virNetworkIsActive", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNetworkIsActive(virNetworkPtr @net);

        [DllImport(libraryPath, EntryPoint = "virNetworkIsPersistent", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNetworkIsPersistent(virNetworkPtr @net);

        [DllImport(libraryPath, EntryPoint = "virNetworkDHCPLeaseFree", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern void virNetworkDHCPLeaseFree(virNetworkDHCPLeasePtr @lease);

        [DllImport(libraryPath, EntryPoint = "virNetworkGetDHCPLeases", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNetworkGetDHCPLeases(virNetworkPtr @network, [MarshalAs(UnmanagedType.LPStr)] string @mac, out IntPtr @leases, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virConnectNetworkEventRegisterAny", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectNetworkEventRegisterAny(virConnectPtr @conn, virNetworkPtr @net, int @eventID, virConnectNetworkEventGenericCallback @cb, IntPtr @opaque, virFreeCallback @freecb);

        [DllImport(libraryPath, EntryPoint = "virConnectNetworkEventDeregisterAny", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectNetworkEventDeregisterAny(virConnectPtr @conn, int @callbackID);

        [DllImport(libraryPath, EntryPoint = "virNodeNumOfDevices", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeNumOfDevices(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr)] string @cap, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNodeListDevices", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeListDevices(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr)] string @cap, out IntPtr @names, int @maxnames, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virConnectListAllNodeDevices", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectListAllNodeDevices(virConnectPtr @conn, out IntPtr @devices, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNodeDeviceLookupByName", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virNodeDevicePtr virNodeDeviceLookupByName(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr)] string @name);

        [DllImport(libraryPath, EntryPoint = "virNodeDeviceLookupSCSIHostByWWN", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virNodeDevicePtr virNodeDeviceLookupSCSIHostByWWN(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr)] string @wwnn, [MarshalAs(UnmanagedType.LPStr)] string @wwpn, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNodeDeviceGetName", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern string virNodeDeviceGetName(virNodeDevicePtr @dev);

        [DllImport(libraryPath, EntryPoint = "virNodeDeviceGetParent", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern string virNodeDeviceGetParent(virNodeDevicePtr @dev);

        [DllImport(libraryPath, EntryPoint = "virNodeDeviceNumOfCaps", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeDeviceNumOfCaps(virNodeDevicePtr @dev);

        [DllImport(libraryPath, EntryPoint = "virNodeDeviceListCaps", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeDeviceListCaps(virNodeDevicePtr @dev, out IntPtr @names, int @maxnames);

        [DllImport(libraryPath, EntryPoint = "virNodeDeviceGetXMLDesc", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern IntPtr virNodeDeviceGetXMLDesc(virNodeDevicePtr @dev, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNodeDeviceRef", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeDeviceRef(virNodeDevicePtr @dev);

        [DllImport(libraryPath, EntryPoint = "virNodeDeviceFree", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeDeviceFree(virNodeDevicePtr @dev);

        [DllImport(libraryPath, EntryPoint = "virNodeDeviceDettach", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeDeviceDettach(virNodeDevicePtr @dev);

        [DllImport(libraryPath, EntryPoint = "virNodeDeviceDetachFlags", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeDeviceDetachFlags(virNodeDevicePtr @dev, [MarshalAs(UnmanagedType.LPStr)] string @driverName, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNodeDeviceReAttach", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeDeviceReAttach(virNodeDevicePtr @dev);

        [DllImport(libraryPath, EntryPoint = "virNodeDeviceReset", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeDeviceReset(virNodeDevicePtr @dev);

        [DllImport(libraryPath, EntryPoint = "virNodeDeviceCreateXML", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virNodeDevicePtr virNodeDeviceCreateXML(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr)] string @xmlDesc, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNodeDeviceDestroy", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNodeDeviceDestroy(virNodeDevicePtr @dev);

        [DllImport(libraryPath, EntryPoint = "virConnectNumOfNWFilters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectNumOfNWFilters(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virConnectListNWFilters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectListNWFilters(virConnectPtr @conn, out IntPtr @names, int @maxnames);

        [DllImport(libraryPath, EntryPoint = "virConnectListAllNWFilters", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectListAllNWFilters(virConnectPtr @conn, out IntPtr @filters, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virNWFilterLookupByName", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virNWFilterPtr virNWFilterLookupByName(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr)] string @name);

        [DllImport(libraryPath, EntryPoint = "virNWFilterLookupByUUID", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virNWFilterPtr virNWFilterLookupByUUID(virConnectPtr @conn, IntPtr @uuid);

        [DllImport(libraryPath, EntryPoint = "virNWFilterLookupByUUIDString", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virNWFilterPtr virNWFilterLookupByUUIDString(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr)] string @uuid);

        [DllImport(libraryPath, EntryPoint = "virNWFilterDefineXML", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virNWFilterPtr virNWFilterDefineXML(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr)] string @xmlDesc);

        [DllImport(libraryPath, EntryPoint = "virNWFilterUndefine", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNWFilterUndefine(virNWFilterPtr @nwfilter);

        [DllImport(libraryPath, EntryPoint = "virNWFilterRef", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNWFilterRef(virNWFilterPtr @nwfilter);

        [DllImport(libraryPath, EntryPoint = "virNWFilterFree", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNWFilterFree(virNWFilterPtr @nwfilter);

        [DllImport(libraryPath, EntryPoint = "virNWFilterGetName", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern string virNWFilterGetName(virNWFilterPtr @nwfilter);

        [DllImport(libraryPath, EntryPoint = "virNWFilterGetUUID", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNWFilterGetUUID(virNWFilterPtr @nwfilter, IntPtr @uuid);

        [DllImport(libraryPath, EntryPoint = "virNWFilterGetUUIDString", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virNWFilterGetUUIDString(virNWFilterPtr @nwfilter, IntPtr @buf);

        [DllImport(libraryPath, EntryPoint = "virNWFilterGetXMLDesc", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern IntPtr virNWFilterGetXMLDesc(virNWFilterPtr @nwfilter, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virSecretGetConnect", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virConnectPtr virSecretGetConnect(virSecretPtr @secret);

        [DllImport(libraryPath, EntryPoint = "virConnectNumOfSecrets", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectNumOfSecrets(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virConnectListSecrets", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectListSecrets(virConnectPtr @conn, out IntPtr @uuids, int @maxuuids);

        [DllImport(libraryPath, EntryPoint = "virConnectListAllSecrets", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectListAllSecrets(virConnectPtr @conn, out IntPtr @secrets, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virSecretLookupByUUID", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virSecretPtr virSecretLookupByUUID(virConnectPtr @conn, IntPtr @uuid);

        [DllImport(libraryPath, EntryPoint = "virSecretLookupByUUIDString", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virSecretPtr virSecretLookupByUUIDString(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr)] string @uuid);

        [DllImport(libraryPath, EntryPoint = "virSecretLookupByUsage", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virSecretPtr virSecretLookupByUsage(virConnectPtr @conn, int @usageType, [MarshalAs(UnmanagedType.LPStr)] string @usageID);

        [DllImport(libraryPath, EntryPoint = "virSecretDefineXML", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virSecretPtr virSecretDefineXML(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr)] string @xml, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virSecretGetUUID", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virSecretGetUUID(virSecretPtr @secret, IntPtr @buf);

        [DllImport(libraryPath, EntryPoint = "virSecretGetUUIDString", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virSecretGetUUIDString(virSecretPtr @secret, IntPtr @buf);

        [DllImport(libraryPath, EntryPoint = "virSecretGetUsageType", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virSecretGetUsageType(virSecretPtr @secret);

        [DllImport(libraryPath, EntryPoint = "virSecretGetUsageID", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern string virSecretGetUsageID(virSecretPtr @secret);

        [DllImport(libraryPath, EntryPoint = "virSecretGetXMLDesc", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern IntPtr virSecretGetXMLDesc(virSecretPtr @secret, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virSecretSetValue", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virSecretSetValue(virSecretPtr @secret, IntPtr @value, UIntPtr @value_size, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virSecretGetValue", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern IntPtr virSecretGetValue(virSecretPtr @secret, IntPtr @value_size, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virSecretUndefine", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virSecretUndefine(virSecretPtr @secret);

        [DllImport(libraryPath, EntryPoint = "virSecretRef", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virSecretRef(virSecretPtr @secret);

        [DllImport(libraryPath, EntryPoint = "virSecretFree", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virSecretFree(virSecretPtr @secret);

        //DO NOT USE ACCORDING TO DOCUMENTATION  http://libvirt.org/html/libvirt-libvirt-storage.html#virStoragePoolGetConnect
        //[DllImport(libraryPath, EntryPoint = "virStoragePoolGetConnect", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        // public static extern virConnectPtr virStoragePoolGetConnect(virStoragePoolPtr @pool);

        [DllImport(libraryPath, EntryPoint = "virConnectNumOfStoragePools", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectNumOfStoragePools(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virConnectListStoragePools", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectListStoragePools(virConnectPtr @conn, IntPtr @names, int @maxnames);

        [DllImport(libraryPath, EntryPoint = "virConnectNumOfDefinedStoragePools", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectNumOfDefinedStoragePools(virConnectPtr @conn);

        [DllImport(libraryPath, EntryPoint = "virConnectListDefinedStoragePools", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectListDefinedStoragePools(virConnectPtr @conn, IntPtr @names, int @maxnames);

        [DllImport(libraryPath, EntryPoint = "virConnectListAllStoragePools", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnectListAllStoragePools(virConnectPtr @conn, out IntPtr @pools, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virConnectFindStoragePoolSources", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virConnectFindStoragePoolSources(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @type, [MarshalAs(UnmanagedType.LPStr), In] string @srcSpec, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolLookupByName", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virStoragePoolPtr virStoragePoolLookupByName(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @name);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolLookupByUUID", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virStoragePoolPtr virStoragePoolLookupByUUID(virConnectPtr @conn, [In] byte[] @uuid);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolLookupByUUIDString", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virStoragePoolPtr virStoragePoolLookupByUUIDString(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @uuid);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolLookupByVolume", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virStoragePoolPtr virStoragePoolLookupByVolume(virStorageVolPtr @vol);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolCreateXML", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virStoragePoolPtr virStoragePoolCreateXML(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @xmlDesc, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolDefineXML", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virStoragePoolPtr virStoragePoolDefineXML(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr)] string @xmlDesc, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolBuild", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStoragePoolBuild(virStoragePoolPtr @pool, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolUndefine", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStoragePoolUndefine(virStoragePoolPtr @pool);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolCreate", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStoragePoolCreate(virStoragePoolPtr @pool, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolDestroy", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStoragePoolDestroy(virStoragePoolPtr @pool);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolDelete", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStoragePoolDelete(virStoragePoolPtr @pool, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolRef", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStoragePoolRef(virStoragePoolPtr @pool);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolFree", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStoragePoolFree(virStoragePoolPtr @pool);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolRefresh", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStoragePoolRefresh(virStoragePoolPtr @pool, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolGetName", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithoutNativeCleanUpMarshaler))]
        public static extern string virStoragePoolGetName(virStoragePoolPtr @pool);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolGetUUID", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStoragePoolGetUUID(virStoragePoolPtr @pool, [Out] byte[] @uuid);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolGetUUIDString", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStoragePoolGetUUIDString(virStoragePoolPtr @pool, [Out] byte[] @buf);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolGetInfo", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStoragePoolGetInfo(virStoragePoolPtr @vol, ref _virStoragePoolInfo @info);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolGetXMLDesc", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virStoragePoolGetXMLDesc(virStoragePoolPtr @pool, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolGetAutostart", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStoragePoolGetAutostart(virStoragePoolPtr @pool, ref int @autostart);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolSetAutostart", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStoragePoolSetAutostart(virStoragePoolPtr @pool, int @autostart);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolNumOfVolumes", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStoragePoolNumOfVolumes(virStoragePoolPtr @pool);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolListVolumes", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStoragePoolListVolumes(virStoragePoolPtr @pool, IntPtr @names, int @maxnames);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolListAllVolumes", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStoragePoolListAllVolumes(virStoragePoolPtr @pool, out IntPtr @vols, uint @flags);

        //DO NOT USE THIS ACCORDING TO DOCUMENTATION http://libvirt.org/html/libvirt-libvirt-storage.html#virStorageVolGetConnect
        // [DllImport(libraryPath, EntryPoint = "virStorageVolGetConnect", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        // public static extern virConnectPtr virStorageVolGetConnect(virStorageVolPtr @vol);

        [DllImport(libraryPath, EntryPoint = "virStorageVolLookupByName", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virStorageVolPtr virStorageVolLookupByName(virStoragePoolPtr @pool, [MarshalAs(UnmanagedType.LPStr), In] string @name);

        [DllImport(libraryPath, EntryPoint = "virStorageVolLookupByKey", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virStorageVolPtr virStorageVolLookupByKey(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @key);

        [DllImport(libraryPath, EntryPoint = "virStorageVolLookupByPath", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virStorageVolPtr virStorageVolLookupByPath(virConnectPtr @conn, [MarshalAs(UnmanagedType.LPStr), In] string @path);

        [DllImport(libraryPath, EntryPoint = "virStorageVolGetName", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithoutNativeCleanUpMarshaler))]
        public static extern string virStorageVolGetName(virStorageVolPtr @vol);

        [DllImport(libraryPath, EntryPoint = "virStorageVolGetKey", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virStorageVolGetKey(virStorageVolPtr @vol);

        [DllImport(libraryPath, EntryPoint = "virStorageVolCreateXML", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virStorageVolPtr virStorageVolCreateXML(virStoragePoolPtr @pool, [MarshalAs(UnmanagedType.LPStr), In] string @xmldesc, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virStorageVolCreateXMLFrom", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virStorageVolPtr virStorageVolCreateXMLFrom(virStoragePoolPtr @pool, [MarshalAs(UnmanagedType.LPStr)] string @xmldesc, virStorageVolPtr @clonevol, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virStorageVolDownload", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStorageVolDownload(virStorageVolPtr @vol, virStreamPtr @stream, ulong @offset, ulong @length, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virStorageVolUpload", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStorageVolUpload(virStorageVolPtr @vol, virStreamPtr @stream, ulong @offset, ulong @length, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virStorageVolDelete", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStorageVolDelete(virStorageVolPtr @vol, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virStorageVolWipe", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStorageVolWipe(virStorageVolPtr @vol, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virStorageVolWipePattern", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStorageVolWipePattern(virStorageVolPtr @vol, uint @algorithm, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virStorageVolRef", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStorageVolRef(virStorageVolPtr @vol);

        [DllImport(libraryPath, EntryPoint = "virStorageVolFree", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStorageVolFree(virStorageVolPtr @vol);

        [DllImport(libraryPath, EntryPoint = "virStorageVolGetInfo", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStorageVolGetInfo(virStorageVolPtr @vol, ref _virStorageVolInfo @info);

        [DllImport(libraryPath, EntryPoint = "virStorageVolGetXMLDesc", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virStorageVolGetXMLDesc(virStorageVolPtr @pool, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virStorageVolGetPath", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithNativeCleanUpMarshaler))]
        public static extern string virStorageVolGetPath(virStorageVolPtr @vol);

        [DllImport(libraryPath, EntryPoint = "virStorageVolResize", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStorageVolResize(virStorageVolPtr @vol, ulong @capacity, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolIsActive", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStoragePoolIsActive(virStoragePoolPtr @pool);

        [DllImport(libraryPath, EntryPoint = "virStoragePoolIsPersistent", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStoragePoolIsPersistent(virStoragePoolPtr @pool);

        [DllImport(libraryPath, EntryPoint = "virStreamNew", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virStreamPtr virStreamNew(virConnectPtr @conn, uint @flags);

        [DllImport(libraryPath, EntryPoint = "virStreamRef", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStreamRef(virStreamPtr @st);

        [DllImport(libraryPath, EntryPoint = "virStreamSend", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStreamSend(virStreamPtr @st, [In] byte[] @data, UIntPtr @nbytes);

        [DllImport(libraryPath, EntryPoint = "virStreamRecv", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStreamRecv(virStreamPtr @st, [Out] byte[] @data, UIntPtr @nbytes);

        [DllImport(libraryPath, EntryPoint = "virStreamSendAll", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStreamSendAll(virStreamPtr @st, virStreamSourceFunc @handler, IntPtr @opaque);

        [DllImport(libraryPath, EntryPoint = "virStreamRecvAll", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStreamRecvAll(virStreamPtr @st, virStreamSinkFunc @handler, IntPtr @opaque);

        [DllImport(libraryPath, EntryPoint = "virStreamEventAddCallback", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStreamEventAddCallback(virStreamPtr @stream, int @events, virStreamEventCallback @cb, IntPtr @opaque, virFreeCallback @ff);

        [DllImport(libraryPath, EntryPoint = "virStreamEventUpdateCallback", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStreamEventUpdateCallback(virStreamPtr @stream, int @events);

        [DllImport(libraryPath, EntryPoint = "virStreamEventRemoveCallback", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStreamEventRemoveCallback(virStreamPtr @stream);

        [DllImport(libraryPath, EntryPoint = "virStreamFinish", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStreamFinish(virStreamPtr @st);

        [DllImport(libraryPath, EntryPoint = "virStreamAbort", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStreamAbort(virStreamPtr @st);

        [DllImport(libraryPath, EntryPoint = "virStreamFree", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virStreamFree(virStreamPtr @st);

        [DllImport(libraryPath, EntryPoint = "virConnCopyLastError", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virConnCopyLastError(virConnectPtr conn, [Out] virErrorPtr to);

        [DllImport(libraryPath, EntryPoint = "virConnGetLastError", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virErrorPtr virConnGetLastError(virConnectPtr conn);

        [DllImport(libraryPath, EntryPoint = "virGetLastError", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virErrorPtr virGetLastError();


        [DllImport(libraryPath, EntryPoint = "virSaveLastError", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern virErrorPtr virSaveLastError();
        [DllImport(libraryPath, EntryPoint = "virResetLastError", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern void virResetLastError();
        [DllImport(libraryPath, EntryPoint = "virResetError", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern void virResetError(virErrorPtr err);
        [DllImport(libraryPath, EntryPoint = "virFreeError", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern void virFreeError(virErrorPtr err);
        [DllImport(libraryPath, EntryPoint = "virGetLastErrorMessage", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringWithoutNativeCleanUpMarshaler))]
        public static extern string virGetLastErrorMessage();
        [DllImport(libraryPath, EntryPoint = "virConnResetLastError", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern void virConnResetLastError(virConnectPtr conn);
        [DllImport(libraryPath, EntryPoint = "virCopyLastError", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern int virCopyLastError([Out] virErrorPtr to);

        [DllImport(libraryPath, EntryPoint = "virDefaultErrorFunc", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern void virDefaultErrorFunc(virErrorPtr err);
        [DllImport(libraryPath, EntryPoint = "virSetErrorFunc", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern void virSetErrorFunc(IntPtr userData, virErrorFunc handler);
        [DllImport(libraryPath, EntryPoint = "virConnSetErrorFunc", CallingConvention = CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public static extern void virConnSetErrorFunc(virConnectPtr conn, IntPtr userData, virErrorFunc handler);


    }
}
