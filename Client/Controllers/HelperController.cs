using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    [Authorize]
    public class HelperController : Controller
    {
        [HttpGet]
        public IActionResult SearchParent()
        {

            return PartialView();
        }
    }
}
