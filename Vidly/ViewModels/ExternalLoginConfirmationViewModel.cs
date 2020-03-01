using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }
        [Required]
        [MaxLength(15)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}