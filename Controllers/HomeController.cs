using System.Diagnostics;
using System.Security.Claims;
using FastFood.Data;
using FastFood.Models;
using Microsoft.AspNetCore.Authorization;
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
            var itemFromDb = await _context.Items.Include(i => i.SubCategory).Where(x=>x.Id==Id).FirstOrDefaultAsync();
            var cart = new Cart()
            {
                Item = itemFromDb,
                ItemId = itemFromDb.Id,
                Count = 1
            };
            return View(cart);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Details(Cart cart)
        {
            // Retrieve the logged-in user's ID
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            cart.ApplicationUserId = claim.Value;

            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogError(error.ErrorMessage);
                }
                return RedirectToAction("Details", new { id = cart.ItemId });
            }

            // Check if the cart item already exists for the user
            var cartFromDb = await _context.Carts
                .FirstOrDefaultAsync(x => x.ApplicationUserId == cart.ApplicationUserId && x.ItemId == cart.ItemId);

            if (cartFromDb == null)
            {
                // Add a new cart item if it doesn't exist
                cart.Id = 0;
                _context.Carts.Add(cart);  // No need to set the Id manually
                await _context.SaveChangesAsync();
            }
            else
            {
                // Update the quantity if the item already exists in the cart
                cartFromDb.Count += cart.Count;
                await _context.SaveChangesAsync();
            }

            // Redirect to the Index page
            return RedirectToAction("Index");
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
