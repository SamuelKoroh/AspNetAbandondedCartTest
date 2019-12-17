using AspNetAbandondedCartTest.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Core.Services
{
    public interface IAuthService
    {
        Task<Customer> RegisterAsync(Customer customer);
        Task<Customer> LoginAsync(string email, string password);
        Task<string> GetUserToken(Customer customer);
    }
}
