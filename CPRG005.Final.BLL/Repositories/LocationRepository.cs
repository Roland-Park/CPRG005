using CPRG005.Final.Data;
using CPRG005.Final.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG005.Final.BLL.Repositories
{
    public interface ILocationRepository : IRepositoryBase<Location>
    {

    }
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        private readonly MarinaDbContext context;
        private readonly ILogger<Location> logger;
        public LocationRepository(MarinaDbContext context, ILogger<Location> logger) : base(context, logger)
        {
            this.context = context;
            this.logger = logger;
        }
    }
}
