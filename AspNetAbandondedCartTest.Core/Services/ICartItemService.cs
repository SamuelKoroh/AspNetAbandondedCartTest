using AspNetAbandondedCartTest.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Core.Services
{
    public interface ICartItemService
    {
        Task<CartItem> AddToCart(Cart cart);
        Task<CartItem> UpdateItemInCart(Cart cartToUpdate, Cart cart);
        Task DeleteItemInCart(Cart cartToUpdate, Cart cart);
        Task<IEnumerable<CartItem>> GetCartItems(string cartId);
        Task<IEnumerable<CartItem>> GetCartItem(int cartItemId);
        Task RemoveAllCartItems(IEnumerable<CartItem> cartItems);
    }
}
