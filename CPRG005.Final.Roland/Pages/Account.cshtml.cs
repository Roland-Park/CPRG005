using CPRG005.Final.Roland.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CPRG005.Final.Roland.Pages
{
    public class AccountModel : PageModel
    {
        private IHttpClientFactory clientFactory;
        private ISessionHelper sessionHelper;
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public AccountModel(ISessionHelper sessionHelper, IHttpClientFactory clientFactory)
        {
            this.sessionHelper = sessionHelper;
            this.clientFactory = clientFactory;
        }
        public async Task<IActionResult> OnGet()
        {
            if (!sessionHelper.IsLoggedIn)
            {
                return RedirectToPage("./Login");
            }
            else
            {
                //TODO: add auth token to header
                var client = clientFactory.CreateClient("MarinaApi");
                var customer = await client.GetFromJsonAsync<CustomerCreationViewModel>($"customer/{sessionHelper.UserId}");
                UserName = sessionHelper.UserName;
                FirstName = customer.FirstName;
                LastName = customer.LastName;
                Phone = customer.Phone;
                City = customer.City;

                return Page();
            }
        }
    }
}
