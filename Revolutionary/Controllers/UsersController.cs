using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Revolutionary.Data;
using Revolutionary.Models;

namespace Revolutionary.Controllers
{
    [Authorize(Roles = "Staff")]
    public class UsersController : Controller
    {
        private readonly UserManager<Revolutionary.Areas.Identity.Data.Models.User> _userManager;
        private readonly ApplicationContext _context;

        public UsersController(ApplicationContext context, UserManager<Revolutionary.Areas.Identity.Data.Models.User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize(Roles = "Student")]
        // GET: Users
        public async Task<IActionResult> Index(string Search)
        {
            if (!String.IsNullOrEmpty(Search))
            {
                var Users = from c in _context.User select c;
                Users = Users.Where(cs => cs.Name.Contains(Search) || cs.StudentCode.Contains(Search) || cs.Class.Contains(Search) || cs.PhoneNumber.Contains(Search) || cs.Email.Contains(Search));
                return View(await Users.ToListAsync());
            }
            return View(await _context.User.Include(u => u.ClassRegisters).ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Name,Class,StudentCode,PhoneNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                var u = Construct(user);
                var result = await _userManager.CreateAsync(u, "FPT@Student123");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(u, "Student");
                }
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Name,Class,StudentCode,PhoneNumber")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userManager.UpdateAsync(Construct(user));
                    _context.Update(user);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            await _userManager.DeleteAsync(Construct(user));
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }

        public Revolutionary.Areas.Identity.Data.Models.User Construct(User user)
        {
            return new Revolutionary.Areas.Identity.Data.Models.User()
            {
                UserName = user.Email,
                Name = user.Name,
                StudentCode = user.StudentCode,
                Class = user.Class,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}
