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

            //TempData.Clear();
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
            }

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

            return View(model);
        }
        #endregion
    }
}
