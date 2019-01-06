using Microsoft.EntityFrameworkCore;
using Revolutionary.Data;
using Revolutionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Services
{
    public class InviteCodesManager
    {
        private readonly ApplicationContext _context;

        public InviteCodesManager(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> Validate(String Token)
        {
            return 1;
            /*
            InviteCode type = await _context.InviteCode.FirstOrDefaultAsync(i => string.Equals(i.Code, Token));
            if (type == null || type.Status == InviteCodeStatus.Inactive)
            {
                return 0;
            }
            return type.RoleId;
            */
        }
    }
}
