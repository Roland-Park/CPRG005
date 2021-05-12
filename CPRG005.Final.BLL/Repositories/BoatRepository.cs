using CPRG005.Final.Data;
using CPRG005.Final.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CPRG005.Final.BLL.Repositories
{
    public interface IBoatRepository : IRepositoryBase<Boat>
    {

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
    }
}
