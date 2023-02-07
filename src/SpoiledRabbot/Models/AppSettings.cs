namespace SpoiledRabbot.Models;

public record AppSettings
{
    public DialogflowSettings Dialogflow { get; set; } = new DialogflowSettings();
    public LineSettings Line { get; set; } = new LineSettings();
}

public record DialogflowSettings
{
    public string AgentId { get; set; } = string.Empty;
}

public record InitialUserSettings
{
    public string Password { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
}

public record LineSettings
{
    public string ChannelAccessToken { get; set; } = string.Empty;
}