
using System.ComponentModel.DataAnnotations;

namespace CPRG005.Final.Roland.ViewModels
{
    public class EditBoatViewModel
    {
        public int BoatId { get; set; }
        [Display(Name = "Registration Number")]
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters must be alphanumeric.")]
        public string RegistrationNumber { get; set; }
        [Display(Name = "Manufacturer")]
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters must be alphanumeric.")]
        public string Manufacturer { get; set; }
        [Display(Name = "Model Year")]
        public int ModelYear { get; set; }
        [Display(Name = "Length (ft)")]
        public int Length { get; set; }
    }
}
