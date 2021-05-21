using CPRG005.Final.Roland.Helpers;
using CPRG005.Final.Roland.Models;

namespace CPRG005.Final.Roland.Repositories
{
    public class LeaseTypeRepository
    {
        private IHttpHelper<LeaseType> httpHelper;

        public LeaseTypeRepository(IHttpHelper<LeaseType> httpHelper, IApplicationSettingsHelper applicationSettingsHelper)
        {
            this.httpHelper = httpHelper;
            httpHelper.BaseUrl = $"{applicationSettingsHelper.ApiBaseUrl}/LeaseType";
        }
    }
}
