using System.Text.Json;

namespace _2024_25_Islington_1stSemBlazorMAUI.Model;
public abstract class UserBase
{
   protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "users.json");
    protected List<User> LoadUsers()
    {
        if (!File.Exists(FilePath)) return new List<User>();
        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
    }

    protected void SaveUsers(List<User> users)
    {
        var json = JsonSerializer.Serialize(users);
        File.WriteAllText(FilePath, json);
    }
}
