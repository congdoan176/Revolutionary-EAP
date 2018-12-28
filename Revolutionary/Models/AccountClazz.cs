using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class AccountClazz
    {
        public Guid AccountId { get; set; }
        public Guid ClazzId { get; set; }

        public Account Account { get; set; }
        public Clazz Clazz { get; set; }
    }
}
