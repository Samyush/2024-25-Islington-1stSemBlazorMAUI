using _2024_25_Islington_1stSemBlazorMAUI.Model;

namespace _2024_25_Islington_1stSemBlazorMAUI.Services.Interface;

public interface IUserService
{
    bool Login(User user);

    bool Register(User user);

    bool DeleteUser(string username);

    List<User> GetAllUsers();
}

