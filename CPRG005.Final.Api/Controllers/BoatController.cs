using AutoMapper;
using CPRG005.Final.Api.ViewModels.Boat;
using CPRG005.Final.BLL.Repositories;
using CPRG005.Final.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPRG005.Final.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoatController : ControllerBase
    {
        private readonly IBoatRepository boatRepository;
        private readonly IMapper mapper;
        public BoatController(IBoatRepository boatRepository, IMapper mapper)
        {
            this.boatRepository = boatRepository;
            this.mapper = mapper;
        }

        [HttpGet("{customerId}")]
        public async Task<List<BoatDisplayViewModel>> GetBoatsByCustomerId(int customerId)
        {
            var boats = await boatRepository.GetBoatsForCustomer(customerId);
            var model = mapper.Map<List<BoatDisplayViewModel>>(boats);
            return model;
        }

        [HttpPut("{model}")]
        public async Task<string> UpdateCustomer([FromBody] BoatDisplayViewModel model)
        {
            var customer = mapper.Map<Boat>(model);
            var successMessage = await boatRepository.Edit(customer.Id, customer);

            return successMessage;
        }

        [HttpPost("{model}")]
        public async Task<string> AddCustomer([FromBody] BoatDisplayViewModel model)
        {
            var customer = mapper.Map<Boat>(model);
            var successMessage = await boatRepository.Create(customer);

            return successMessage;
        }
    }
}
