
namespace CPRG005.Final.Domain.Entities
{
    public interface IAuthorize : IEntity
    {
        string UserName { get; set; }
        string Password { get; set; }
        int CustomerId { get; set; }
    }
    public class Authorize : Entity, IAuthorize
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CustomerId { get; set; }

        #region Navigation properties
        public Customer Customer { get; set; }
        #endregion
    }
}
