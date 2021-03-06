using AutoMapper;
using CPRG005.Final.Api.ViewModels.Boat;
using CPRG005.Final.BLL.Repositories;
using CPRG005.Final.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPRG005.Final.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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

        [HttpPut]
        public async Task<string> UpdateBoat([FromBody] BoatDisplayViewModel model)
        {
            var customer = mapper.Map<Boat>(model);
            var successMessage = await boatRepository.Edit(customer.Id, customer);

            return successMessage;
        }

        [HttpPost]
        public async Task<string> AddBoat([FromBody] BoatDisplayViewModel model)
        {
            var customer = mapper.Map<Boat>(model);
            var successMessage = await boatRepository.Create(customer);

            return successMessage;
        }

        [HttpDelete("{boatId}")]
        public async Task<string> DeleteBoat(int boatId)
        {
            var successMessage = await boatRepository.Delete(boatId);

            return successMessage.ToString();
        }
    }
}
