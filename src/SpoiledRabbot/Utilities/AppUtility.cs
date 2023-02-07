using Microsoft.EntityFrameworkCore;
using SpoiledRabbot.Data;
using SpoiledRabbot.Models;

namespace SpoiledRabbot.Utilities;

public class AppUtility
{
    public static async Task EnsureDbCreatedAndSeedAsync(DbContextOptions<AppDbContext> options, UserInfo initialUser)
    {
        var factory = new LoggerFactory();
        var builder = new DbContextOptionsBuilder<AppDbContext>(options).UseLoggerFactory(factory);

        using var context = new AppDbContext(builder.Options);
        if (await context.Database.EnsureCreatedAsync())
        {
            if (!await context.Users.AnyAsync())
            {
                await context.Users.AddAsync(initialUser);
                await context.SaveChangesAsync();
            }
        }
    }
}