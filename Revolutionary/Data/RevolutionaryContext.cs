using Microsoft.EntityFrameworkCore;
using Revolutionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Data
{
    public class RevolutionaryContext:DbContext
    {
        public DbSet<Revolutionary.Models.Account> Accounts { get; set; }
        public DbSet<Revolutionary.Models.AccountClazz> AccountClazzs { get; set; }
        public DbSet<Revolutionary.Models.Clazz> Clazzs { get; set; }
        public DbSet<Revolutionary.Models.AccountRole> AccountRoles { get; set; }
        public DbSet<Revolutionary.Models.Role> Roles { get; set; }
        public DbSet<Revolutionary.Models.Mark> Marks { get; set; }
        public DbSet<Revolutionary.Models.Subject> Subjects { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RevolutionaryContext-9d9d6375-8ec6-4226-9205-e6eae8ee9a69;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountClazz>().HasKey(ac => new { ac.AccountId, ac.ClazzId });
            modelBuilder.Entity<AccountRole>().HasKey(ar => new { ar.AccountId, ar.RoleId });
            modelBuilder.Entity<Mark>().HasKey(m => new { m.AccountId, m.SubjectId });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Revolutionary.Models.Teacher> Teacher { get; set; }
    }
}
