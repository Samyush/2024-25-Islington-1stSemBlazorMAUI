using _2024_25_Islington_1stSemBlazorMAUI.Model;

namespace _2024_25_Islington_1stSemBlazorMAUI.Services.Interface;
public interface IUserService
{
    void RegisterUser(UserBase user);

    UserBase? Login(string username, string password);

    void DeleteUser(string username);

    List<UserBase> GetAllUsers();
}

