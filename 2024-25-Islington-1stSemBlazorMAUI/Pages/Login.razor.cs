namespace _2024_25_Islington_1stSemBlazorMAUI.Pages;

public partial class Login
{
    private string Username = "";
    private string Password = "";
    private string? ErrorMessage;

    private void HandleLogin()
    {
        if (UserService.Login(Username, Password))
        {
            ErrorMessage = null;
            Navigation.NavigateTo("/home");
        }
        else
        {
            ErrorMessage = "Invalid username or password.";
        }
    }

    private void HandleRegister()
    {
        Navigation.NavigateTo("/register");
    }
}