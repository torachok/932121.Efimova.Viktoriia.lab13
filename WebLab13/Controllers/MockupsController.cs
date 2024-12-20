using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebLab13.Models;

namespace WebLab13.Controllers
{

    public class MockupsController : Controller
    {
        private readonly ILogger<MockupsController> _logger;

        public MockupsController(ILogger<MockupsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
