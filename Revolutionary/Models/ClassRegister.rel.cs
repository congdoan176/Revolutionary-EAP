using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class ClassRegister
    {
        [Key]
        public int Id { get; set; }
        // this is a relationship model
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int ClassId { get; set; }
        [ForeignKey("UserId")]
        public Class Class { get; set; }
    }
}
