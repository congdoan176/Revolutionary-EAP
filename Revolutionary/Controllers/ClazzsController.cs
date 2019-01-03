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
    public class ClazzsController : Controller
    {
        private readonly RevolutionaryContext _context;

        public ClazzsController(RevolutionaryContext context)
        {
            _context = context;
        }

        // GET: Clazzs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clazzes.ToListAsync());
        }

        // GET: Clazzs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clazz = await _context.Clazzes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clazz == null)
            {
                return NotFound();
            }

            return View(clazz);
        }

        // GET: Clazzs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clazzs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Shift,CreatedAt,UpdatedAt,DeletedAt,Status")] Clazz clazz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clazz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clazz);
        }

        // GET: Clazzs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clazz = await _context.Clazzes.FindAsync(id);
            if (clazz == null)
            {
                return NotFound();
            }
            return View(clazz);
        }

        // POST: Clazzs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Shift,CreatedAt,UpdatedAt,DeletedAt,Status")] Clazz clazz)
        {
            if (id != clazz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clazz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClazzExists(clazz.Id))
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
            return View(clazz);
        }

        // GET: Clazzs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clazz = await _context.Clazzes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clazz == null)
            {
                return NotFound();
            }

            return View(clazz);
        }

        // POST: Clazzs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var clazz = await _context.Clazzes.FindAsync(id);
            _context.Clazzes.Remove(clazz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClazzExists(long id)
        {
            return _context.Clazzes.Any(e => e.Id == id);
        }
    }
}
