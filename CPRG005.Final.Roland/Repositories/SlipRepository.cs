using CPRG005.Final.Roland.Helpers;
using CPRG005.Final.Roland.Models;

namespace CPRG005.Final.Roland.Repositories
{
    public class SlipRepository
    {
        private IHttpHelper<Slip> httpHelper;

        public SlipRepository(IHttpHelper<Slip> httpHelper, IApplicationSettingsHelper applicationSettingsHelper)
        {
            this.httpHelper = httpHelper;
            httpHelper.BaseUrl = $"{applicationSettingsHelper.ApiBaseUrl}/Slip";
        }
    }
}
