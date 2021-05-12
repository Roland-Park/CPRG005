using AutoMapper;
using CPRG005.Final.Api.ViewModels.Lease;
using CPRG005.Final.BLL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPRG005.Final.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaseController : ControllerBase
    {
        private readonly ILeaseRepository leaseRepository;
        private readonly IMapper mapper;
        public LeaseController(ILeaseRepository leaseRepository, IMapper mapper)
        {
            this.leaseRepository = leaseRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<LeaseDisplayViewModel>> GetAllDocks()
        {
            var leases = await leaseRepository.GetAll();
            var model = mapper.Map<List<LeaseDisplayViewModel>>(leases);

            return model;
        }
    }
}
