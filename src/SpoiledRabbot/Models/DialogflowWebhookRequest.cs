using Newtonsoft.Json;

namespace SpoiledRabbot.Models;

public record DialogflowWebhookRequest
{
    public string ResponseId { get; set; } = string.Empty;
    public QueryResult QueryResult { get; set; } = new QueryResult();
    public OriginalDetectIntentRequest OriginalDetectIntentRequest { get; set; } = new OriginalDetectIntentRequest();
    public string Session { get; set; } = string.Empty;
}

public record Data
{
    public Source Source { get; set; } = new Source();
    public string Type { get; set; } = string.Empty;
    public Message Message { get; set; } = new Message();
    public string ReplyToken { get; set; } = string.Empty;
    public string Timestamp { get; set; } = string.Empty;
}

public record FulfillmentMessage
{
    public FullfillmentMessageText Text { get; set; } = new FullfillmentMessageText();
}

public record Intent
{
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
}

public record Message
{
    public string Id { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}

public record OriginalDetectIntentRequest
{
    public string Source { get; set; } = string.Empty;
    public Payload Payload { get; set; } = new Payload();
}

public record OutputContext
{
    public string Name { get; set; } = string.Empty;
    public Parameters Parameters { get; set; } = new Parameters();
}

public record Parameters
{
    public string Calc { get; set; } = string.Empty;

    [JsonProperty("no-input")]
    public double NoInput { get; set; }

    [JsonProperty("no-match")]
    public double NoMatch { get; set; }

    [JsonProperty("any.original")]
    public string AnyOriginal { get; set; } = string.Empty;
}

public record Payload
{
    public Data Data { get; set; } = new Data();
}

public record QueryResult
{
    public string QueryText { get; set; } = string.Empty;
    public Parameters Parameters { get; set; } = new Parameters();
    public bool AllRequiredParamsPresent { get; set; }
    public List<FulfillmentMessage> FulfillmentMessages { get; set; } = new List<FulfillmentMessage>();
    public List<OutputContext> OutputContexts { get; set; } = new List<OutputContext>();
    public Intent Intent { get; set; } = new Intent();
    public double IntentDetectionConfidence { get; set; }
    public string LanguageCode { get; set; } = string.Empty;
}

public record Source
{
    public string Type { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}

public record FullfillmentMessageText
{
    public List<string> Text { get; set; } = new List<string>();
}