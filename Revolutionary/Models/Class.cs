using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class Class
    {
        public Class()
        {
            this.Status = ClassStatus.Active;
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
        [Required(ErrorMessage = "Please input the current subject of the class")]
        public ICollection<ClassRegister> ClassRegisters { get; set; }
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "Please input class start date")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please input class end date")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Please input the class session (Morning, Afternoon or Evening)")]
        public ClassSession Session { get; set; }
        public ClassStatus Status { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }

    public enum ClassSession
    {
        Morning = 0,
        Afternoon = 1,
        Evening = 2
    }

    public enum ClassStatus
    {
        Active = 1,
        Deactive = 0
    }
}
