namespace Imtihon22.Model;

public class User : General
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string UserName { get; set; }
    private string password;

    public User(string password)
    {
        this.password = password;
    }

    public User()
    {

    }

    public UserRole Role { get; set; }


    public bool CheckPassword(string password) =>
        password == this.password;
}

