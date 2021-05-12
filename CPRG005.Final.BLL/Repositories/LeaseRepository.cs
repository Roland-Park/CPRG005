using CPRG005.Final.Data;
using CPRG005.Final.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CPRG005.Final.BLL.Repositories
{
    public interface ILeaseRepository : IRepositoryBase<Lease>
    {

    }
    public class LeaseRepository : RepositoryBase<Lease>, ILeaseRepository
    {
        private readonly MarinaDbContext context;
        private readonly ILogger<Lease> logger;
        public LeaseRepository(MarinaDbContext context, ILogger<Lease> logger) : base(context, logger)
        {
            this.context = context;
            this.logger = logger;
        }
    }
}
