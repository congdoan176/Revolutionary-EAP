using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class AccountInfomation
    {
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
