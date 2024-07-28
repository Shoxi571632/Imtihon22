using Imtihon22.Model;
using System.Text.Json;

namespace Imtihon22.Service;

internal class JsonOperations
{
    public static List<User> users = new List<User>();
    public static List<Book> books = new List<Book>();
    const string UserFilePath = @"C:\Users\99891\OneDrive\Ishchi stol\G7\Imtihon22\Imtihon22\JsonFiles\Users.json";
    const string BookFilePath = @"C:\Users\99891\OneDrive\Ishchi stol\G7\Imtihon22\Imtihon22\JsonFiles\Books.json";

    public static void LoadData()
    {
        try
        {
            if (File.Exists(UserFilePath))
            {
                var userData = File.ReadAllText(UserFilePath);
                if (!string.IsNullOrWhiteSpace(userData))
                {
                    users = JsonSerializer.Deserialize<List<User>>(userData) ?? new List<User>();
                }
            }

            if (File.Exists(BookFilePath))
            {
                var bookData = File.ReadAllText(BookFilePath);
                if (!string.IsNullOrWhiteSpace(bookData))
                {
                    books = JsonSerializer.Deserialize<List<Book>>(bookData) ?? new List<Book>();
                }
            }
        }
        catch (JsonException)
        {
            Console.WriteLine("Error reading JSON data. Starting with an empty list.");
            users = new List<User>();
            books = new List<Book>();
        }
    }

    public static void SaveData()
    {
        try
        {
            var userData = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(UserFilePath, userData);

            var bookData = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(BookFilePath, bookData);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving data: {ex.Message}");
        }
    }
}
