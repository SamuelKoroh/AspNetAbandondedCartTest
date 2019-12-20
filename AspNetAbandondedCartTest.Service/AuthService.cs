using AspNetAbandondedCartTest.Configuration;
using AspNetAbandondedCartTest.Core.Models;
using AspNetAbandondedCartTest.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Customer> _userManager;
        private readonly IOptions<JwtSetting> _jwtSetting;

        public AuthService(UserManager<Customer> userManager, IOptions<JwtSetting> jwtSetting)
        {
            _userManager = userManager;
            _jwtSetting = jwtSetting;
        }
        public string GetUserToken(Customer customer)
        {
            var key = Encoding.ASCII.GetBytes(_jwtSetting.Value.SecretKey);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, customer.Id),
                    new Claim(ClaimTypes.Name, string.Concat(customer.FirstName, " ", customer.LastName)),
                    new Claim(ClaimTypes.Email, customer.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<Customer> FindCustomerByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> RegisterAsync(Customer customer, string password)
        {
            return await _userManager.CreateAsync(customer, password);
        }

        public async Task<bool> VerifyCustomerPasswordAsync(Customer customer, string password)
        {
            return await _userManager.CheckPasswordAsync(customer, password);
        }

        public async Task UpdateLastLoginDate(Customer customer)
        {
            customer.LastLoginDate = DateTime.Now;

            await _userManager.UpdateAsync(customer);
        }
    }
}
