using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Revolutionary.Models;

namespace Revolutionary.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        public DbSet<Revolutionary.Models.Class> Class { get; set; }
        /*public DbSet<Revolutionary.Models.ClassSubject> ClassSubject { get; set; }
        public DbSet<Revolutionary.Models.ClassUser> ClassUser { get; set; }*/
        public DbSet<Revolutionary.Models.Mark> Mark { get; set; }
        public DbSet<Revolutionary.Models.Subject> Subject { get; set; }
    }
}
