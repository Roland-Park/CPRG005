using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CPRG005.Final.Roland.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CPRG005.Final.Roland.Pages
{
    public class LeaseModel : PageModel
    {
        private IHttpClientFactory clientFactory;
        public LeaseModel(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = clientFactory.CreateClient("MarinaApi");
            try
            {
                var x = await client.GetFromJsonAsync<List<LeaseType>>("leaseType");
                return Page();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
