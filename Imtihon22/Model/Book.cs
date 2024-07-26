namespace Imtihon22.Model;

public class Book : General
{
    public string Name { get; set; }
    public string ISBN { get; set; }
    public short Page { get; set; }
    public User Author { get; set; }
}
