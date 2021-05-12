using CPRG005.Final.Data;
using CPRG005.Final.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CPRG005.Final.BLL.Repositories
{
    public interface IDockRepository : IRepositoryBase<Dock>
    {

    }
    public class DockRepository : RepositoryBase<Dock>, IDockRepository
    {
        private readonly MarinaDbContext context;
        private readonly ILogger<Dock> logger;
        public DockRepository(MarinaDbContext context, ILogger<Dock> logger) : base(context, logger)
        {
            this.context = context;
            this.logger = logger;
        }
    }
}
