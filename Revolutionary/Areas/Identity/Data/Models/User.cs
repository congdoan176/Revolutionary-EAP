using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Revolutionary.Models;

namespace Revolutionary.Areas.Identity.Data.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser<int>
    {
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public string Class { get; set; }
        [PersonalData]
        public string StudentCode { get; set; }
    }
}
