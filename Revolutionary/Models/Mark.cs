using Revolutionary.Areas.Identity.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class Mark
    {
        /*private static readonly int MaxTheory = 10;
        private static readonly int MaxPractice = 15;
        private static readonly int MaxAssignment = 10;
        */
        private static readonly int PercentToPass = 40;

        public Mark() {
            this.SetTime();
        }

        public Mark(int Base, int Value)
        {
            this.MarkBase = Base;
            this.Value = Value;
            this.SetStatus();
            this.SetTime();
        }

        public Mark(int Base, int value, int SubjectId, int UserId)
        {
            this.SubjectId = SubjectId;
            this.UserId = UserId;
            this.MarkBase = Base;
            this.Value = value;
            this.SetStatus();
            this.SetTime();
        }

        private void SetStatus() {
            float percent = (this.Value * this.MarkBase / 10) * 100;
            this.Status = percent >= PercentToPass ? MarkStatus.Pass : MarkStatus.Fail;
        }

        private void SetTime()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please input account")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please input subject")]
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "Please input mark value"),
            Range(0, 15, ErrorMessage = "Please input valid mark value")]
        public float Value { get; set; }
        [Required(ErrorMessage = "Please input mark type")]
        public float MarkBase { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public MarkStatus Status { get; set; }
        public User User { get; set; }
        public Subject Subject { get; set; }
    }

    public enum MarkStatus
    {
        Pass = 0,
        Fail = 1
    }

    
}
