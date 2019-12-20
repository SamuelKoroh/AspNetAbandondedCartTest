using AspNetAbandondedCartTest.Core;
using AspNetAbandondedCartTest.Core.Models;
using AspNetAbandondedCartTest.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Service
{
    public class CartItemService : ICartItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CartItem> AddToCart(CartItem cartItem)
        {
            await _unitOfWork.CartItems.AddAsync(cartItem);
            await _unitOfWork.CommitAsync();
            return cartItem;
        }

        public async Task DeleteItemInCart( CartItem cartItem)
        {
            _unitOfWork.CartItems.RemoveAsync(cartItem);
            await _unitOfWork.CommitAsync();
        }

        public async  Task<CartItem> GetCartItem(int cartItemId)
        {
            return await _unitOfWork.CartItems.SingleOrDefaultAsync(x => x.Id == cartItemId);
        }

        public async Task<IEnumerable<CartItem>> GetCartItems(string cartId)
        {
            return await _unitOfWork.CartItems.GetCartItemsByCartId(cartId);
        }

        public async Task RemoveAllCartItems(IEnumerable<CartItem> cartItems)
        {
            _unitOfWork.CartItems.RemoveRangeAsync(cartItems);
            await _unitOfWork.CommitAsync();
        }

        public async Task<CartItem> UpdateItemInCart(CartItem cartItemToUpdate, CartItem cartItem)
        {
            cartItemToUpdate.Quantity = cartItem.Quantity;
            await _unitOfWork.CommitAsync();
            return cartItemToUpdate;
        }
    }
}
