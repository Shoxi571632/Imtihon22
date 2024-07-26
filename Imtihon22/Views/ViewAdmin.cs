using Imtihon22.Model;
using Imtihon22.Service;

namespace Imtihon22.Views;

public partial class View
{
    private readonly LibrarySectionService librarySectionService;

    void AdminMenu()
    {
        (int operationOpt, int option) adminOption = AdminConsole();

        switch (adminOption.option)
        {
            case 1:
                SectionMenu(adminOption.operationOpt);
                break;
            case 2:
                //BookMenu(adminOption.operationOpt);
                break;
        }
    }

    private void SectionMenu(int operationOpt)
    {
        switch (operationOpt)
        {
            case 1:
                AddSection();
                break;
            case 2:
                UpdateSection();
                break;
            case 3:
                DeleteSection();
                break;
            case 4:
                GetAllSections();
                break;

        }

        Console.WriteLine("1. Ortga");
        int back = int.Parse(Console.ReadLine());
        if (back == 1)
            AdminMenu();


        void DeleteSection()
        {
            var sections = GetAllSections();

            int opt = int.Parse(Console.ReadLine());

            if (!(sections.Count > opt && opt >= 0))
            {
                Console.WriteLine("To'gri kirit");
                DeleteSection();
            }

            sections.RemoveAt(opt - 1);

            Console.WriteLine("Deleted successfully");
        }



        void UpdateSection()
        {
            var sections = GetAllSections();
            int opt = int.Parse(Console.ReadLine());

            LibrarySection selectedlibrarySection = sections[opt - 1];

            UpdateData(selectedlibrarySection);

        }




        void UpdateData(LibrarySection selectedlibrarySection)
        {
            Console.Write("Name : ");
            string name = Console.ReadLine();
            selectedlibrarySection.Name = name is "" ? selectedlibrarySection.Name : name;

            Console.Write("Description : ");
            string desc = Console.ReadLine();
            selectedlibrarySection.Description = desc is "" ? selectedlibrarySection.Description : name;

            Console.Write("Shelf Count : ");
            string shCount = Console.ReadLine();
            selectedlibrarySection.ShelfCount = shCount is "" ? selectedlibrarySection.ShelfCount : int.Parse(shCount);

            Console.Write("Capacity : ");
            string capacity = Console.ReadLine();
            selectedlibrarySection.Capacity = capacity is "" ? selectedlibrarySection.Capacity : int.Parse(capacity);

            Console.WriteLine("Type : ");
            int typeCount = 1;
            foreach (var typeName in Enum.GetNames(typeof(LibrarySectionType)))
            {
                Console.WriteLine($"{typeCount++}. {typeName}");
            }

            int typeIndex = int.Parse(Console.ReadLine());

            selectedlibrarySection.Type = typeIndex is 0 ? selectedlibrarySection.Type : (LibrarySectionType)typeIndex;
        }



        List<LibrarySection> GetAllSections()
        {
            List<LibrarySection> sections = librarySectionService.LibrarySections;

            int count = 1;
            foreach (LibrarySection section in sections)
            {
                Console.WriteLine($"{count++}.{section}");
            }
            return sections;

        }



        void AddSection()
        {
            Console.Write("Section Name : ");
            string sectionName = Console.ReadLine();
            //Bo'lim nomi

            Console.Write("Capacity : ");
            int capacity = int.Parse(Console.ReadLine());
            //Imkoniyat
            Console.Write("Shelf count : ");
            int shelfCount = int.Parse(Console.ReadLine());
            //Raflar soni

            Console.Write("Description : ");
            string description = Console.ReadLine();
            //Tavsiv

            Console.WriteLine("Section Type : ");
            //Bo'lim turi

            string[] sectionTypeNames = Enum.GetNames(typeof(LibrarySectionType));

            int count = 1;
            foreach (string sectionTypeName in sectionTypeNames)
            {
                Console.WriteLine($"{count++}. {sectionTypeName}");
            }

            LibrarySectionType sectionType = (LibrarySectionType)int.Parse(Console.ReadLine());

            bool iscreated = librarySectionService.Add(new LibrarySection()
            {
                Capacity = capacity,
                Description = description,
                Name = sectionName,
                ShelfCount = shelfCount,
                Type = sectionType
            });

            if (!iscreated)
            {
                Console.WriteLine("Xatolik yuzaga keldi!!!");
                AdminMenu();
            }

            Console.WriteLine("Muvaffaqqiyatli qo'shildi !!!");
            Console.Clear();

        }
    }


    (int, int) AdminConsole()
    {
        Console.WriteLine("1. Add\n" +
                      "2. Update\n" +
                      "3. Delete\n" +
                      "4. Get All");
        

        int crudOption = int.Parse(Console.ReadLine());

        Console.WriteLine("1. Section\n" +
                          "2. Book");
        int option = int.Parse(Console.ReadLine());
        Console.Clear();

        return (crudOption, option);
    }
}
