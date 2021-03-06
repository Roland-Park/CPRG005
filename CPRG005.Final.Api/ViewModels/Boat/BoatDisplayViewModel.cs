using CPRG005.Final.Api.ViewModels.Customer;

namespace CPRG005.Final.Api.ViewModels.Boat
{
    public class BoatDisplayViewModel
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string Manufacturer { get; set; }
        public int ModelYear { get; set; }
        public int Length { get; set; }
        public int CustomerId { get; set; }
    }
}
