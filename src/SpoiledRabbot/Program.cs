#nullable disable

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Serilog;
using Serilog.Events;
using SpoiledRabbot.Data;
using SpoiledRabbot.Models;
using SpoiledRabbot.Services;
using SpoiledRabbot.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.MinimumLevel.Debug();
    configuration.MinimumLevel.Override("Microsoft", LogEventLevel.Debug).Enrich.FromLogContext();
    configuration.WriteTo.Console();
    configuration.WriteTo.File($@"./logs/{DateTime.Now.ToString("yyyy-MM-dd")}.txt", fileSizeLimitBytes: 1_000_000_000, rollOnFileSizeLimit: true, shared: true, flushToDiskInterval: TimeSpan.FromSeconds(1));
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContextFactory<AppDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("AppConnection")));
builder.Services.AddHttpClient();
builder.Services.AddMudServices();
builder.Services.AddRazorPages();
builder.Services.AddScoped<LineService>();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.Configure<AppSettings>(builder.Configuration);

var app = builder.Build();

await using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope();
var options = scope.ServiceProvider.GetRequiredService<DbContextOptions<AppDbContext>>();
var user = builder.Configuration.GetSection("InitialUser").Get<UserInfo>();
await AppUtility.EnsureDbCreatedAndSeedAsync(options, user);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapControllers();
app.MapFallbackToPage("/_Host");

app.Run();
