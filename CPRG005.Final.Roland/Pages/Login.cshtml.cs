using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CPRG005.Final.Roland.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CPRG005.Final.Roland.Pages
{
    public class LoginModel : PageModel
    {
        private IHttpClientFactory clientFactory;
        private ISessionHelper sessionHelper;
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginModel(IHttpClientFactory clientFactory, ISessionHelper sessionHelper)
        {
            this.clientFactory = clientFactory;
            this.sessionHelper = sessionHelper;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                UserName = Request.Form[nameof(UserName)];
                Password = Request.Form[nameof(Password)];

                try
                {
                    var client = clientFactory.CreateClient("MarinaApi");
                    var response = await client.PostAsJsonAsync("authorization/login", new { UserName, Password });

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var authorization = JsonConvert.DeserializeObject<AuthDto>(json);
                        sessionHelper.SignIn(authorization.Token, authorization.UserId, UserName);
                        return RedirectToPage("./Lease");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt."); //TODO: make this display
                        return Page();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return Page();
        }
    }

    public class AuthDto
    {
        public string Token { get; set; }
        public int UserId { get; set; }
    }
}
