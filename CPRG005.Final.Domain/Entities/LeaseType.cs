
using System.ComponentModel.DataAnnotations.Schema;

namespace CPRG005.Final.Domain.Entities
{
    public interface ILeaseType : IEntity
    {
        string Name { get; set; }
        decimal StandardRateAmount { get; set; }
    }

    [Table("LeaseTypes")]
    public class LeaseType : Entity, ILeaseType
    {
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal StandardRateAmount { get; set; }
    }
}
