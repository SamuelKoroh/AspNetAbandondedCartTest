using AspNetAbandondedCartTest.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Core.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(Customer customer, string password);
        Task<Customer> FindCustomerByEmailAsync(string email);
        Task<bool> VerifyCustomerPasswordAsync(Customer customer, string password);

        Task UpdateLastLoginDate(Customer customer);
        string GetUserToken(Customer customer);
    }
}
