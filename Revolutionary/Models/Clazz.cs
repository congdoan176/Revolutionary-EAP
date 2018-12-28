using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class Clazz
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ShiftType Shift { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public ClazzStatus Status { get; set; }
        public Teacher Teacher { get; set; }
        public List<AccountClazz> AccountClazzes { get; set; }
    }

    public enum ClazzStatus
    {
        Active = 1,
        Deactive = 0
    }

    public enum ShiftType
    {
        Morning = 1,
        Afternoon = 2,
        Evening = 3
    }

}
