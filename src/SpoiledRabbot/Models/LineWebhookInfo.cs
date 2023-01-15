using Newtonsoft.Json;

namespace SpoiledRabbot.Models;

public class LineWebhookRequest
{
    [JsonProperty("events")]
    public List<Event> Events { get; set; } = new List<Event>();
    [JsonProperty("destination")]
    public string Destination { get; set; } = string.Empty;
}

public class Event
{
    [JsonProperty("type")]
    public string Type { get; set; } = string.Empty;
    [JsonProperty("replyToken")]
    public string ReplyToken { get; set; } = string.Empty;
    [JsonProperty("source")]
    public LineSource Source { get; set; } = new LineSource();
    [JsonProperty("timestamp")]
    public long Timestamp { get; set; }
    [JsonProperty("mode")]
    public string Mode { get; set; } = string.Empty;
    [JsonProperty("message")]
    public LineMessage Message { get; set; } = new LineMessage();
    [JsonProperty("postback")]
    public LinePostback Postback { get; set; } = new LinePostback();
}

public class LineMessage
{
    [JsonProperty("type")]
    public string Type { get; set; } = string.Empty;
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;
    [JsonProperty("text")]
    public string Text { get; set; } = string.Empty;
}

public class LinePostback
{
    [JsonProperty("data")]
    public string Data { get; set; } = string.Empty;
    [JsonProperty("params")]
    public LinePostbackParams Params { get; set; } = new LinePostbackParams();
}

public class LinePostbackParams
{
    [JsonProperty("date")]
    public DateTime Date { get; set; }
    [JsonProperty("datetime")]
    public DateTime Datetime { get; set; }
    [JsonProperty("time")]
    public TimeSpan Time { get; set; }
}

public class LineSource
{
    [JsonProperty("userId")]
    public string UserId { get; set; } = string.Empty;
    [JsonProperty("type")]
    public string Type { get; set; } = string.Empty;
}