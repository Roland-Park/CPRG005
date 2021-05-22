using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CPRG005.Final.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CPRG005.Final.Roland.Pages
{
    public class LoginModel : PageModel
    {
        private IHttpClientFactory clientFactory;
        private IHashingService hashingService;
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginModel(IHashingService hashingService, IHttpClientFactory clientFactory)
        {
            this.hashingService = hashingService;
            this.clientFactory = clientFactory;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            UserName = Request.Form[nameof(UserName)];
            Password = Request.Form[nameof(Password)];            

            try
            {
                var client = clientFactory.CreateClient("MarinaApi");
                var response = await client.PostAsJsonAsync("authorization/login", new { UserName, Password });

                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync(); //todo: deserialize
                }
                return Page();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
