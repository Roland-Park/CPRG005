using System;

namespace CPRG005.Final.Api.ViewModels.Lease
{
    public class LeaseCreateViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SlipId { get; set; }
        public int CustomerId { get; set; }
        public int LeaseTypeId { get; set; }
    }
}
