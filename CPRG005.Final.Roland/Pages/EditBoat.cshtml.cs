using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    public class EditBoatModel : PageModel
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
        public EditBoatViewModel FormData { get; set; }

        public EditBoatModel(IHttpClientFactory clientFactory, ISessionHelper sessionHelper, IBoatFactory boatFactory)
        {
            FormData = new EditBoatViewModel();
            this.clientFactory = clientFactory;
            this.sessionHelper = sessionHelper;
            this.boatFactory = boatFactory;
        }
        public IActionResult OnGet(string id, string reg, string manu, string year, string length)
        {
            if (!sessionHelper.IsLoggedIn)
            {
                return RedirectToPage("./Login");
            }
            else
            {
                FormData.BoatId = int.Parse(id);
                FormData.RegistrationNumber = reg;
                FormData.Manufacturer = manu;
                FormData.ModelYear = int.Parse(year);
                FormData.Length = int.Parse(length);
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
                var boat = boatFactory.BuildForEdit(FormData, sessionHelper.UserId);

                var client = clientFactory.CreateClient("MarinaApi");
                await client.PutAsJsonAsync("Boat", boat);
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
            for (int i = currentYear; i >= currentYear - 60; i--)
            {
                years.Add(i);
            }

            return years;
        }

        private List<int> CreateLengths()
        {
            var lengths = new List<int>();
            for (int i = minLength; i <= maxLength; i++)
            {
                lengths.Add(i);
            }

            return lengths;
        }
    }
}
