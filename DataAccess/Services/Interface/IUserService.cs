using DataModel.Model;

namespace DataAccess.Services.Interface;
public interface IUserService
{
    /// Logs in a user using their credentials.
    Task<bool> Login(User user);

    /// Registers a new user into the system.
    Task<bool> Register(User user);

    /// Deletes a user by their username.
    Task<bool> DeleteUser(string username);

    /// Retrieves all users from the system.
    Task<List<User>> GetAllUsers();

    /// Searches for users based on their name.
    Task<List<User>> SearchUser(string searchName);
}

