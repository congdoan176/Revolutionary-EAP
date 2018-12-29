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
    public class MarksController : Controller
    {
        private readonly RevolutionaryContext _context;

        public MarksController(RevolutionaryContext context)
        {
            _context = context;
        }

        // GET: Marks
        public async Task<IActionResult> Index()
        {
            var revolutionaryContext = _context.Marks.Include(m => m.Account).Include(m => m.Subject);
            return View(await revolutionaryContext.ToListAsync());
        }

        // GET: Marks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Marks
                .Include(m => m.Account)
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }

        // GET: Marks/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Id");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id");
            return View();
        }

        // POST: Marks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Value,Type,SubjectId,AccountId,CreatedAt")] Mark mark)
        {
            if (ModelState.IsValid)
            {
                mark.AccountId = Guid.NewGuid();
                _context.Add(mark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Id", mark.AccountId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", mark.SubjectId);
            return View(mark);
        }

        // GET: Marks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Marks.FindAsync(id);
            if (mark == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Id", mark.AccountId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", mark.SubjectId);
            return View(mark);
        }

        // POST: Marks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Value,Type,SubjectId,AccountId,CreatedAt")] Mark mark)
        {
            if (id != mark.AccountId)
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
                    if (!MarkExists(mark.AccountId))
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
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Id", mark.AccountId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", mark.SubjectId);
            return View(mark);
        }

        // GET: Marks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Marks
                .Include(m => m.Account)
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var mark = await _context.Marks.FindAsync(id);
            _context.Marks.Remove(mark);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkExists(Guid id)
        {
            return _context.Marks.Any(e => e.AccountId == id);
        }
    }
}
