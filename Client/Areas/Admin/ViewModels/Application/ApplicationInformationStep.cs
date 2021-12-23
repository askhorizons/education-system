using Client.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Client.Areas.Admin.ViewModels
{
    public class ApplicationInformationStep : StepViewModel
    {
        [Required, Display(Name = "Session")]
        public int SessionId { get; set; }

        [Required, Display(Name = "Class")]
        public int ClassId { get; set; }

        [Display(Name = "Option No. 1")]
        public int OptionOneId{ get; set; }
        
        [Display(Name = "Option No. 2")]
        public int OptionTwoId{ get; set; }

        public ApplicationInformationStep()
        {
            Position = 3;
        }
    }
}
