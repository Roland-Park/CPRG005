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
        public List<Location> Locations { get; set; }
        public List<Dock> Docks { get; set; }
        public SlipModel(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
            Slips = new List<Slip>();
            Locations = new List<Location>() { new Location { Id = -1, Name = "All" } };
            Docks = new List<Dock>() { new Dock { Id = -1, Name = "All" } };
        }
        public async Task<IActionResult> OnGet()
        {
            var client = clientFactory.CreateClient("MarinaApi");
            try
            {
                var slips = await client.GetFromJsonAsync<List<Slip>>("slip");
                Slips.AddRange(slips);

                var dockNames = new List<string>();
                var locName = new List<string>();

                foreach (var slip in slips)
                {
                    var dock = slip.Dock;
                    var loc = slip.Dock.Location;

                    if (!dockNames.Contains(dock.Name))
                    {
                        Docks.Add(slip.Dock);
                        dockNames.Add(dock.Name);
                    }

                    if (!locName.Contains(loc.Name))
                    {
                        Locations.Add(slip.Dock.Location);
                        locName.Add(loc.Name);
                    }
                }
                return Page();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string IdFormat(int id)
        {
            var prefix = string.Empty;
            if (id < 10)
            {
                prefix = "0000";
            }
            else if(id < 100)
            {
                prefix = "000";
            }
            else if(id < 1000)
            {
                prefix = "00";
            }
            else if(id < 10000)
            {
                prefix = "0";
            }

            return $"#{prefix}{id}";
        }
    }
}
