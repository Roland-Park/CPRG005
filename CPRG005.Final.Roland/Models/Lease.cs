using System;
using System.ComponentModel.DataAnnotations;

namespace CPRG005.Final.Roland.Models
{
    public interface ILease : IEntity
    {
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        int SlipId { get; set; }
        int CustomerId { get; set; }
        int LeaseTypeId { get; set; }
    }

    public class Lease : Entity, ILease
    {
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name="End Date")]
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
