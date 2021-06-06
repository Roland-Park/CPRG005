using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CPRG005.Final.Roland.Helpers;
using CPRG005.Final.Roland.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CPRG005.Final.Roland.Pages
{
    public class LeaseModel : PageModel
    {
        private IHttpClientFactory clientFactory;
        private ISessionHelper sessionHelper;
        public List<Lease> Leases { get; set; }
        public LeaseModel(IHttpClientFactory clientFactory, ISessionHelper sessionHelper)
        {
            this.clientFactory = clientFactory;
            this.sessionHelper = sessionHelper;
            Leases = new List<Lease>();
        }

        public async Task<IActionResult> OnGet()
        {
            if (!sessionHelper.IsLoggedIn)
            {
                return RedirectToPage("./Login");
            }
            else
            {
                var client = clientFactory.CreateClient("MarinaApi");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionHelper.AccessToken);
                try
                {
                    var leases = await client.GetFromJsonAsync<List<Lease>>($"lease/{sessionHelper.UserId}");
                    Leases.AddRange(leases);
                    return Page();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
