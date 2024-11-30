using DataAccess.Services.Interface;
using DataModel.Model;
using DataModel.Seeding;

namespace DataAccess.Services;

public class UserService : UserBase, IUserService
{
    private List<User> _users;

    public UserService()
    {
        _users = LoadUsers();

        // Add default admin user if the file is empty
        if (!_users.Any())
        {
            _users.Add(new User { Username = Seeding.SeedUsername, Password = Seeding.SeedPassword});
            SaveUsers(_users);
        }
    }

    // Simulated delete logic
    public async Task<bool> DeleteUser(string username)
    {
        var user = _users.FirstOrDefault(u => u.Username == username);
        if (user == null)
            return false;

        _users.Remove(user);
        SaveUsers(_users);
        return true;
    }

    // Simulated retrieval logic
    public async Task<List<User>> GetAllUsers()
    {
        return _users;
    }

    // Simulated authentication login logic
    public async Task<bool> Login(User user)
    {
        if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
        {
            return false;
        }
        return _users.Any(u => u.Username == user.Username && u.Password == u.Password);
    }

    // Simulated Register New Users logic
    public async Task<bool> Register(User user)
    {
        if ( _users.Any(u => u.Username == user.Username))
            return false; // User already exists

        _users.Add(new User { Username = user.Username, Password = user.Password });
        SaveUsers(_users);
        return true;
    }

    // Simulated SearchUser logic
    public async Task<List<User>> SearchUser(string searchName)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(searchName))
                throw new ArgumentNullException("Name Cannot be Null or Empty", nameof(searchName));

            return await Task.FromResult(
                _users.Where(u => u.Username.Contains(searchName, StringComparison.OrdinalIgnoreCase)).ToList());

        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while searching for the user.",ex);
        }   
    }
}
