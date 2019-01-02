using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Revolutionary.Data;
using Revolutionary.Models;
using HashidsNet;
using Revolutionary.Helper;

namespace Revolutionary.Controllers
{
    public class AccountInfomationsController : Controller
    {
        private readonly RevolutionaryContext _context;

        public AccountInfomationsController(RevolutionaryContext context)
        {
            _context = context;
        }

        // GET: AccountInfomations
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountInfomation.ToListAsync());
        }

        // GET: AccountInfomations/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountInfomation = await _context.AccountInfomation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountInfomation == null)
            {
                return NotFound();
            }

            return View(accountInfomation);
        }

        // GET: AccountInfomations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountInfomations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,FirstName,LastName,BirthDay,Phone,Gender,Address")] AccountInfomation accountInfomation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountInfomation);
                var hashId = new Hashids("FPTAptech");
                Account newAccount = new Account()
                {                    
                    Salt = PasswordHandle.GetInstance().GenerateSalt(),                    
                };
                newAccount.Password = PasswordHandle.GetInstance().EncryptPassword("123456789", newAccount.Salt);
                newAccount.Username = "Student" + String.Format("{0:X}", accountInfomation.Email.GetHashCode());                
                _context.Add(newAccount);
                await _context.SaveChangesAsync();                
                return RedirectToAction(nameof(Index));
            }
            return View(accountInfomation);
        }

        // GET: AccountInfomations/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountInfomation = await _context.AccountInfomation.FindAsync(id);
            if (accountInfomation == null)
            {
                return NotFound();
            }
            return View(accountInfomation);
        }

        // POST: AccountInfomations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Email,FirstName,LastName,BirthDay,Phone,Gender,Address")] AccountInfomation accountInfomation)
        {
            if (id != accountInfomation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountInfomation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountInfomationExists(accountInfomation.Id))
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
            return View(accountInfomation);
        }

        // GET: AccountInfomations/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountInfomation = await _context.AccountInfomation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountInfomation == null)
            {
                return NotFound();
            }

            return View(accountInfomation);
        }

        // POST: AccountInfomations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var accountInfomation = await _context.AccountInfomation.FindAsync(id);
            _context.AccountInfomation.Remove(accountInfomation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountInfomationExists(long id)
        {
            return _context.AccountInfomation.Any(e => e.Id == id);
        }

        private string HashEmail(string email)
        {
            var hashId = new Hashids("FPTAptech");
            return hashId.EncodeHex(email);
        }
    }   


}
