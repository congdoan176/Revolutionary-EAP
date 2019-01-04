using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Revolutionary.Models
{
    public class AccountRole:IdentityUserRole<string>
    {
        public Account Account { get; set; }
        public Role Role { get; set; }
    }
}
