using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Revolutionary.Data;
using Revolutionary.Models;

namespace Revolutionary.Controllers
{
    public class ClassRegistersController : Controller
    {
        private readonly ApplicationContext _context;

        public ClassRegistersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: ClassRegisters
        public async Task<IActionResult> Index(String Search)
        {
            if (!String.IsNullOrEmpty(Search))
            {
                var Registers = from c in _context.ClassRegister select c;
                Registers = Registers.Where(cs => cs.User.Name.Contains(Search) || cs.User.StudentCode.Contains(Search) || cs.User.Class.Contains(Search) || cs.Class.Name.Contains(Search) || cs.Class.Subject.Name.Contains(Search));
                return View(await Registers.ToListAsync());
            }
            var applicationContext = _context.ClassRegister.Include(c => c.Class).Include(c => c.User);
            return View(await applicationContext.ToListAsync());
        }

        // GET: ClassRegisters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classRegister = await _context.ClassRegister
                .Include(c => c.Class)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classRegister == null)
            {
                return NotFound();
            }

            return View(classRegister);
        }

        // GET: ClassRegisters/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Class, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Class");
            return View();
        }

        // POST: ClassRegisters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ClassId")] ClassRegister classRegister)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classRegister);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Class, "Id", "Id", classRegister.UserId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Class", classRegister.UserId);
            return View(classRegister);
        }

        // GET: ClassRegisters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classRegister = await _context.ClassRegister.FindAsync(id);
            if (classRegister == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Class, "Id", "Id", classRegister.UserId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Class", classRegister.UserId);
            return View(classRegister);
        }

        // POST: ClassRegisters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ClassId")] ClassRegister classRegister)
        {
            if (id != classRegister.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classRegister);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassRegisterExists(classRegister.Id))
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
            ViewData["UserId"] = new SelectList(_context.Class, "Id", "Id", classRegister.UserId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Class", classRegister.UserId);
            return View(classRegister);
        }

        // GET: ClassRegisters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classRegister = await _context.ClassRegister
                .Include(c => c.Class)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classRegister == null)
            {
                return NotFound();
            }

            return View(classRegister);
        }

        // POST: ClassRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classRegister = await _context.ClassRegister.FindAsync(id);
            _context.ClassRegister.Remove(classRegister);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassRegisterExists(int id)
        {
            return _context.ClassRegister.Any(e => e.Id == id);
        }
    }
}
