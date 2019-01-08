using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Revolutionary.Data;
using Revolutionary.Models;

namespace Revolutionary.Controllers
{
    [Authorize]
    public class ClassesController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<Revolutionary.Areas.Identity.Data.Models.User> _userManager;
        private static object locker = new object();

        public ClassesController(ApplicationContext context, UserManager<Revolutionary.Areas.Identity.Data.Models.User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        // GET: Classes
        // optional: Classes?Search=
        public async Task<IActionResult> Index(string Search)
        {
            if (User.IsInRole("Student"))
            {
                var user = await GetCurrentUserAsync();
                var Classes = from c in _context.Class.Include(c => c.Subject) select c;
                Classes = Classes.Where(cs => cs.StartDate <= DateTime.Now && cs.EndDate >= DateTime.Now);
                var ListClasses = await Classes.ToListAsync();
                if (ListClasses.Count > 0)
                {

                    for (int i = 0; i < ListClasses.Count; i++) {
                        if (await _context.ClassRegister.AnyAsync(cr => cr.ClassId == ListClasses.ElementAt(i).Id && cr.UserId == user.Id))
                        {
                            ListClasses.RemoveAt(i);
                            if (i == ListClasses.Count - 1) ListClasses.Clear();
                        }
                    }
                }
                return View(ListClasses);
            }
            else
            {
                if (!String.IsNullOrEmpty(Search))
                {
                    var Classes = from c in _context.Class.Include(c => c.Subject) select c;
                    Classes = Classes.Where(cs => cs.Name.Contains(Search) || cs.Subject.Name.Contains(Search));
                    return View(await Classes.ToListAsync());
                }
                return View(await _context.Class.Include(c => c.Subject).ToListAsync());
            }
        }
        [Authorize(Roles = "Staff")]
        // GET: Classes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Class
                .Include(c => c.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }
        [Authorize(Roles = "Staff")]
        // GET: Classes/Create
        public IActionResult Create()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name");
            return View();
        }
        [Authorize(Roles = "Staff")]
        // POST: Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Code,SubjectId,StartDate,EndDate,Session,Status")] Class @class)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@class);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name", @class.SubjectId);
            return View(@class);
        }
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Register(int id)
        {
            var user = await GetCurrentUserAsync();
            if (await _context.ClassRegister.AnyAsync(c => c.UserId == user.Id && c.ClassId == id))
            {
                return Redirect("/ClassRegisters");
            }
            ClassRegister classRegister = new ClassRegister()
            {
                UserId = user.Id,
                ClassId = id
            };
            _context.ClassRegister.Add(classRegister);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Staff")]
        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Class.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name", @class.SubjectId);
            return View(@class);
        }
        [Authorize(Roles = "Staff")]
        // POST: Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Code,SubjectId,StartDate,EndDate,Session,Status")] Class @class)
        {
            if (id != @class.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(@class.Id))
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
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name", @class.SubjectId);
            return View(@class);
        }
        [Authorize(Roles = "Staff")]
        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Class
                .Include(c => c.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }
        [Authorize(Roles = "Staff")]
        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @class = await _context.Class.FindAsync(id);
            _context.Class.Remove(@class);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(int id)
        {
            return _context.Class.Any(e => e.Id == id);
        }

        private async Task<Revolutionary.Areas.Identity.Data.Models.User> GetCurrentUserAsync()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
