using _2024_25_Islington_1stSemBlazorMAUI.Model;
using _2024_25_Islington_1stSemBlazorMAUI.Services.Interface;

namespace _2024_25_Islington_1stSemBlazorMAUI.Services;

public class UserService : UserBase, IUserService
{
    private List<User> _users;
    public UserService()
    {
        _users = LoadUsers();

        // Add default admin user if the file is empty
        if (!_users.Any())
        {
            _users.Add(new User { Username = "admin", Password = "password" });
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

    public bool Login(string username, string password)
    {
        return _users.Any(u => u.Username == username && u.Password == password);
    }

    public bool Register(string username, string password)
    {
        if (_users.Any(u => u.Username == username))
            return false; // User already exists

        _users.Add(new User { Username = username, Password = password });
        SaveUsers(_users);
        return true;
    }
}
