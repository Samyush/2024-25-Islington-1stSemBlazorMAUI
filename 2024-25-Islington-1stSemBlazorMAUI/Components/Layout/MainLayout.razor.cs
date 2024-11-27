using _2024_25_Islington_1stSemBlazorMAUI.Model;

namespace _2024_25_Islington_1stSemBlazorMAUI.Components.Layout
{
    public partial class MainLayout
    {
        private GlobalState _globalState = new();

        private void LogoutHandler()
        {
            if (_globalState.CurrentUser == null)
            {
                Navigation.NavigateTo("/login");
            }
        }

    }
}