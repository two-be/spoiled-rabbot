using System.Security.Cryptography;
using System.Text;

namespace SpoiledRabbot.Extensions;

public static class StringExtensions
{
    public static string ToSHA512(this string value)
    {
        using var sha = SHA512.Create();
        var utf8Bytes = Encoding.UTF8.GetBytes(value);
        var hash = sha.ComputeHash(utf8Bytes);
        return BitConverter.ToString(hash).Replace("-", string.Empty);
    }
}