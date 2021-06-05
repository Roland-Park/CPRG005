using CPRG005.Final.Roland.Factories;
using CPRG005.Final.Roland.Helpers;
using CPRG005.Final.Roland.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CPRG005.Final.Roland.Pages
{
    public class AccountModel : PageModel
    {
        private IHttpClientFactory clientFactory;
        private ISessionHelper sessionHelper;
        private ICustomerFactory customerFactory;
        [BindProperty]
        public EditCustomerViewModel FormData { get; set; }
        public AccountModel(ISessionHelper sessionHelper, IHttpClientFactory clientFactory, ICustomerFactory customerFactory)
        {
            this.sessionHelper = sessionHelper;
            this.clientFactory = clientFactory;
            this.customerFactory = customerFactory;
            FormData = new EditCustomerViewModel();
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
                FormData.Id = sessionHelper.UserId;
                FormData.UserName = sessionHelper.UserName;
                FormData.FirstName = customer.FirstName;
                FormData.LastName = customer.LastName;
                FormData.Phone = customer.Phone;
                FormData.City = customer.City;

                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!sessionHelper.IsLoggedIn)
            {
                return RedirectToPage("./Login");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var customer = customerFactory.BuildForEdit(FormData, sessionHelper.UserId);

                var client = clientFactory.CreateClient("MarinaApi");
                await client.PutAsJsonAsync("Customer", customer);
                return RedirectToPage("./Account");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
