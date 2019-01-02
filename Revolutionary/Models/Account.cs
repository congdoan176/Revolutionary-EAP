using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class Account
    {
        [Key]
        public long Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public AccountStatus Status { get; set; }

        public List<AccountRole> AccountRoles { get; set; }
        public List<Mark> Marks { get; set; }
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
