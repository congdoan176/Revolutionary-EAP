using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Revolutionary.Models
{
    public class Account:IdentityUser
    {
        //[Key]
        //public long Id { get; set; }        
        //public string Username { get; set; }
        //public string Password { get; set; }        
        //public string Salt { get; set; }
        [PersonalData]
        public DateTime CreatedAt { get; set; }
        [PersonalData]
        public DateTime UpdatedAt { get; set; }
        [PersonalData]
        public DateTime DeletedAt { get; set; }
        [PersonalData]
        public AccountStatus Status { get; set; }

        public List<AccountRole> AccountRoles { get; set; }
        [PersonalData]
        public List<Mark> Marks { get; set; }
        [PersonalData]
        public List<AccountClazz> AccountClazzes { get; set; }

        public Account()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = AccountStatus.Active;
        }
    }
    public enum AccountStatus
    {
        Active = 1,
        Deactive = 0
    }
}
