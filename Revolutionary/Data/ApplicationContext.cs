using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Revolutionary.Areas.Identity.Data.Models;
using Revolutionary.Models;

namespace Revolutionary.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        public DbSet<Class> Class { get; set; }
        /*public DbSet<Revolutionary.Models.ClassSubject> ClassSubject { get; set; }
        public DbSet<Revolutionary.Models.ClassUser> ClassUser { get; set; }*/
        public DbSet<Mark> Mark { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<InviteCode> InviteCode { get; set; }
        #region DummyDbSet
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        #endregion
    }
}
