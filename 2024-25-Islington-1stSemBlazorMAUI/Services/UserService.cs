using _2024_25_Islington_1stSemBlazorMAUI.Model;
using _2024_25_Islington_1stSemBlazorMAUI.Services.Interface;
using System.Text.Json;

namespace _2024_25_Islington_1stSemBlazorMAUI.Services;

public class UserService : IUserService
{
    private static readonly string FilePath = Path.Combine(
         Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
         "users.json");

    private List<UserBase> users = new();

    public UserService()
    {
        //LoadUsers();

        if (!users.Any())
        {
            users.Add(new AdminUser
            {
                Username = "admin",
                Password = "password",
            });

            SaveUsers();
        }
    }

    public void DeleteUser(string username)
    {
        var user = users.FirstOrDefault(u => u.Username == username);
        if (user != null)
        {
            users.Remove(user);
            SaveUsers();
        }
    }

    public List<UserBase> GetAllUsers()
    {
       return users; 
    }

    public UserBase? Login(string username, string password)
    {
        return users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }

    public void RegisterUser(UserBase user)
    {
        if (users.Any(u => u.Username == user.Username))
            throw new Exception("User already exists!");

        users.Add(user);
        SaveUsers();
    }

    private void LoadUsers()
    {
        if (File.Exists(FilePath))
        {
            var json = File.ReadAllText(FilePath);
            users = JsonSerializer.Deserialize<List<UserBase>>(json) ?? new List<UserBase>();
        }
    }

    private void SaveUsers()
    {
        var json = JsonSerializer.Serialize(users);
        File.WriteAllText(FilePath, json);
    }
}
