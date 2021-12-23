using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetData()
        {
            return ViewComponent("Client.Areas.Admin.ViewComponents.UserList");
        }
    }
}
