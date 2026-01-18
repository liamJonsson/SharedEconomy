using Microsoft.AspNetCore.Mvc;
using SharedEconomy.Data.Models;
using SharedEconomy.Web.ViewModels;
using System.Diagnostics;

namespace SharedEconomy.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SharedEconomyDbContext _context;

        public HomeController(ILogger<HomeController> logger, SharedEconomyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var profiles = _context.Profiles.ToList();
            return View(profiles);
        }

        public IActionResult Privacy()
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
