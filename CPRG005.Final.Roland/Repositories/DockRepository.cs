using CPRG005.Final.Roland.Helpers;
using CPRG005.Final.Roland.Models;

namespace CPRG005.Final.Roland.Repositories
{
    public class DockRepository
    {
        private IHttpHelper<Dock> httpHelper;

        public DockRepository(IHttpHelper<Dock> httpHelper, IApplicationSettingsHelper applicationSettingsHelper)
        {
            this.httpHelper = httpHelper;
            httpHelper.BaseUrl = $"{applicationSettingsHelper.ApiBaseUrl}/Dock";
        }
    }
}
