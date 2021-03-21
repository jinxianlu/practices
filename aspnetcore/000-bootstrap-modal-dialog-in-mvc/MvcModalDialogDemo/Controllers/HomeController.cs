using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcModalDialogDemo.Models;
using MvcModalDialogDemo.Views.Home;

namespace MvcModalDialogDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Modal()
        {
            var model = new DemoViewModel
            {
                Username = "sam.zhang",
                Password = "1234",
                Email  = "sam.zhang@google.com"
            };
            return PartialView("_ModalDialog", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Modal(DemoViewModel input)
        {
            _logger.LogWarning($"{input.Username} has signed in");
            return RedirectToAction(nameof(Index));
        }
    }
}
