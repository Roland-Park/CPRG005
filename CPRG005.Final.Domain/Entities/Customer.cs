
using System.ComponentModel.DataAnnotations.Schema;

namespace CPRG005.Final.Domain.Entities
{
    public interface ICustomer : IEntity
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Phone { get; set; }
        string City { get; set; }
    }

    [Table("Customers")]
    public class Customer : Entity, ICustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
}
