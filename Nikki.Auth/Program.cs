using Nikki.Auth.Models;
using Nikki.Auth.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddDbContext<UserContext>();

var app = builder.Build();

app.MapGrpcService<AuthService>();

app.Run();