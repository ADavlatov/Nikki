using Nikki.Core.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CoreContext>();

var app = builder.Build();

app.Run();