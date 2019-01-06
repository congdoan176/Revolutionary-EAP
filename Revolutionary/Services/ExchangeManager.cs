using Microsoft.EntityFrameworkCore;
using Revolutionary.Areas.Identity.Data.Models;
using Revolutionary.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Services
{
    // this class is used for intercharging between 2 databases
    public class ExchangeManager
    {
        public class AuthenticationToApplication
        {
            // this class will help generate Authentication -> Application: User
            private readonly ApplicationContext _context;
            public AuthenticationToApplication(ApplicationContext context)
            {
                _context = context;
            }
            public async Task Create(User user)
            {
                Revolutionary.Models.User u = Construct(user);
                _context.User.Add(u);
                await _context.SaveChangesAsync();
            }
            public async Task Edit(User user)
            {
                Revolutionary.Models.User u = Construct(user);
                try
                {
                    _context.User.Update(u);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            public async Task Delete(User user)
            {
                Revolutionary.Models.User u = Construct(user);
                _context.User.Remove(u);
                await _context.SaveChangesAsync();
            }
            public Revolutionary.Models.User Construct(User user)
            {
                return new Revolutionary.Models.User()
                {
                    Id = user.Id,
                    Name = user.Name,
                    StudentCode = user.StudentCode,
                    Class = user.Class,
                    Email = user.Email,
                    PhọneNumber = user.PhoneNumber
                };
            }
        }
    }
}

namespace Revolutionary.Models
{
    public class User
    {
        public User()
        {
            this.SetTime();
        }
        private void SetTime()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string StudentCode { get; set; }
        [Required]
        public string PhọneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}