using CPRG005.Final.Data;
using CPRG005.Final.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG005.Final.BLL.Repositories
{
    public interface IBoatRepository : IRepositoryBase<Boat>
    {
        Task<List<Boat>> GetBoatsForCustomer(int customerId);
    }
    public class BoatRepository : RepositoryBase<Boat>, IBoatRepository
    {
        private readonly MarinaDbContext context;
        private readonly ILogger<Boat> logger;
        public BoatRepository(MarinaDbContext context, ILogger<Boat> logger) : base(context, logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<List<Boat>> GetBoatsForCustomer(int customerId)
        {
            var boats = await context.Set<Boat>().ToListAsync();
            return boats.Where(x => x.CustomerId == customerId).ToList();
        }
    }
}
