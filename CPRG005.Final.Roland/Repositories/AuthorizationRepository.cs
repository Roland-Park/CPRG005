using CPRG005.Final.Roland.Helpers;
using CPRG005.Final.Roland.Models;

namespace CPRG005.Final.Roland.Repositories
{
    public class AuthorizationRepository
    {
        private IHttpHelper<Authorize> httpHelper;

        public AuthorizationRepository(IHttpHelper<Authorize> httpHelper, IApplicationSettingsHelper applicationSettingsHelper)
        {
            this.httpHelper = httpHelper;
            httpHelper.BaseUrl = $"{applicationSettingsHelper.ApiBaseUrl}/Authorize";
        }
    }
}
