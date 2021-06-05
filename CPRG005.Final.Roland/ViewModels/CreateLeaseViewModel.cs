using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG005.Final.Roland.ViewModels
{
    public class CreateLeaseViewModel
    {
        public DateTime Start { get; set; }
        [Display(Name="Slip#")]
        public int SlipId { get; set; }
        [Display(Name="Lease Type")]
        public int LeaseTypeId { get; set; }
    }
}
