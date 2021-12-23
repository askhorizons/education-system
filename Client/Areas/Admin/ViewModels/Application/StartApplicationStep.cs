using Client.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Client.Areas.Admin.ViewModels
{
    public class StartApplicationStep
    {
        [Display(Name = "Cnic / B-Form")]
        [Required]
        public string Cnic { get; set; }

        public StartApplicationStep()
        {
        }
    }
}
