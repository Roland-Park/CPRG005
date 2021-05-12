
namespace CPRG005.Final.Domain.Entities
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
