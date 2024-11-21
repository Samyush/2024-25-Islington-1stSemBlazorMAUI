namespace _2024_25_Islington_1stSemBlazorMAUI.Pages;
public partial class Register
{
    private string Username = "";
    private string Password = "";
    private string? Message;

    private void RegisterUser()
    {
        if (UserService.Register(Username, Password))
        {
            Message = "User registered successfully!";
        }
        else
        {
            Message = "Username already exists.";
        }
    }
}