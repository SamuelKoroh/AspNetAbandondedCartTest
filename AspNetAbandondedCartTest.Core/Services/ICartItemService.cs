using AspNetAbandondedCartTest.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Core.Services
{
    public interface ICartItemService
    {
        Task<CartItem> AddToCart(CartItem cartItem);
        Task<CartItem> UpdateItemInCart(CartItem cartItemToUpdate, CartItem cartItem);
        Task DeleteItemInCart(CartItem cartItem);
        Task<IEnumerable<CartItem>> GetCartItems(string cartId);
        Task<CartItem> GetCartItem(int cartItemId);
        Task RemoveAllCartItems(IEnumerable<CartItem> cartItems);
    }
}
