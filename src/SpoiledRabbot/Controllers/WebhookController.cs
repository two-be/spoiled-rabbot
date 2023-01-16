using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SpoiledRabbot.Extensions;
using SpoiledRabbot.Models;
using SpoiledRabbot.Services;

namespace SpoiledRabbot.Controllers;

[ApiController]
[Route("[controller]")]
public class WebhookController : ControllerBase
{
    private readonly IHttpClientFactory _http;
    private readonly LineService _line;
    private readonly ILogger<WebhookController> _logger;
    private readonly AppSettings _settings;

    public WebhookController(IHttpClientFactory http, LineService line, ILogger<WebhookController> logger, IOptions<AppSettings> options)
    {
        _http = http;
        _line = line;
        _logger = logger;
        _settings = options.Value;
    }

    [HttpPost("Dialogflow")]
    public async Task<IActionResult> PostForDialogflow([FromBody] DialogflowWebhookRequest value)
    {
        _logger.LogInformation("__{value}__", value.ToJson());

        var replyToken = value.OriginalDetectIntentRequest.Payload.Data.ReplyToken;

        if (value.QueryResult.Intent.DisplayName == "calc")
        {
            var expression = value.QueryResult.Parameters.Calc;
            var answer = new DataTable().Compute(expression, null).ToString();
            await _line.ReplyAsync(replyToken, $"{answer} ไง ไอโง่นี่");
        }
        else
        {
            var images = new List<string> {
                "https://spoiled-rabbot.twobe.net/images/12131016.png",
                "https://spoiled-rabbot.twobe.net/images/12131017.png",
            };
            var random = new Random();
            var i = random.Next(2);

            await _line.ReplyImageAsync(replyToken, images[i]);
        }
        return Ok();
    }

    [HttpPost("Dialogflow/Explore")]
    public IActionResult PostForDialogflowForExplore([FromBody] object value)
    {
        _logger.LogInformation("__{value}__", value);
        return Ok();
    }

    [HttpPost("Line")]
    public async Task<IActionResult> PostForLine([FromBody] LineWebhookRequest value)
    {
        _logger.LogInformation("__{value}__", value.ToJson());
        if (value.Events[0].Message.Type == "sticker")
        {
            value.Events[0].Message.Type = "text";
            value.Events[0].Message.Text = "(sticker)";
        }
        using var client = _http.CreateClient();
        var rs = await client.PostAsJsonAsync($"https://dialogflow.cloud.google.com/v1/integrations/line/webhook/{_settings.Dialogflow.AgentId}", value);
        var content = await rs.Content.ReadAsStringAsync();
        _logger.LogInformation("__{content}__", content);
        return Ok();
    }

    [HttpPost("Line/Explore")]
    public async Task<IActionResult> PostForLineForExplore([FromBody] object value)
    {
        _logger.LogInformation("__{value}__", value);
        using var client = _http.CreateClient();
        var rs = await client.PostAsJsonAsync($"https://dialogflow.cloud.google.com/v1/integrations/line/webhook/{_settings.Dialogflow.AgentId}", value);
        var content = await rs.Content.ReadAsStringAsync();
        _logger.LogInformation("__{content}__", content);
        return Ok();
    }
}