#nullable disable

using Microsoft.EntityFrameworkCore;
using Serilog;
using SpoiledRabbot.Models;

namespace SpoiledRabbot.Data;

public class AppDbContext : DbContext
{
    public DbSet<UserInfo> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Log.Debug("{ContextId} context created.", ContextId);
    }

    public override void Dispose()
    {
        Log.Debug("{ContextId} context disposed.", ContextId);
        base.Dispose();
    }

    public override ValueTask DisposeAsync()
    {
        Log.Debug("{ContextId} context disposed async.", ContextId);
        return base.DisposeAsync();
    }
}