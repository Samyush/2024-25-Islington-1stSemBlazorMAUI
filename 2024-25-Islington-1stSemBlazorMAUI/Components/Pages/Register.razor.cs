using _2024_25_Islington_1stSemBlazorMAUI.Model;

namespace _2024_25_Islington_1stSemBlazorMAUI.Components.Pages;
public partial class Register 
{
    private string? Message;

    private User Users {  get; set; } = new User();

    private async void RegisterUser()
    {
        if (UserService.Register(Users))
        {
            Message = "User registered successfully!";
            Nav.NavigateTo("/login");
        }
        else
        {
            Message = "Username already exists.";
        }
    }
}