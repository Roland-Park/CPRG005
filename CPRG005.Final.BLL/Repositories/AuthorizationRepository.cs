using CPRG005.Final.Data;
using CPRG005.Final.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CPRG005.Final.BLL.Repositories
{
    public interface IAuthorizationRepository : IRepositoryBase<Authorize>
    {
    }

    public class AuthorizationRepository : RepositoryBase<Authorize>, IAuthorizationRepository
    {
        private readonly MarinaDbContext context;
        private readonly ILogger<Authorize> logger;
        public AuthorizationRepository(MarinaDbContext context, ILogger<Authorize> logger) : base(context, logger)
        {
            this.context = context;
            this.logger = logger;
        }
    }
}
