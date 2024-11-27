using _2024_25_Islington_1stSemBlazorMAUI.Model;
using Microsoft.AspNetCore.Components;

namespace _2024_25_Islington_1stSemBlazorMAUI.Components.Pages
{
    public partial class Index :ComponentBase
    {

        [CascadingParameter]
        private GlobalState _globalState { get; set; }

        protected override void OnInitialized()
        {

            Nav.NavigateTo("/login");
         
        }
    }
}