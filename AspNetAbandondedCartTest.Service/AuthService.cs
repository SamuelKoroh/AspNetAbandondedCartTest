using AspNetAbandondedCartTest.Core.Models;
using AspNetAbandondedCartTest.Core.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Service
{
    public class AuthService : IAuthService
    {
        public AuthService(UserManager<Customer> userManager)
        {

        }
        public Task<string> GetUserToken(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> RegisterAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
