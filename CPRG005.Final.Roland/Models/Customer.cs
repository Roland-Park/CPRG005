
namespace CPRG005.Final.Roland.Models
{
    public interface ICustomer : IEntity
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Phone { get; set; }
        string City { get; set; }
    }

    public class Customer : Entity, ICustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
}
