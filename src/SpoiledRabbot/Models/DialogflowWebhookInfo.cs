using Newtonsoft.Json;

namespace SpoiledRabbot.Models;

public class DialogflowWebhookRequest
{
    public string ResponseId { get; set; } = string.Empty;
    public QueryResult QueryResult { get; set; } = new QueryResult();
    public OriginalDetectIntentRequest OriginalDetectIntentRequest { get; set; } = new OriginalDetectIntentRequest();
    public string Session { get; set; } = string.Empty;
}

public class DialogflowWebhookResponse
{
    public List<FulfillmentMessage> FulfillmentMessages { get; set; } = new List<FulfillmentMessage>();

    public DialogflowWebhookResponse() { }

    public DialogflowWebhookResponse(string text)
    {
        FulfillmentMessages = new List<FulfillmentMessage>
            {
                new FulfillmentMessage
                {
                    Text = new FulfillmentText
                    {
                        Text = new List<string> { text },
                    },
                },
            };
    }
}

public class Button
{
    public string Text { get; set; } = string.Empty;
    public string Postback { get; set; } = string.Empty;
}

public class Data
{
    public string ReplyToken { get; set; } = string.Empty;
    public string Timestamp { get; set; } = string.Empty;
    public Source Source { get; set; } = new Source();
    public string Type { get; set; } = string.Empty;
    public Message Message { get; set; } = new Message();
}

public class FulfillmentCard
{
    public string Title { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;
    public string ImageUri { get; set; } = string.Empty;
    public List<Button> Buttons { get; set; } = new List<Button>();
}

public class FulfillmentMessage
{
    public FulfillmentCard Card { get; set; } = new FulfillmentCard();
    public FulfillmentText Text { get; set; } = new FulfillmentText();
}

public class FulfillmentText
{
    public List<string> Text { get; set; } = new List<string>();
}

public class Intent
{
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
}

public class Message
{
    public string Type { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string Id { get; set; } = string.Empty;
}

public class OriginalDetectIntentRequest
{
    public string Source { get; set; } = string.Empty;
    public Payload Payload { get; set; } = new Payload();
}

public class OutputContext
{
    public string Name { get; set; } = string.Empty;
    public int LifespanCount { get; set; }
    public Parameters Parameters { get; set; } = new Parameters();
}

public class Parameters
{
    public string CourseTermCode { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;

    [JsonProperty("no-input")]
    public double NoInput { get; set; }
    [JsonProperty("no-match")]
    public double NoMatch { get; set; }
}

public class Payload
{
    public Data Data { get; set; } = new Data();
}

public class QueryResult
{
    public string QueryText { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public Parameters Parameters { get; set; } = new Parameters();
    public bool AllRequiredParamsPresent { get; set; }
    public string FulfillmentText { get; set; } = string.Empty;
    public List<FulfillmentMessage> FulfillmentMessages { get; set; } = new List<FulfillmentMessage>();
    public List<OutputContext> OutputContexts { get; set; } = new List<OutputContext>();
    public Intent Intent { get; set; } = new Intent();
    public double IntentDetectionConfidence { get; set; }
    public string LanguageCode { get; set; } = string.Empty;
}

public class Source
{
    public string UserId { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}