using System.Text.Json.Serialization;

namespace _2024_25_Islington_1stSemBlazorMAUI.Model;
public class RegularUser :UserBase
{
    public string Role { get; set; } = "User";

}

