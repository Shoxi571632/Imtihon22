using Imtihon22.Model;

namespace Imtihon22.Service;

public class UserService
{
    public UserService()
    {
        users = new List<User>
        {
            new User(password : "2208")
            {
                Id = 1,
                FirstName = "Shoxrux",
                LastName = "Ismatullayev",
                Role = UserRole.Admin,
                UserName = "Shoxrux"
            }
        };

        id = 0;
    }
    int id;

    private List<User> users { get; set; }

    public UserRole? LogIn(string username, string password)
    {
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].UserName == username &&
                users[i].CheckPassword(password))
            {
                return users[i].Role;
            }
        }

        return null;
    }

    public bool Register(User user)
    {
        if (FindUserByUserName(user.UserName) is null)
            return false;

        user.Id = id++;
        users.Add(user);

        return true;
    }

    User? FindUserByUserName(string username)
    {
        foreach (var user in users)
        {
            if (user.UserName == username)
                return user;
        }

        return null;
    }
}
