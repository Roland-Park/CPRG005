using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPRG005.Final.Domain.Entities
{
    public interface ILease : IEntity
    {
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        int SlipId { get; set; }
        int CustomerId { get; set; }
        int LeaseTypeId { get; set; }
    }

    [Table("Leases")]
    public class Lease : Entity, ILease
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SlipId { get; set; }
        public int CustomerId { get; set; }
        public int LeaseTypeId { get; set; }

        #region Navigation properties
        public Customer Customer { get; set; }
        public LeaseType LeaseType { get; set; }
        public Slip Slip { get; set; }
        #endregion
    }
}
