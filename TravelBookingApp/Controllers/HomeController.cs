using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TravelBookingApp.Data;
using TravelBookingApp.Models;

namespace TravelBookingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // ✅ 1. Récupérer les packages populaires (max 9)
            var packages = await _context.TravelPackages
                .Where(p => p.IsAvailable)
                .Include(p => p.Destination)
                .Take(9)
                .ToListAsync();

            // ✅ 2. Récupérer les destinations phares (ex: les 5 premières)
            var featuredDestinations = await _context.Destinations
                .Take(5)
                .ToListAsync();

            // ✅ 3. Passer les deux listes à la vue via ViewBag ou un ViewModel
            ViewBag.FeaturedDestinations = featuredDestinations;

            return View(packages);
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