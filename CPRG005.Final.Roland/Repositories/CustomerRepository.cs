using CPRG005.Final.Roland.Helpers;
using CPRG005.Final.Roland.Models;

namespace CPRG005.Final.Roland.Repositories
{
    public class CustomerRepository
    {
        private IHttpHelper<Customer> httpHelper;

        public CustomerRepository(IHttpHelper<Customer> httpHelper, IApplicationSettingsHelper applicationSettingsHelper)
        {
            this.httpHelper = httpHelper;
            httpHelper.BaseUrl = $"{applicationSettingsHelper.ApiBaseUrl}/Customer";
        }
    }
}
