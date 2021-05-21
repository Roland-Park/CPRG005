
namespace CPRG005.Final.Roland.Models
{
    public interface ILocation : IEntity
    {
        string Name { get; set; }
    }

    public class Location : Entity, ILocation
    {
        public string Name { get; set; }
    }
}
