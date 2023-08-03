using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Nikki.Client.Pages;

public class LogIn : PageModel
{
    public string[]? UsernameErrors { get; set; }
    public string[]? PasswordErrors { get; set; }
    public IActionResult? OnPost(string username, string password)
    {
        var client = new Auth.AuthClient(GrpcChannel.ForAddress("https://localhost:7269"));
        var response = client.LogInUser(new LogInRequest { Username = username, Password = password });

        if (response.IsSucceed)
        {
            Response.Cookies.Append("AccessToken", response.AccessToken);
            Response.Cookies.Append("RefreshToken", response.RefreshToken);

            return RedirectToPage("/Notice");
        }
        
        UsernameErrors = response.UsernameErrors.Split(", ");
        PasswordErrors = response.PasswordErrors.Split(", ");

        return null;
    }
}