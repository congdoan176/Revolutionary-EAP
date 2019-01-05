using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class Mark
    {
        private static readonly int MaxTheory = 10;
        private static readonly int MaxPractice = 15;
        private static readonly int MaxAssignment = 10;
        private static readonly int PassPercent = 40;

        public Mark(int value, int markbase, int subjectId, int accountId)
        {
            this.SubjectId = subjectId;
            this.AccountId = accountId;
            this.Base = markbase;
            this.Value = value;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int AccountId { get; set; }
        [Required(ErrorMessage = "Please input a subject")]
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "Please input a mark"), Range(0, 15, ErrorMessage = "Please input valid mark value")]
        public float Value { get; set; }
        [Required(ErrorMessage = "Please input a base")]
        public float Base { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public MarkStatus Status { get; set; }
    }

    public enum MarkStatus
    {
        Pass = 0,
        Fail = 1
    }
}
