using EasySetupASPNetCoreAPI.Controllers.V1.Request;
using EasySetupASPNetCoreAPI.Controllers.V1.Response;
using EasySetupASPNetCoreAPI.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EasySetupASPNetCoreAPI.Service
{
    public class AccountServiceRepository : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwt;
        public AccountServiceRepository(UserManager<ApplicationUser> userManager, JwtSettings jwt)
        {
            _userManager = userManager;
            _jwt = jwt;
        }

        public async Task<AuthenticationResult> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Invalid login attempt!" },
                    Success = false
                };
            }
            var hasValidPassword = await _userManager.CheckPasswordAsync(user, password);
            if (!hasValidPassword)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Wrong password or username!" },
                    Success = false
                };
            }
            return GenerateAuthResult(user);
        }

        public async Task<AuthenticationResult> RegisterAsync(string email, string password, string firstName, string lastName,string phone)
        {
            var userExist = await _userManager.FindByEmailAsync(email);
            if(userExist != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Email already exist!" },
                    Success = false
                };
            }
            var user = new ApplicationUser
            {
                FirstName=firstName,
                LastName=lastName,
                Email=email,
                UserName=email,
                PhoneNumber=phone,
            };
            var result = await _userManager.CreateAsync(user,password);
            if (!result.Succeeded)
            {

                return new AuthenticationResult
                {
                    Errors = result.Errors.Select(x => x.Description),
                    Success = false
                };
            }
            return GenerateAuthResult(user);
        }

        private AuthenticationResult GenerateAuthResult(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwt.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email),
                    new Claim("id",user.Id),
                }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthenticationResult
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Success = true,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
