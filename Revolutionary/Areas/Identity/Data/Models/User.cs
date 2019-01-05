using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Revolutionary.Areas.Identity.Data.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public string Class { get; set; }
        [PersonalData]
        public string StudentCode { get; set; }

        public string Ticket { get; set; } // a golden ticket for logging in instantly -> referring to UWP app
        
    }
}
