using Imtihon22.Model;
using Imtihon22.Service;

namespace Imtihon22.Views;

public partial class View
{
    private readonly UserService userService;

    void LoginMenu()
    {
        Console.Write("Username : ");
        string username = Console.ReadLine();

        Console.Write("Password : ");
      
        string password = Console.ReadLine();
        Console.Clear();

        UserRole? enteredUser = userService.LogIn(username, password);

        if (enteredUser is null)
        {
            Console.WriteLine("Username yoki password xato !!!");

            MainMenu();
        }

        switch (enteredUser)
        {
            case UserRole.Admin:
                AdminMenu();
                break;
            case UserRole.Reader:
                ReaderMenu();
                break;
        }
    }
}

