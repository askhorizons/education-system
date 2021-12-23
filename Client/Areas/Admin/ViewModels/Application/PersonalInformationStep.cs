using Client.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Client.Areas.Admin.ViewModels
{
    public class PersonalInformationStep
    {
        [Required, Display(Name = "Name")]
        public string Name { get; set; }

        [Required, Display(Name = "Gender")]
        public int GenderId { get; set; }
        public IEnumerable<SelectListItem> Genders { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }

        public PersonalInformationStep()
        {
        }
    }
}
