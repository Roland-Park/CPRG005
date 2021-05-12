using AutoMapper;
using CPRG005.Final.Api.ViewModels.Location;
using CPRG005.Final.BLL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPRG005.Final.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository locationRepository;
        private readonly IMapper mapper;
        public LocationController(ILocationRepository locationRepository, IMapper mapper)
        {
            this.locationRepository = locationRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<LocationDisplayViewModel>> GetAllLocations()
        {
            var locations = await locationRepository.GetAll();
            var model = mapper.Map<List<LocationDisplayViewModel>>(locations);

            return model;
        }
    }
}
