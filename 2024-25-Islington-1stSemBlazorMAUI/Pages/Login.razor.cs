namespace _2024_25_Islington_1stSemBlazorMAUI.Pages;
public partial class Login
{
    private string Username = "";
    private string Password = "";
    private string? ErrorMessage;
    private string? InfoMessage;

    protected override void OnInitialized()
    {
       HandleLogin();
    }

    private void HandleLogin()
    {
        var user = UserService.Login(Username, Password);
        if (user != null)
        {
            ErrorMessage = null;
            InfoMessage = $"Welcome, {user.Username}";
            // Redirect to Home
            Navigation.NavigateTo("/");
        }
        else
        {
            ErrorMessage = "Invalid username or password.";
        }
    }
}