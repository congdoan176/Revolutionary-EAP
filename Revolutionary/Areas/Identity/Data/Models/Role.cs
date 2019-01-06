using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Areas.Identity.Data.Models
{
    public class Role : IdentityRole<int>
    {
        public Role(string Name)
        {
            this.Name = Name;
        }
    }
}
