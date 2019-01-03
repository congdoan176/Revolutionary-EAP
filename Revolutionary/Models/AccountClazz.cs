using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class AccountClazz
    {
        public long AccountId { get; set; }
        public long ClazzId { get; set; }

        public Account Account { get; set; }
        public Clazz Clazz { get; set; }
    }
}
