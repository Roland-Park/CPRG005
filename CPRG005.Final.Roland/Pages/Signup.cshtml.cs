using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CPRG005.Final.Roland.Helpers;
using CPRG005.Final.Roland.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CPRG005.Final.Roland.Pages
{
    public class SignupModel : PageModel
    {
        private IHttpClientFactory clientFactory;
        private IHashingHelper hashingHelper;
        [BindProperty]
        public SignUpViewModel FormData { get; set; }
        public SignupModel(IHttpClientFactory clientFactory, IHashingHelper hashingHelper)
        {
            this.clientFactory = clientFactory;
            this.hashingHelper = hashingHelper;
            FormData = new SignUpViewModel();
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!string.Equals(FormData.Password, FormData.PasswordConfirm))
            {
                return Page();
            }

            var customer = new CustomerCreationViewModel
            {
                FirstName = FormData.FirstName,
                LastName = FormData.LastName,
                City = FormData.City,
                Phone = FormData.Phone
            };

            var authorization = new AuthorizeCreationViewModel
            {
                UserName = FormData.UserName,
                Password = hashingHelper.Hash(FormData.Password),
                Customer = customer
            };

            try
            {
                var client = clientFactory.CreateClient("MarinaApi");
                var response = await client.PostAsJsonAsync("authorization", authorization);
                return Page();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public class CustomerCreationViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }

    public class AuthorizeCreationViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public CustomerCreationViewModel Customer { get; set; }
    }
}
