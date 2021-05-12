
using CPRG005.Final.Api.ViewModels.Customer;

namespace CPRG005.Final.Api.ViewModels.Authorize
{
    public class AuthorizeDisplayViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public CustomerDisplayViewModel Customer { get; set; }
    }
}
