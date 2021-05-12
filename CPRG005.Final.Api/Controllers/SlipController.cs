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

        [HttpGet("{dockId}")]
        public async Task<List<SlipDisplayViewModel>> GetAvailableSlipsByDockId(int dockId)
        {
            var slips = await slipRepository.GetAvailableSlipsByDockId(dockId);
            var model = mapper.Map<List<SlipDisplayViewModel>>(slips);
            return model;
        }
    }
}
