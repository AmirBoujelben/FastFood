using System.Diagnostics;
using FastFood.Data;
using FastFood.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Controllers
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

            var applicationDbContext = _context.Items.Include(i => i.SubCategory);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> Details(int Id)
        {
            var itemFromDb = await _context.Items.Include(i => i.SubCategory).Where(x => x.Id == Id).FirstOrDefaultAsync();
            var cart = new Cart()
            {
                Item = itemFromDb,
                ItemId = itemFromDb.Id,
                Count = 1
            };
            return View(cart);
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
