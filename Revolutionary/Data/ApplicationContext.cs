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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InviteCode>().HasData(
                new InviteCode() { Id = 1, Code = "AAAAAA", RoleId = InviteCodeRole.Staff }, 
                new InviteCode() { Id = 2, Code = "BBBBBB", RoleId = InviteCodeRole.Student }
            );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Class> Class { get; set; }
        /*public DbSet<Revolutionary.Models.ClassSubject> ClassSubject { get; set; }
        public DbSet<Revolutionary.Models.ClassUser> ClassUser { get; set; }*/
        public DbSet<Mark> Mark { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<InviteCode> InviteCode { get; set; }
        #region DummyDbSet
        public DbSet<User> User { get; set; }
        #endregion
    }
}
