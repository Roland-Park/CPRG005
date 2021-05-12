using CPRG005.Final.Data;
using CPRG005.Final.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CPRG005.Final.BLL.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {

    }
    public class CustomerRepository : RepositoryBase<Customer>
    {
        private readonly MarinaDbContext context;
        private readonly ILogger<Customer> logger;
        public CustomerRepository(MarinaDbContext context, ILogger<Customer> logger) : base(context, logger)
        {
            this.context = context;
            this.logger = logger;
        }
    }
}
