using Client.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Client.Areas.Admin.ViewModels
{
    public class StartApplicationStep
    {
        [Display(Name = "Cnic / B-Form")]
        [Required]
        [RegularExpression("^[0-9]{13}$", ErrorMessage = "{0} must be valid Cnic")]
        [StringLength(13, ErrorMessage = "{0} must be exact 13 characters", MinimumLength = 13)]
        public string Cnic { get; set; }

        public StartApplicationStep()
        {
        }
    }
}
