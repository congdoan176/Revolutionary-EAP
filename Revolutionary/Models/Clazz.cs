using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class Clazz
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public ClazzStatus Status { get; set; }
        public List<AccountClazz> AccountClazzes { get; set; }
    }

    public enum ClazzStatus
    {
        Active = 1,
        Deactive = 0
    }
}
