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
            this.SetTime();
        }

        private void SetTime()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter subject name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public SubjectStatus Status { get; set; }
        public List<Class> Classes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public enum SubjectStatus
    {
        Active = 1,
        Inactive = 0
    }
}
