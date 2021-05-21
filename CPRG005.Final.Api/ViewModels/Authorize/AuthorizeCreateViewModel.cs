
using CPRG005.Final.Api.ViewModels.Customer;

namespace CPRG005.Final.Api.ViewModels.Authorize
{
    public class AuthorizeCreateViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public CustomerCreateViewModel Customer { get; set; }
    }
}
