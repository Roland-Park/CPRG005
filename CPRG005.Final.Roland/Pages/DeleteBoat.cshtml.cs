using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CPRG005.Final.Roland.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CPRG005.Final.Roland.Pages
{
    public class DeleteBoatModel : PageModel
    {
        private IHttpClientFactory clientFactory;
        private ISessionHelper sessionHelper;
        public int BoatId { get; set; }
        public DeleteBoatModel(IHttpClientFactory clientFactory, ISessionHelper sessionHelper)
        {
            this.clientFactory = clientFactory;
            this.sessionHelper = sessionHelper;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            BoatId = int.Parse(id);
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
                    var success = await client.DeleteAsync($"Boat/{BoatId}");

                    return RedirectToPage("./Boat");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
