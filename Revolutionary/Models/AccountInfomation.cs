using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class AccountInfomation
    {
        [Key]
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public GenderType Gender { get; set; }
        public string Address { get; set; }
        public Account Account { get; set; }
    }

    public enum GenderType
    {
        Male = 1, 
        Female = 0,
        Unknown = -1
    }
}
