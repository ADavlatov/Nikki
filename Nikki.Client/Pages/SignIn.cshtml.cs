using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Nikki.Client.Pages;

[IgnoreAntiforgeryToken]
public class SignIn : PageModel
{
    public string[]? UsernameErrors { get; set; }
    public string[]? EmailErrors { get; set; }
    public string[]? PasswordErrors { get; set; }
    public void OnGet()
    {
        
    }

    public void OnPost(string username, string email, string password)
    {
        var client = new Auth.AuthClient(GrpcChannel.ForAddress("https://localhost:7269"));
        var response = client.SignInUser(new SignInRequest { Username = username, Email = email, Password = password });

        if (!response.IsSucceed)
        {
            UsernameErrors = response.UsernameErrors.Split(", ");
            EmailErrors = response.EmailErrors.Split(", ");
            PasswordErrors = response.PasswordErrors.Split(", ");
        }
        
        Response.Cookies.Append("AccessToken", response.AccessToken);
        Response.Cookies.Append("RefreshToken", response.RefreshToken);

        RedirectToPage("Index");
    }
}