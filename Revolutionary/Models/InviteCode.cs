using Revolutionary.Areas.Identity.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Revolutionary.Models
{
    public class InviteCode
    {
        public InviteCode(string Code)
        {
            this.Code = Code;
            this.Status = InviteCodeStatus.Active;
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
        [Required]
        public string Code { get; set; }
        [Required]
        public InviteCodeStatus Status { get; set; }
        [Required]
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public enum InviteCodeStatus
    {
        Active = 1,
        Inactive = 0
    }
}
