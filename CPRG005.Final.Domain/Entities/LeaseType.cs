
namespace CPRG005.Final.Domain.Entities
{
    public interface ILeaseType : IEntity
    {
        string Name { get; set; }
        decimal StandardRateAmount { get; set; }
    }
    public class LeaseType : Entity, ILeaseType
    {
        public string Name { get; set; }
        public decimal StandardRateAmount { get; set; }
    }
}
