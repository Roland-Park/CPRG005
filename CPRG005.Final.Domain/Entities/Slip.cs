
using System.ComponentModel.DataAnnotations.Schema;

namespace CPRG005.Final.Domain.Entities
{
    public interface ISlip : IEntity
    {
        int Width { get; set; }
        int Length { get; set; }
        int DockId { get; set; }
    }

    [Table("Slips")]
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
