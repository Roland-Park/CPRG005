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
        Task<List<Slip>> GetAvailableSlipsByDockAndLocation(int locationId, int dockId);
        Task<List<Slip>> GetAvailableSlipsByDockId(int dockId);
        Task<List<Slip>> GetAvailableSlipsByLocationId(int locationId);
        Task<List<Slip>> GetAvailableSlips();
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

        public async Task<List<Slip>> GetAvailableSlips()
        {
            var unavailableSlipIds = await GetUnavailableSlipIds();

            var slipsForDock = await context.Set<Slip>().Include(x => x.Dock.Location).ToListAsync();
            return slipsForDock.Where(x => !unavailableSlipIds.Contains(x.Id)).ToList();
        }

        public async Task<List<Slip>> GetAvailableSlipsByDockId(int dockId)
        {
            var leases = await context.Set<Lease>().ToListAsync();
            var unavailableSlipIds = new List<int>();

            foreach(var lease in leases)
            {
                unavailableSlipIds.Add(lease.SlipId);
            }

            var slips = await context.Set<Slip>().Include(x => x.Dock.Location).Where(x => x.DockId == dockId).ToListAsync();
            return slips.Where(x => !unavailableSlipIds.Contains(x.Id)).ToList();
        }

        public async Task<List<Slip>> GetAvailableSlipsByLocationId(int locationId)
        {
            var leases = await context.Set<Lease>().ToListAsync();
            var unavailableSlipIds = new List<int>();

            foreach (var lease in leases)
            {
                unavailableSlipIds.Add(lease.SlipId);
            }

            var slips = await context.Set<Slip>().Include(x => x.Dock.Location).Where(x => x.Dock.LocationId == locationId).ToListAsync();
            return slips.Where(x => !unavailableSlipIds.Contains(x.Id)).ToList();
        }

        public async Task<List<Slip>> GetAvailableSlipsByDockAndLocation(int locationId, int dockId)
        {
            var unavailableSlipIds = await GetUnavailableSlipIds();

            var slips = await context.Set<Slip>().Include(x => x.Dock.Location).Where(x => x.Dock.LocationId == locationId && x.DockId == dockId).ToListAsync();
            return slips.Where(x => !unavailableSlipIds.Contains(x.Id)).ToList();
        }

        private async Task<List<int>> GetUnavailableSlipIds()
        {
            var leases = await context.Set<Lease>().ToListAsync();
            var unavailableSlipIds = new List<int>();

            foreach (var lease in leases)
            {
                unavailableSlipIds.Add(lease.SlipId);
            }

            return unavailableSlipIds;
        }
    }
}
