using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class ClassUser
    {
        [Key]
        public long Id { get; set; }
        public int ClassId { get; set; }
        public int UserId { get; set; }
        public Class Class { get; set; }
    }
}
