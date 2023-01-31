using SpoiledRabbot.Extensions;

namespace SpoiledRabbot.Models;

public class UserInfo
{
    private string _password = string.Empty;

    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string LineUserId { get; set; } = string.Empty;
    public string Password
    {
        get => _password;
        set => _password = value.ToSHA512();
    }
    public string Username { get; set; } = string.Empty;

    public UserInfo ToInfo()
    {
        Password = string.Empty;
        return this;
    }
}