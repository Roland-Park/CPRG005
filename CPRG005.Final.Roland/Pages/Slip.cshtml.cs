using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CPRG005.Final.Roland.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CPRG005.Final.Roland.Pages
{
    public class SlipModel : PageModel
    {
        private IHttpClientFactory clientFactory;
        public List<Slip> Slips { get; set; }
        public SlipModel(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
            Slips = new List<Slip>();
        }
        public async Task<IActionResult> OnGet()
        {
            var client = clientFactory.CreateClient("MarinaApi");
            try
            {
                var slips = await client.GetFromJsonAsync<List<Slip>>("slip");
                Slips.AddRange(slips);
                return Page();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
