using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public List<AccountRole> AccountRole { get; set; }

        public Role()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;            
        }
    }
}
