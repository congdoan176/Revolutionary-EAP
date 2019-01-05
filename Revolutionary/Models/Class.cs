using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class Class
    {
        public Class()
        {
            this.Status = ClassStatus.Active;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please input a code")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please input a start date")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please input a session")]
        public Session Session { get; set; }
        public ClassStatus Status { get; set; }
        [Required(ErrorMessage = "Please input a subject")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public enum Session
    {
        Morning = 1,
        Afternoon = 2
    }

    public enum ClassStatus
    {
        Active = 1,
        Inactive = 0
    }
}
