using Line.Messaging;
using Microsoft.Extensions.Options;
using SpoiledRabbot.Models;

namespace SpoiledRabbot.Services;

public class LineService
{
    private readonly AppSettings _settings;

    public LineService(IOptions<AppSettings> options)
    {
        _settings = options.Value;
    }

    public async Task ReplyAsync(string replyToken, string text)
    {
        using (var line = new LineMessagingClient(_settings.Line.ChannelAccessToken))
        {
            var message = new TextMessage(text);
            var messages = new List<ISendMessage>();
            messages.Add(message);
            await line.ReplyMessageAsync(replyToken, messages);
        }
    }
}