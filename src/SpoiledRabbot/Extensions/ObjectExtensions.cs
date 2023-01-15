using Newtonsoft.Json;

namespace SpoiledRabbot.Extensions;

public static class ObjectExtensions
{
    public static string ToJson(this object value)
    {
        var settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        };
        return JsonConvert.SerializeObject(value, Formatting.Indented, settings);
    }
}