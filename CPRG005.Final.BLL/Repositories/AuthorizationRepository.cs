using CPRG005.Final.Data;
using CPRG005.Final.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG005.Final.BLL.Repositories
{
    public interface IAuthorizationRepository : IRepositoryBase<Authorize>
    {
        Task<Authorize> GetForCredentials(string username, string password);
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

        public async Task<Authorize> GetForCredentials(string username, string password)
        {
            try
            {
                var authorizations = await context.Set<Authorize>().ToListAsync();
                return authorizations.FirstOrDefault(x => x.UserName == username && x.Password == password);
            }
            catch (Exception ex)
            {
                logger.LogDebug($"Error in GetForCredentials. T: {typeof(Authorize)} Error: {ex.Message}");
                return null;
            }
        }
    }
}
