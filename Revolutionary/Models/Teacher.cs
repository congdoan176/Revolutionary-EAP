using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class Teacher
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public TeacherStatus Status { get; set; }
        public List<Clazz> Clazzes { get; set; }
    }

    public enum TeacherStatus
    {
        Active = 1,
        Deactive = 0
    }
}
