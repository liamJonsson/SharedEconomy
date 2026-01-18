using Microsoft.AspNetCore.Mvc;
using SharedEconomy.Data.Models;
using SharedEconomy.Web.ViewModels;
using System.Diagnostics;

namespace SharedEconomy.Web.Controllers
    
{
    public class UserController : Controller
    {
        private readonly SharedEconomyDbContext _context;

        public UserController(SharedEconomyDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
