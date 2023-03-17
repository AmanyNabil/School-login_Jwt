using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagment_API.Models
{
    public class AppUser :IdentityUser
    {
        //public string userName { get; set; }
        //public string pass { get; set; }
        //public List<string> Roles { get; set; }
        public int schoolId { get; set; }
    }
}
