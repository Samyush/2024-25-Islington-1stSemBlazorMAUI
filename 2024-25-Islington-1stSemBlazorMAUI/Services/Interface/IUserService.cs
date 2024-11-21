using _2024_25_Islington_1stSemBlazorMAUI.Model;

namespace _2024_25_Islington_1stSemBlazorMAUI.Services.Interface;

public interface IUserService
{
    bool Login(string username, string password);

    bool Register(string username, string password);

    bool DeleteUser(string username);

    List<User> GetAllUsers();
}

