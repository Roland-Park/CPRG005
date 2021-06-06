using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CPRG005.Final.Roland.Factories;
using CPRG005.Final.Roland.Helpers;
using CPRG005.Final.Roland.Models;
using CPRG005.Final.Roland.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CPRG005.Final.Roland.Pages
{
    public class CreateLeaseModel : PageModel
    {
        private IHttpClientFactory clientFactory;
        private ISessionHelper sessionHelper;
        private ILeaseFactory leaseFactory;
        public SelectList SlipSelectList { get; set; }
        public SelectList LeaseTypeSelectList { get; set; }
        [BindProperty]
        public CreateLeaseViewModel FormData { get; set; }
        public CreateLeaseModel(IHttpClientFactory clientFactory, ISessionHelper sessionHelper, ILeaseFactory leaseFactory)
        {
            this.clientFactory = clientFactory;
            this.sessionHelper = sessionHelper;
            this.leaseFactory = leaseFactory;
            FormData = new CreateLeaseViewModel()
            {
                Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            };
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
                    var slips = await client.GetFromJsonAsync<List<Slip>>("Slip");
                    SlipSelectList = new SelectList(slips, nameof(Slip.Id), nameof(Slip.Id));

                    var leaseTypes = await client.GetFromJsonAsync<List<LeaseType>>("LeaseType");
                    LeaseTypeSelectList = new SelectList(leaseTypes, nameof(LeaseType.Id), nameof(LeaseType.Name));

                    return Page();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
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
                var lease = leaseFactory.Build(FormData, sessionHelper.UserId);

                var client = clientFactory.CreateClient("MarinaApi");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionHelper.AccessToken);
                await client.PostAsJsonAsync("Lease", lease);
                return RedirectToPage("./Lease");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
