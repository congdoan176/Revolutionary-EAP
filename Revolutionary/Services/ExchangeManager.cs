using Microsoft.EntityFrameworkCore;
using Revolutionary.Areas.Identity.Data.Contexts;
using Revolutionary.Areas.Identity.Data.Models;
using Revolutionary.Data;
using Revolutionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Services
{
    // this class is used for intercharging between 2 databases
    public class ExchangeManager
    {
        public class AuthenticationToApplication
        {
            // this class will help generate dual tables from Authentication -> Application: User, Role
            private readonly ApplicationContext _context;
            public AuthenticationToApplication(ApplicationContext context)
            {
                _context = context;
            }
            public async Task Create(User user)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
            }
            public async Task Edit(User user)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.User.Any(e => e.Id == user.Id))
                    {
                        throw;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            public async Task Delete(User user)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}