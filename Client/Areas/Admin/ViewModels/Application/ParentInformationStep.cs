using Client.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Client.Areas.Admin.ViewModels
{
    public class ParentInformationStep
    {
        [Required, Display(Name = "Father / Mother")]
        public int ParentId { get; set; }

        [Required, Display(Name = "Fee Payer")]
        public int FeePayerId { get; set; }

        [Required, Display(Name = "Email")]
        public string Email{ get; set; }

        public ParentInformationStep()
        {
        }
    }
}
