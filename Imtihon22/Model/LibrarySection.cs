namespace Imtihon22.Model;

public class LibrarySection : General
{
    public string Name { get; set; }
    public int Capacity { get; set; }
    public int ShelfCount { get; set; }
    public string Description { get; set; }
    public LibrarySectionType Type { get; set; }

    public override string ToString()
    {
        return $"name : {Name}, capacity : {Capacity}, shelf count : {ShelfCount}, " +
            $"description : {Description}, Type : {Type}";
    }

}