using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CPRG005.Final.Roland.Factories;
using CPRG005.Final.Roland.Helpers;
using CPRG005.Final.Roland.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CPRG005.Final.Roland.Pages
{
    public class CreateBoatModel : PageModel
    {
        private IHttpClientFactory clientFactory;
        private ISessionHelper sessionHelper;
        private IBoatFactory boatFactory;
        private readonly int currentYear = DateTime.Now.Year;
        private const int minLength = 12;
        private const int maxLength = 28;
        public SelectList Years;
        public SelectList Lengths;
        [BindProperty]
        public CreateBoatViewModel FormData { get; set; }
        public CreateBoatModel(IHttpClientFactory clientFactory, ISessionHelper sessionHelper, IBoatFactory boatFactory)
        {
            this.clientFactory = clientFactory;
            this.sessionHelper = sessionHelper;
            this.boatFactory = boatFactory;
        }
        public IActionResult OnGet()
        {
            if (!sessionHelper.IsLoggedIn)
            {
                return RedirectToPage("./Login");
            }
            else
            {
                Years = new SelectList(CreateModelYears(), currentYear);
                Lengths = new SelectList(CreateLengths(), minLength);
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
                var boat = boatFactory.Build(FormData, sessionHelper.UserId);

                var client = clientFactory.CreateClient("MarinaApi");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionHelper.AccessToken);
                await client.PostAsJsonAsync("Boat", boat);
                return RedirectToPage("./Boat");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<int> CreateModelYears()
        {
            var years = new List<int>();            
            for(int i = currentYear; i >= currentYear - 60; i--)
            {
                years.Add(i);
            }

            return years;
        }

        private List<int> CreateLengths()
        {
            var lengths = new List<int>();
            for(int i = minLength; i <= maxLength; i++)
            {
                lengths.Add(i);
            }

            return lengths;
        }
    }
}
