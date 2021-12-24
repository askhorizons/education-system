using AutoMapper;
using Client.Areas.Admin.ViewModels;
using Client.Helpers;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CandidatesController : Controller
    {
        private readonly DataContext _context;
        private readonly ILogger<CandidatesController> _logger;
        private readonly IMapper _mapper;

        public CandidatesController(
            DataContext context,
            ILogger<CandidatesController> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;

        }

        #region Index
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Load Data
        [HttpGet]
        public IActionResult GetData(string cnic, string name)
        {
            return ViewComponent("Client.Areas.Admin.ViewComponents.CandidateList",
                new { cnic, name });
        }
        #endregion

        #region Step No. 1
        [HttpGet]
        public IActionResult Step1()
        {
            var model = new StartApplicationStep();

            var stepData = TempData.Get<StartApplicationStep>("Step1");
            if (stepData != null)
            {
                model.Cnic = stepData.Cnic;
            }
            TempData.Keep("Step1");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Step1(StartApplicationStep model)
        {
            if (ModelState.IsValid)
            {
                TempData.Set($"Step1", model);

                return RedirectToAction("Step2", new { area = "Admin", controller = "Candidates" });
            }

            return View(model);
        }
        #endregion

        #region Step No. 2
        [HttpGet]
        public IActionResult Step2()
        {
            var model = new PersonalInformationStep();

            var stepData = TempData.Get<PersonalInformationStep>("Step2");
            if (stepData != null)
            {
                model.Name = stepData.Name;
                model.DateOfBirth = stepData.DateOfBirth;
                model.GenderId = stepData.GenderId;
            }

            TempData.Keep("Step2");

            model.Genders = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Male" },
                new SelectListItem { Value = "2", Text = "Female" }
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Step2(PersonalInformationStep model)
        {
            if (ModelState.IsValid)
            {
                TempData.Set($"Step2", model);

                return RedirectToAction("Step3", new { area = "Admin", controller = "Candidates" });
            }

            model.Genders = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Male" },
                new SelectListItem { Value = "2", Text = "Female" }
            };

            return View(model);
        }
        #endregion

        #region Step No. 3
        [HttpGet]
        public IActionResult Step3()
        {
            var model = new ParentInformationStep();

            var stepData = TempData.Get<ParentInformationStep>("Step3");
            if (stepData != null)
            {
                model.Email = stepData.Email;
            }
            TempData.Keep("Step3");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Step3(ParentInformationStep model)
        {
            if (ModelState.IsValid)
            {
                TempData.Set($"Step3", model);

                return RedirectToAction("Step4", new { area = "Admin", controller = "Candidates" });
            }

            return View(model);
        }
        #endregion

        #region Step No. 4
        [HttpGet]
        public IActionResult Step4()
        {
            var model = new ApplicationInformationStep();

            var stepData = TempData.Get<ApplicationInformationStep>("Step4");
            if (stepData != null)
            {
                model.SessionId = stepData.SessionId;
                model.ClassId = stepData.ClassId;
                model.OptionOneId = stepData.OptionOneId;
                model.OptionTwoId = stepData.OptionTwoId;
            }

            TempData.Keep("Step4");


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Step4(ApplicationInformationStep model)
        {
            if (ModelState.IsValid)
            {
                TempData.Set($"Step4", model);

                return RedirectToAction("Step5", new { area = "Admin", controller = "Candidates" });
            }

            return View(model);
        }
        #endregion

        #region Step No. 5
        [HttpGet]
        public IActionResult Step5()
        {
            var model = new ReviewInformationStep();

            var stepData = TempData.Get<ReviewInformationStep>("Step5");
            if (stepData != null)
            {
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Step5(ReviewInformationStep model)
        {
            if (ModelState.IsValid)
            {
                TempData.Set($"Step5", model);

                return RedirectToAction("Index", new { area = "Admin", controller = "Candidates" });
            }

            return View(model);
        }
        #endregion
    }
}
