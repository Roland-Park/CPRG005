using CPRG005.Final.Data;
using CPRG005.Final.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CPRG005.Final.BLL.Repositories
{
    public interface ILeaseTypeRepository : IRepositoryBase<LeaseType>
    {

    }
    public class LeaseTypeRepository : RepositoryBase<LeaseType>, ILeaseTypeRepository
    {
        private readonly MarinaDbContext context;
        private readonly ILogger<LeaseType> logger;
        public LeaseTypeRepository(MarinaDbContext context, ILogger<LeaseType> logger) : base(context, logger)
        {
            this.context = context;
            this.logger = logger;
        }
    }
}
