using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Revolutionary.Areas.Identity.Data.Models;
using Revolutionary.Data;
using Revolutionary.Models;

namespace Revolutionary.Controllers
{
    [Authorize(Roles = "Staff")]
    public class InviteCodesController : Controller
    {
        private readonly ApplicationContext _context;

        public InviteCodesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: InviteCodes
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.InviteCode.Include(i => i.Role);
            return View(await applicationContext.ToListAsync());
        }

        // GET: InviteCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inviteCode = await _context.InviteCode
                .Include(i => i.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inviteCode == null)
            {
                return NotFound();
            }

            return View(inviteCode);
        }

        // GET: InviteCodes/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Set<Role>(), "Id", "Id");
            return View();
        }

        // POST: InviteCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Status,RoleId,CreatedAt,UpdatedAt")] InviteCode inviteCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inviteCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Set<Role>(), "Id", "Id", inviteCode.RoleId);
            return View(inviteCode);
        }

        // GET: InviteCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inviteCode = await _context.InviteCode.FindAsync(id);
            if (inviteCode == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Set<Role>(), "Id", "Id", inviteCode.RoleId);
            return View(inviteCode);
        }

        // POST: InviteCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Status,RoleId,CreatedAt,UpdatedAt")] InviteCode inviteCode)
        {
            if (id != inviteCode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inviteCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InviteCodeExists(inviteCode.Id))
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
            ViewData["RoleId"] = new SelectList(_context.Set<Role>(), "Id", "Id", inviteCode.RoleId);
            return View(inviteCode);
        }

        // GET: InviteCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inviteCode = await _context.InviteCode
                .Include(i => i.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inviteCode == null)
            {
                return NotFound();
            }

            return View(inviteCode);
        }

        // POST: InviteCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inviteCode = await _context.InviteCode.FindAsync(id);
            _context.InviteCode.Remove(inviteCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InviteCodeExists(int id)
        {
            return _context.InviteCode.Any(e => e.Id == id);
        }
    }
}
