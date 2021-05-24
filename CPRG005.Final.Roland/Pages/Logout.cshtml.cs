using CPRG005.Final.Roland.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CPRG005.Final.Roland.Pages
{
    public class LogoutModel : PageModel
    {
        private ISessionHelper sessionHelper;
        public LogoutModel(ISessionHelper sessionHelper)
        {
            this.sessionHelper = sessionHelper;
        }

        public IActionResult OnGet()
        {
            sessionHelper.SignOut();
            return RedirectToPage("./Index");
        }
    }
}
