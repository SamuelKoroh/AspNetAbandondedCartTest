using AspNetAbandondedCartTest.Core;
using AspNetAbandondedCartTest.Core.Models;
using AspNetAbandondedCartTest.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Service
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Cart>> AbandonedCarts()
        {
            return await _unitOfWork.Carts.GetWithCustomerOpenCart();
        }

        public async Task<IEnumerable<Cart>> AbandonedCartsByStatus(int status)
        {
            return await _unitOfWork.Carts.GetAbandonedCartsByStatus(1);
        }

        public async Task<Cart> CheckIfCustomerIsOpen(string customerId)
        {
            return await _unitOfWork.Carts.SingleOrDefaultAsync(x => x.CustomerId == customerId && x.Status == CartState.Opened);
        }

        public Task DeleteCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        public async Task<Cart> GenerateNewCart(string customerId)
        {
            var cart = new Cart
            {
                CustomerId = customerId,
                Date = DateTime.Now,
                Status = CartState.Opened
            };

            await _unitOfWork.Carts.AddAsync(cart);
            await _unitOfWork.CommitAsync();

            return cart;
        }

        public Task<Cart> UpdateCartStatus(Cart cart, int status)
        {
            throw new NotImplementedException();
        }
    }
}
