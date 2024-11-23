using _2024_25_Islington_1stSemBlazorMAUI.Model;

namespace _2024_25_Islington_1stSemBlazorMAUI.Components.Pages;

public partial class Login 
{
    private string? ErrorMessage;

    public User Users { get; set; } = new();

    private async void HandleLogin()
    {
        if (UserService.Login(Users))
        {
            Nav.NavigateTo("/home");
        }
        else
        {
            ErrorMessage = "Invalid username or password.";
        }
    }

    private async void HandleRegister()
    {
        Nav.NavigateTo("/register");
    }
}