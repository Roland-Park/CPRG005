using CPRG005.Final.Roland.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CPRG005.Final.Roland.Controllers
{
    public class FilterBySlipController : Controller
    {
        private IHttpClientFactory clientFactory;
        public FilterBySlipController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetSlipsForParameters(int locationId, int dockId)
        {
            var client = clientFactory.CreateClient("MarinaApi");

            if((locationId == 0 && dockId == 0) || (locationId == -1 && dockId == -1))
            {
                var allSlips = await client.GetFromJsonAsync<List<Slip>>("slip");
                return PartialView("_GetFilteredSlips", allSlips.ToList());
            }

            var slips = await client.GetFromJsonAsync<List<Slip>>($"slip/filter/?locationId={locationId}&dockId={dockId}");
            return PartialView("_GetFilteredSlips", slips.ToList());
        }
    }
}
