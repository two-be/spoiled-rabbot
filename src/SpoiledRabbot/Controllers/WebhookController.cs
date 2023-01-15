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
    public async Task<ActionResult<DialogflowWebhookResponse>> PostForDialogflow([FromBody] DialogflowWebhookRequest value)
    {
        _logger.LogInformation("__{value}__", value.ToJson());
        await _line.ReplyAsync(value.OriginalDetectIntentRequest.Payload.Data.ReplyToken, "Hello, World!");
        return Ok();
    }

    [HttpPost("Line")]
    public async Task<IActionResult> PostForLine([FromBody] LineWebhookRequest value)
    {
        _logger.LogInformation("__{value}__", value.ToJson());
        using var client = _http.CreateClient();
        var rs = await client.PostAsJsonAsync($"https://dialogflow.cloud.google.com/v1/integrations/line/webhook/{_settings.Dialogflow.AgentId}", value);
        var content = await rs.Content.ReadAsStringAsync();
        _logger.LogInformation("__{content}__", content);
        return Ok();
    }
}