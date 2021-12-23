using Client.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Client.Areas.Admin.ViewModels
{
    public class ReviewInformationStep : StepViewModel
    {
        public ReviewInformationStep()
        {
            Position = 4;
        }
    }
}
