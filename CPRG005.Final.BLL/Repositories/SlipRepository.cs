using CPRG005.Final.Data;
using CPRG005.Final.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG005.Final.BLL.Repositories
{
    public interface ISlipRepository : IRepositoryBase<Slip>
    {
        Task<List<Slip>> GetAvailableSlipsByDockId(int dockId);
    }
    public class SlipRepository : RepositoryBase<Slip>, ISlipRepository
    {
        private readonly MarinaDbContext context;
        private readonly ILogger<Slip> logger;
        public SlipRepository(MarinaDbContext context, ILogger<Slip> logger) : base(context, logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async  Task<List<Slip>> GetAvailableSlipsByDockId(int dockId)
        {
            var leases = await context.Set<Lease>().ToListAsync();
            var unavailableSlipIds = new List<int>();

            foreach(var lease in leases)
            {
                unavailableSlipIds.Add(lease.Id);
            }

            var slipsForDock = await context.Set<Slip>().Where(x => x.DockId == dockId).ToListAsync();
            return slipsForDock.Where(x => !unavailableSlipIds.Contains(x.Id)).ToList();            
        }
    }
}
