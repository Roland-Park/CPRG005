
namespace CPRG005.Final.Roland.Models
{
    public interface ISlip : IEntity
    {
        int Width { get; set; }
        int Length { get; set; }
        int DockId { get; set; }
    }

    public class Slip : Entity, ISlip
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public int DockId { get; set; }

        #region Navigation properties
        public Dock Dock { get; set; }
        #endregion
    }
}
