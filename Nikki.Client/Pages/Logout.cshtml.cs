using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nikki.Client.Services;

namespace Nikki.Client.Pages;

public class Logout : PageModel
{
    public RedirectToPageResult OnGet(LogoutService logoutService)
    {
        logoutService.Logout(Response);
        
        return RedirectToPage("Index");
    }
}