

namespace Libvirt_WebManager.ViewModels
{
    public class TreeViewModel
    {
        public enum Node_Types { Host, Domains, Interfaces, Storage_Pools, Domain }
        public string Name { get; set; }
        public string Path { get; set; }
        public Node_Types Node_Type { get; set; }
        public bool IsDirectory { get; set; }
        public string UniqueID
        {
            get
            {
                return Path.Replace('/', '_');
            }
        }
    }
}

