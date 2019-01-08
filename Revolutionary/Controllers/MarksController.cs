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
    [Authorize]
    public class MarksController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<Revolutionary.Areas.Identity.Data.Models.User> _userManager;

        public MarksController(ApplicationContext context, UserManager<Revolutionary.Areas.Identity.Data.Models.User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        // GET: Marks
        public async Task<IActionResult> Index(string Search)
        {
            if (User.IsInRole("Student"))
            {
                var user = await GetCurrentUserAsync();
                var Marks = from c in _context.Mark.Include(m => m.Class).Include(m => m.User) select c;
                Marks = Marks.Where(cs => cs.UserId == user.Id);
                return View(await Marks.ToListAsync());
            }
            else
            {
                if (!String.IsNullOrEmpty(Search))
                {
                    var Marks = from c in _context.Mark select c;
                    Marks = Marks.Where(cs => cs.User.Name.Contains(Search) || cs.User.Class.Contains(Search) || cs.User.StudentCode.Contains(Search));
                    return View(await Marks.ToListAsync());
                }
                var applicationContext = _context.Mark.Include(m => m.Class).Include(m => m.User);
                return View(await applicationContext.ToListAsync());
            }
        }
        [Authorize(Roles = "Staff")]
        // GET: Marks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Mark
                .Include(m => m.Class)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }
        [Authorize(Roles = "Staff")]
        // GET: Marks/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Name");
            return View();
        }
        [Authorize(Roles = "Staff")]
        // POST: Marks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,ClassId,Theory,Practical,Assignment,Penalty")] Mark mark)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name", mark.ClassId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Name", mark.UserId);
            return View(mark);
        }
        [Authorize(Roles = "Staff")]
        // GET: Marks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Mark.FindAsync(id);
            if (mark == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name", mark.ClassId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Name", mark.UserId);
            return View(mark);
        }
        [Authorize(Roles = "Staff")]
        // POST: Marks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ClassId,Theory,Practical,Assignment,Penalty")] Mark mark)
        {
            if (id != mark.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkExists(mark.Id))
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
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name", mark.ClassId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Name", mark.UserId);
            return View(mark);
        }
        [Authorize(Roles = "Staff")]
        // GET: Marks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Mark
                .Include(m => m.Class)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }
        [Authorize(Roles = "Staff")]
        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mark = await _context.Mark.FindAsync(id);
            _context.Mark.Remove(mark);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkExists(int id)
        {
            return _context.Mark.Any(e => e.Id == id);
        }
        private async Task<Revolutionary.Areas.Identity.Data.Models.User> GetCurrentUserAsync()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
