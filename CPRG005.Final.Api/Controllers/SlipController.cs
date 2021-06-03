using AutoMapper;
using CPRG005.Final.Api.ViewModels.Slip;
using CPRG005.Final.BLL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPRG005.Final.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SlipController : ControllerBase
    {
        private readonly ISlipRepository slipRepository;
        private readonly IMapper mapper;
        public SlipController(ISlipRepository slipRepository, IMapper mapper)
        {
            this.slipRepository = slipRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<SlipDisplayViewModel>> GetAllAvailableSlips()
        {
            var slips = await slipRepository.GetAvailableSlips();
            var model = mapper.Map<List<SlipDisplayViewModel>>(slips);
            return model;
        }

        //[HttpGet("Filter/{locationId}/{dockId}")]
        [HttpGet("Filter")]
        public async Task<List<SlipDisplayViewModel>> GetAvailableSlipsByLocationAndDock([FromQuery]int locationId, [FromQuery] int dockId)
        {
            if(locationId < 0 && dockId < 0)
            {
                return null;
            }

            List<SlipDisplayViewModel> model;
            if(locationId > 0 && dockId > 0)
            {
                var slips = await slipRepository.GetAvailableSlipsByDockAndLocation(locationId, dockId);
                model = mapper.Map<List<SlipDisplayViewModel>>(slips);
                return model;
            }
            if(locationId < 0)
            {
                var slips = await slipRepository.GetAvailableSlipsByDockId(dockId);
                model = mapper.Map<List<SlipDisplayViewModel>>(slips);
                return model;
            }
            if(dockId < 0)
            {
                var slips = await slipRepository.GetAvailableSlipsByLocationId(locationId);
                model = mapper.Map<List<SlipDisplayViewModel>>(slips);
                return model;
            }

            return null;
        }
    }
}
