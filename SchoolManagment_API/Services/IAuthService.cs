using SchoolManagment_API.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagment_API.Services
{
    public interface IAuthService
    {
        Task<AppUser> GetUser(string userName);
        Task<AuthModel> Login(LoginModel login);
        Task<string> GetTokenAsync(string userName);
        Task<JwtSecurityToken> CreateJwtToken(AppUser user);
    }
}
