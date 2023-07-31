using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Nikki.Client.Pages;

public class LogIn : PageModel
{
    public string[]? UsernameErrors { get; set; }
    public string[]? PasswordErrors { get; set; }
    public void OnGet()
    {
        
    }
}