
namespace CPRG005.Final.Domain.Entities
{
    public interface IBoat : IEntity
    {
        string RegistrationNumber { get; set; }
        string Manufacturer { get; set; }
        int ModelYear { get; set; }
        int Length { get; set; }
        int CustomerId { get; set; }
    }
    public class Boat : Entity, IBoat
    {
        public string RegistrationNumber { get; set; }
        public string Manufacturer { get; set; }
        public int ModelYear { get; set; }
        public int Length { get; set; }
        public int CustomerId { get; set; }

        #region Navigation properties
        public Customer Customer { get; set; }
        #endregion
    }
}
