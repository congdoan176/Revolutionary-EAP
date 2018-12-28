using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class Staff
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public GenderType Gender { get; set; }
        public StaffStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public Account Account { get; set; }

        public Staff()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = StaffStatus.Active;
        }

    }

    public enum StaffStatus
    {
        Active = 1, 
        Deactive = 0
    }
}
