using _2024_25_Islington_1stSemBlazorMAUI.Model;
using _2024_25_Islington_1stSemBlazorMAUI.Services.Interface;

namespace _2024_25_Islington_1stSemBlazorMAUI.Services;

public class UserService : UserBase, IUserService
{
    private List<User> _users;

    public const string SeedUsername = "admin";
    public const string SeedPassword = "password";
    public UserService()
    {
        _users = LoadUsers();

        // Add default admin user if the file is empty
        if (!_users.Any())
        {
            _users.Add(new User { Username = SeedUsername, Password = SeedPassword });
            SaveUsers(_users);
        }
    }

    public bool DeleteUser(string username)
    {
        var user = _users.FirstOrDefault(u => u.Username == username);
        if (user == null)
            return false;

        _users.Remove(user);
        SaveUsers(_users);
        return true;
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }

    public bool Login(User user)
    {
        if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
        {
            return false;
        }
        return _users.Any(u => u.Username == user.Username && u.Password == u.Password);
    }

    public bool Register(User user)
    {
        if (_users.Any(u => u.Username == user.Username))
            return false; // User already exists

        _users.Add(new User { Username = user.Username, Password = user.Password });
        SaveUsers(_users);
        return true;
    }
}
