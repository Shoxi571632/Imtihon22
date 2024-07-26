using Imtihon22.Model;

namespace Imtihon22.Service;

public class LibrarySectionService
{
    private List<LibrarySection> librarySections;

    public List<LibrarySection> LibrarySections => librarySections;

    int id;


    public LibrarySectionService()
    {
        librarySections = new List<LibrarySection>();
        id = 0;
    }

    public bool Add(LibrarySection librarySection)
    {
        librarySection.Id = id + 1;
        if (CheckLibrarySection(librarySection.Id) is true)
        {
            return false;
        }

        librarySections.Add(librarySection);
        id++;

        return true;
     
    }


    bool CheckLibrarySection(int id)
    {
        foreach (LibrarySection librarySection in librarySections)
        {
            if (librarySection.Id == id)
            {
                return true;
            }
        }

        return false;
    }
}

