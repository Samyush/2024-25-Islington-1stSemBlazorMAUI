using DataModel.Model;
using System.Text.Json;
public abstract class UserBase
{
    // This file will be stored in the app's local application data directory.
    // The file name is "users.json".

    protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "users.json");

    /// A list of users. If the file does not exist or is empty, returns an empty list.
    protected List<User> LoadUsers()
    {
        if (!File.Exists(FilePath)) return new List<User>();
        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
    }

    /// Saves the list of users to a JSON file.
    protected void SaveUsers(List<User> users)
    {
        var json = JsonSerializer.Serialize(users);
        File.WriteAllText(FilePath, json);
    }
}
