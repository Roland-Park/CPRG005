using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CPRG005.Final.Roland.Helpers;
using CPRG005.Final.Roland.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CPRG005.Final.Roland.Pages
{
    public class BoatModel : PageModel
    {
        private IHttpClientFactory clientFactory;
        private ISessionHelper sessionHelper;
        public List<Boat> Boats { get; set; }
        public BoatModel(IHttpClientFactory clientFactory, ISessionHelper sessionHelper)
        {
            this.clientFactory = clientFactory;
            this.sessionHelper = sessionHelper;
            Boats = new List<Boat>();
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
                try
                {
                    var boats = await client.GetFromJsonAsync<List<Boat>>($"Boat/{sessionHelper.UserId}");
                    Boats.AddRange(boats);
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
