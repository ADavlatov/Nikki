using Nikki.Client.Interfaces;
using Nikki.Client.Pages;
using Nikki.Client.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<ILogoutService,LogoutService>();
builder.Services.AddTransient<ITokenService, TokenService>();

var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();

app.Run();