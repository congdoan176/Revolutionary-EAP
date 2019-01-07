using Revolutionary.Areas.Identity.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class Mark
    {
        private readonly int Total = 35;
        private readonly int PercentToPass = 40;

        public Mark() {
            this.SetStatus();
            this.SetTime();
        }

        private void SetStatus() {
            float percent = ((this.Theory + this.Practical + this.Assignment - this.Penalty) / Total) * 100;
            this.Status = Math.Round(percent) >= PercentToPass ? MarkStatus.Pass : MarkStatus.Fail;
        }

        private void SetTime()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ClassId { get; set; }
        [Required(ErrorMessage = "Please input mark value"),
            Range(0, 10, ErrorMessage = "Please input valid mark value")]
        public float Theory { get; set; }
        [Required(ErrorMessage = "Please input mark value"),
            Range(0, 15, ErrorMessage = "Please input valid mark value")]
        public float Practical { get; set; }
        [Required(ErrorMessage = "Please input mark value"),
            Range(0, 10, ErrorMessage = "Please input valid mark value")]
        public float Assignment { get; set; }
        [Range(0, 35)]
        public float Penalty { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public MarkStatus Status { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("ClassId")]
        public Class Class { get; set; }
    }

    public enum MarkStatus
    {
        Pass = 0,
        Fail = 1
    }

    
}
