using AspNetAbandondedCartTest.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Core.Services
{
    public interface ICartService
    {
        Task<Cart> GenerateNewCart(string customerId);
        Task<Cart> CheckIfCustomerIsOpen(string customerId);
        Task<Cart> UpdateCartStatus(Cart cart, int status);
        Task DeleteCart(Cart cart);
        Task<IEnumerable<Cart>> AbandonedCarts();
        Task<IEnumerable<Cart>> AbandonedCartsByStatus(int status);
    }
}
