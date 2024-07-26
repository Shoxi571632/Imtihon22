using Imtihon22.Service;

namespace Imtihon22.Views;

public partial class View
{
    public View()
    {
        librarySectionService = new LibrarySectionService();
        this.userService = new UserService();
    }
    public void MainMenu()
    {
        Console.WriteLine("Paroli: 2208");
        Console.WriteLine("Neme : Shoxrux");
        Console.WriteLine("1. LogIn\n" +
            "2. Register");
        int opt = int.Parse(Console.ReadLine());
        Console.Clear();

        if (opt == 1)
        {
            LoginMenu();
        }
    }
}
