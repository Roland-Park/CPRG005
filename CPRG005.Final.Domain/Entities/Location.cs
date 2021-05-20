
using System.ComponentModel.DataAnnotations.Schema;

namespace CPRG005.Final.Domain.Entities
{
    public interface ILocation : IEntity
    {
        string Name { get; set; }
    }

    [Table("Locations")]
    public class Location : Entity, ILocation
    {
        public string Name { get; set; }
    }
}
