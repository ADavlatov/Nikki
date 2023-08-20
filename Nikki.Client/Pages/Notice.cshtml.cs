using Microsoft.AspNetCore.Mvc.RazorPages;
using Nikki.Client.Services;

namespace Nikki.Client.Pages;

public class Notice : PageModel
{
    public void OnGet(LogoutService logout, TokenService token)
    {
        ViewData["IsAuth"] = new AuthValidationService(logout, token).ValidateUserAuth(Request, Response);
    }
}