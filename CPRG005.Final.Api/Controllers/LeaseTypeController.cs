using AutoMapper;
using CPRG005.Final.Api.ViewModels.LeaseType;
using CPRG005.Final.BLL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPRG005.Final.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaseTypeController : ControllerBase
    {
        private readonly ILeaseTypeRepository leaseTypeRepository;
        private readonly IMapper mapper;
        public LeaseTypeController(ILeaseTypeRepository leaseTypeRepository, IMapper mapper)
        {
            this.leaseTypeRepository = leaseTypeRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<LeaseTypeDisplayViewModel>> GetAllLeases()
        {
            var leaseTypes = await leaseTypeRepository.GetAll();
            var model = mapper.Map<List<LeaseTypeDisplayViewModel>>(leaseTypes);

            return model;
        }
    }
}
