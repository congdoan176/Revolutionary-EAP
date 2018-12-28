using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class Subject
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EndAt { get; set; }
        public SubjectStatus Status { get; set; }

        public List<Mark> Mark { get; set; }
    }

    public enum SubjectStatus
    {
        Active = 1,
        Deactive = 0
    }
}
