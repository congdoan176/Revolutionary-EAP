using Revolutionary.Areas.Identity.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class Persistent
    {
        public Persistent()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
        [Key]
        [Required]
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
