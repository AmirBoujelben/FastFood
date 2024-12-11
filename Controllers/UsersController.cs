using FastFood.Data;
using FastFood.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Edit(string id, ApplicationUser user)
        {
            if (id != user.Id)
            {
                return BadRequest("User ID mismatch.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Retrieve the existing user
                    var existingUser = await _context.ApplicationUsers.FindAsync(id);
                    if (existingUser == null)
                    {
                        return NotFound();
                    }

                    // Update only the editable fields
                    existingUser.Name = user.Name;
                    existingUser.Email = user.Email;
                    existingUser.City = user.City;
                    existingUser.Address = user.Address;
                    existingUser.PostalCode = user.PostalCode;

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(user);
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

        private bool UserExists(string id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }
    }
}
