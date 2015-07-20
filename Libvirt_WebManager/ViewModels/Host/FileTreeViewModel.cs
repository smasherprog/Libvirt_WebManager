public class TreeViewModel
{
    public string Name { get; set; }
    public string css_class { get; set; }
    public string Path { get; set; }
    public bool IsDirectory { get; set; }
    public string UniqueID
    {
        get
        {
            return Path.Replace('/', '_');
        }
    }
}
