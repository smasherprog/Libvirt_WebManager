namespace Libvirt_WebManager.Areas.Storage_Pool.Models
{
    public class Storage_Volume_Down
    {
        public Storage_Volume_Down()
        {
            PoolInfo = new Libvirt._virStoragePoolInfo();
            Volume = new Storage_Volume();
        }
        public Storage_Volume Volume { get; set; }
        public Libvirt._virStoragePoolInfo PoolInfo { get; set; }

    }
}