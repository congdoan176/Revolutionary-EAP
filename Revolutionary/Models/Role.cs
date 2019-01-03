using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Revolutionary.Models
{
    public class Role:IdentityRole
    {
        [PersonalData]
        public DateTime CreatedAt { get; set; }
        [PersonalData]
        public DateTime UpdatedAt { get; set; }
        [PersonalData]
        public DateTime DeletedAt { get; set; }

        public List<AccountRole> AccountRole { get; set; }

        public Role()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;            
        }

        public Role(string name)
        {
            this.Name = name;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    }
}
