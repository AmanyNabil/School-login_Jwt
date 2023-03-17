using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolManagment_API.Models
{
    public class AuthModel
    {
        public string Username { get; set; }
        
        public List<string> Roles { get; set; }
        public List<Claim> Claims { get; set; }
        public string Token { get; set; }
        public int schoolId { get; set; }
       
    }
}
