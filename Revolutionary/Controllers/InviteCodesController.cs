using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Revolutionary.Data;
using Revolutionary.Models;

namespace Revolutionary.Controllers
{
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
            return View(await _context.InviteCode.ToListAsync());
        }

        // GET: InviteCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inviteCode = await _context.InviteCode
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
