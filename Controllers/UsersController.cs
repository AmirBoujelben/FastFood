using FastFood.Data;
using FastFood.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace FastFood.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var users = _context.ApplicationUsers.Where(x => x.Id != claim.Value).ToList();
            return View(users);
        }

        // GET: Users/Edit/{id}
        public IActionResult Edit(string id)
        {
            if (id == null)
                return NotFound();

            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        // POST: Users/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationUser user)
        {
            if (!ModelState.IsValid)
                return View(user);

            var userInDb = _context.ApplicationUsers.FirstOrDefault(u => u.Id == user.Id);
            if (userInDb == null)
                return NotFound();

            userInDb.UserName = user.UserName;
            userInDb.Email = user.Email;
            // Add additional property updates as needed

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Delete/{id}
        public IActionResult Delete(string id)
        {
            if (id == null)
                return NotFound();

            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        // POST: Users/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();

            _context.ApplicationUsers.Remove(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
