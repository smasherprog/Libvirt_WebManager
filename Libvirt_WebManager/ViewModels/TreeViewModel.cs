

namespace Libvirt_WebManager.ViewModels
{
    public class TreeViewModel
    {
        public enum Node_Types { Host, Domains, Interfaces, Storage_Pools, Domain, Storage, Storage_Volume }
        public enum Node_Status_Types
        {
            VIR_DOMAIN_NOSTATE,
            VIR_DOMAIN_RUNNING ,
            VIR_DOMAIN_BLOCKED,
            VIR_DOMAIN_PAUSED ,
            VIR_DOMAIN_SHUTDOWN ,
            VIR_DOMAIN_SHUTOFF,
            VIR_DOMAIN_CRASHED ,
            VIR_DOMAIN_PMSUSPENDED ,
        }
        public Node_Status_Types Status { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public Node_Types Node_Type { get; set; }
        public bool IsDirectory { get; set; }
        public string Host { get; set; }
        public string UniqueID
        {
            get
            {
                return Path.Replace('/', '_').Replace('.', '_');
            }
        }
    }
}

