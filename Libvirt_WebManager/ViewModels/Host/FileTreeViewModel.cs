public class TreeViewModel
{
    public string Name { get; set; }
    public string Ext { get; set; }
    public string Path { get; set; }
    public bool IsDirectory { get; set; }

    public string PathAltSeparator()
    { 
        return Path.Replace("\\", "/");
    }

}
