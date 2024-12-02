using _2024_25_Islington_1stSemBlazorMAUI.Abstraction;
using _2024_25_Islington_1stSemBlazorMAUI.Model;
using _2024_25_Islington_1stSemBlazorMAUI.Services.Interface;

namespace _2024_25_Islington_1stSemBlazorMAUI.Services;

// UserService class for managing user operations such as login, registration, and deletion.
public class UserService : UserBase, IUserService
{
    // Stores the list of users loaded from the file.
    private List<User> _users;

    // Default admin username and password for initial seeding.
    public const string SeedUsername = "admin";
    public const string SeedPassword = "password";

    // Constructor to initialize the user service.
    public UserService()
    {
        // Load the list of users from the JSON file.
        _users = LoadUsers();

        // If no users are present, add a default admin user and save to the file.
        if (!_users.Any())
        {
            _users.Add(new User { Username = SeedUsername, Password = SeedPassword });
            SaveUsers(_users);
        }
    }

    // Deletes a user by username. Returns true if the user was deleted, false if not found.
    public bool DeleteUser(string username)
    {
        // Find the user with the specified username.
        var user = _users.FirstOrDefault(u => u.Username == username);
        if (user == null) // If no user is found, return false.
            return false;

        // Remove the user from the list and save the updated list to the file.
        _users.Remove(user);
        SaveUsers(_users);
        return true;
    }

    // Retrieves the list of all users.
    public List<User> GetAllUsers()
    {
        return _users; // Return the in-memory list of users.
    }

    // Logs in a user by checking if their username and password exist in the list.
    // Returns true if the user is authenticated, false otherwise.
    public bool Login(User user)
    {
        // Validate input for null or empty values.
        if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
        {
            return false; // Invalid input.
        }

        // Check if the username and password match any user in the list.
        return _users.Any(u => u.Username == user.Username && u.Password == user.Password);
    }

    // Registers a new user. Returns false if the username already exists, true if registration is successful.
    public bool Register(User user)
    {
        // Check if the username already exists in the list.
        if (_users.Any(u => u.Username == user.Username))
            return false; // Registration failed: user already exists.

        // Add the new user to the list and save the updated list to the file.
        _users.Add(new User { Username = user.Username, Password = user.Password });
        SaveUsers(_users);
        return true;
    }
}

