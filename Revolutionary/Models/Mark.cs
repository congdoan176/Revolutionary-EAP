using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class Mark
    {
        public float Value { get; set; }
        public MarkType Type { get; set; }
        public DateTime CreatedAt { get; set; }        
        public Subject Subject { get; set; }        
        public Account Account { get; set; }
    }

    public enum MarkType
    {
        Theory = 1,
        Practice = 2,
        Assignment = 3
    }
}
