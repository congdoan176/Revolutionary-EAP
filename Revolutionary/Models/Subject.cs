using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class Subject
    {
        public Subject()
        {
            this.Status = SubjectStatus.Active;
        }
        [Key]
        [Required]
        public string Id { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public SubjectStatus Status { get; set; }
        public List<Class> Clazzes { get; set; }
    }

    public enum SubjectStatus
    {
        Active = 1,
        Deactive = 0
    }
}
