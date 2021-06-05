
using System.ComponentModel.DataAnnotations;

namespace CPRG005.Final.Roland.ViewModels
{
    public class CreateBoatViewModel
    {
        [Display(Name= "Registration Number")]
        public string RegistrationNumber { get; set; }
        [Display(Name= "Manufacturer")]
        public string Manufacturer { get; set; }
        [Display(Name= "Model Year")]
        public int ModelYear { get; set; }
        [Display(Name= "Length (ft)")]
        public int Length { get; set; }
    }
}
