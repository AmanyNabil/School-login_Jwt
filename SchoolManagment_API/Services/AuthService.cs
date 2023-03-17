using SchoolManagment_API.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagment_API.Models;
using Microsoft.AspNetCore.Identity;
using SchoolManagment_API.Helper;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace SchoolManagment_API.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        public AuthService( UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
        }

        public async Task<AppUser> GetUser(string  userName)
        {
            var result = await _userManager.FindByNameAsync(userName);
            if (result is null)
                throw new NotImplementedException("User Not Exist" );
            
            return result;
        }


        public async Task<AuthModel> Login(LoginModel model)
        {
            // var user = await GetUser(model.userName);
            var user = await _userManager.FindByNameAsync(model.userName);
    
            if (user is null || !await _userManager.CheckPasswordAsync(user, model.password))
            {
                throw new NotImplementedException("UserName or Password is incorrect!");
            }

            var jwtSecurityToken = await CreateJwtToken( user);
            var rolesList = await _userManager.GetRolesAsync( user);

            var authModel = new AuthModel();
            authModel.Username = user.UserName;
            authModel.Roles = (List<string>)await _userManager.GetRolesAsync(user);
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.schoolId = user.schoolId;
            return authModel;
            
        }

        public async Task<string> GetTokenAsync(string userName)
        {
            
            var user = await _userManager.FindByNameAsync(userName);

            if (user is null )
            {
                throw new NotImplementedException("UserName or Password is incorrect!");
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            

            
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }


        public async Task<JwtSecurityToken> CreateJwtToken(AppUser user)
        {
            var userClaims = new List<Claim>(); 
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim("roles", role));
                
            }
            userClaims.Add(new Claim("schoolId",user.schoolId.ToString()));
            var claims = userClaims.Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

    }
}
