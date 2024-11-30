using DataModel.Model;
using Microsoft.AspNetCore.Components;

namespace _2024_25_Islington_1stSemBlazorMAUI.Components.Pages;

public partial class Home :ComponentBase
{
    private List<User> Users = new();

    private List<User> Filtered = new();

    private string? Message = string.Empty;

    private bool IslogOut {  get; set; }  = false;

    #region Initialized Method
    protected async override void OnInitialized()
    {
        Filtered = await UserService.GetAllUsers();
    }

    #endregion

    #region GetAllUsers
    private async Task<List<User>> GetAllUsers()
    {
        try
        {
            Users = await UserService.GetAllUsers();

            return Users;

        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    #endregion

    #region DeleteUsers
    private async Task DeleteUser(string username)
    {
        var result = await UserService.DeleteUser(username);

        if (result)
        {
            Message = "User deleted successfully.";
            // Users = await UserService.GetAllUsers(); // Reload users
        }
        else
        {
            Message = "User could not be deleted.";
        }

        // Message = result ? "Successfully Deleted" : "Error Deleting User";
    }
    #endregion

    #region  LoginPopup
    private async void ShowLogoutConfirmation()
    {
        IslogOut = true;
    }

    private async void HideLogoutConfirmation()
    {
        IslogOut = false;
    }
    #endregion

    #region Logout
    private async void Logout()
    {
        Nav.NavigateTo("/login");
    }
    #endregion

    #region  Search
    private string _search = string.Empty;

    private async Task FilteredUsers()
    {
        try
        {
            if (String.IsNullOrWhiteSpace(Search))
            {
                Filtered = await UserService.GetAllUsers();
                Message = string.Empty;
                return;
            }
            Filtered = await UserService.SearchUser(Search);

            if (!Filtered.Any())
            {
                Message = "No Match Users Found";
            }
        }
        catch (Exception ex)
        {
            Message = ex.Message;   
        }
    }

    private string Search
    {
        get => _search;

        set {
            if(_search == value) return;
            _search = value;
            _ = OnSearchInputAsync(_search);
        }
    }
    private async Task OnSearchInputAsync(string search)
    {
        Search = search;
        await FilteredUsers();
        StateHasChanged();
    }
    #endregion
}
