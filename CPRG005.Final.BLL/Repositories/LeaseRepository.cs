using CPRG005.Final.Data;
using CPRG005.Final.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG005.Final.BLL.Repositories
{
    public interface ILeaseRepository : IRepositoryBase<Lease>
    {
        Task<List<Lease>> GetAllForCustomer(int customerId);
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

        public override async Task<List<Lease>> GetAll()
        {
            try
            {
                return await context.Set<Lease>().Include("LeaseType").ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogDebug($"Error in GetAllLeases. Error: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Lease>> GetAllForCustomer(int customerId)
        {
            try
            {
                return await context.Set<Lease>().Include("LeaseType").Where(x => x.CustomerId == customerId).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogDebug($"Error in GetAllLeasesForCustomer. Error: {ex.Message}");
                return null;
            }
        }
    }
}
