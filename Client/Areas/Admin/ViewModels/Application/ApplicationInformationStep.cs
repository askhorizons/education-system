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
        public IEnumerable<SelectListItem> Sessions { get; set; }


        [Required, Display(Name = "Class")]
        public int ClassId { get; set; }
        public IEnumerable<SelectListItem> Classes { get; set; }

        [Display(Name = "Option No. 1")]
        public int OptionOneId{ get; set; }
        public IEnumerable<SelectListItem> Options1 { get; set; }

        [Display(Name = "Option No. 2")]
        public int OptionTwoId{ get; set; }
        public IEnumerable<SelectListItem> Options2 { get; set; }

        public ApplicationInformationStep()
        {
        }
    }
}
