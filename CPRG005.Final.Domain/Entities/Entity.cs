using System.ComponentModel.DataAnnotations;

namespace CPRG005.Final.Domain.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public abstract class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
