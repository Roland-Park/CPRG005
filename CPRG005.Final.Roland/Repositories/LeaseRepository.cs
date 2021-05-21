using CPRG005.Final.Roland.Helpers;
using CPRG005.Final.Roland.Models;

namespace CPRG005.Final.Roland.Repositories
{
    public class LeaseRepository
    {
        private IHttpHelper<Lease> httpHelper;

        public LeaseRepository(IHttpHelper<Lease> httpHelper, IApplicationSettingsHelper applicationSettingsHelper)
        {
            this.httpHelper = httpHelper;
            httpHelper.BaseUrl = $"{applicationSettingsHelper.ApiBaseUrl}/Lease";
        }
    }
}
