using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nikki.Auth;
using Nikki.Client.Services;

namespace Nikki.Client.Pages;

public class LogIn : PageModel
{
    public string[]? UsernameErrors { get; set; }
    public string[]? PasswordErrors { get; set; }
    public IActionResult? OnPost(string username, string password)
    {
        var client = new Auth.Auth.AuthClient(GrpcChannel.ForAddress("https://localhost:7269"));
        var response = client.LogInUser(new LogInRequest { Username = username, Password = password });

        if (response.IsSucceed)
        {
            new TokenService().SetTokens(Response, response.AccessToken, response.RefreshToken, response.UserId);

            return RedirectToPage("/Notice");
        }
        
        UsernameErrors = response.UsernameErrors.Split(", ");
        PasswordErrors = response.PasswordErrors.Split(", ");

        return null;
    }
}