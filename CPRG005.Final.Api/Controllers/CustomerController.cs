using AutoMapper;
using CPRG005.Final.Api.ViewModels.Customer;
using CPRG005.Final.BLL.Repositories;
using CPRG005.Final.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPRG005.Final.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;
        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerDisplayViewModel>> GetAllCustomers()
        {
            var customers = await customerRepository.GetAll();
            var model = mapper.Map<List<CustomerDisplayViewModel>>(customers);

            return model;
        }

        [HttpGet("{customerId}")]
        public async Task<CustomerDisplayViewModel> GetCustomerRecordById(int customerId)
        {
            var customer = await customerRepository.GetById(customerId);
            var model = mapper.Map<CustomerDisplayViewModel>(customer);

            return model;
        }

        [HttpPut]
        public async Task<string> UpdateCustomer([FromBody] CustomerDisplayViewModel model)
        {
            var customer = mapper.Map<Customer>(model);
            var successMessage = await customerRepository.Edit(customer.Id, customer);

            return successMessage;
        }

        [HttpPost]
        public async Task<string> AddCustomer([FromBody] CustomerDisplayViewModel model)
        {
            var customer = mapper.Map<Customer>(model);
            var successMessage = await customerRepository.Create(customer);

            return successMessage;
        }
    }
}
