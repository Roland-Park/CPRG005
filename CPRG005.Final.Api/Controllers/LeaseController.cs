using AutoMapper;
using CPRG005.Final.Api.ViewModels.Lease;
using CPRG005.Final.BLL.Repositories;
using CPRG005.Final.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPRG005.Final.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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
        public async Task<IEnumerable<LeaseDisplayViewModel>> GetAllLeases()
        {
            var leases = await leaseRepository.GetAll();
            var model = mapper.Map<List<LeaseDisplayViewModel>>(leases);

            return model;
        }

        [HttpGet("{customerId}")]
        public async Task<IEnumerable<LeaseDisplayViewModel>> GetLeasesForCustomer(int customerId)
        {
            var leases = await leaseRepository.GetAllForCustomer(customerId);
            var model = mapper.Map<List<LeaseDisplayViewModel>>(leases);

            return model;
        }

        [HttpPost]
        public async Task<string> Create([FromBody] LeaseCreateViewModel model)
        {
            try
            {
                var lease = mapper.Map<Lease>(model);
                return await leaseRepository.Create(lease);
            }
            catch(Exception ex)
            {
                throw new Exception($"Error POSTing lease: {ex.Message}");
            }
        }
    }
}
