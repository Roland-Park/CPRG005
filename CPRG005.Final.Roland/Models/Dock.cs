
namespace CPRG005.Final.Roland.Models
{
    public interface IDock : IEntity
    {
        string Name { get; set; }
        int LocationId { get; set; }
        bool HasWaterService { get; set; }
        bool HasElectricService { get; set; }
    }

    public class Dock : Entity, IDock
    {
        public string Name { get; set; }
        public int LocationId { get; set; }
        public bool HasWaterService { get; set; }
        public bool HasElectricService { get; set; }

        #region Navigation properties
        public Location Location { get; set; }
        #endregion
    }
}
