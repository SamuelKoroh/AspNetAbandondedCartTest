using AspNetAbandondedCartTest.Core.Models;
using AspNetAbandondedCartTest.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Data.Repositories
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(DataContext context) : base(context)
        {
        }

        private DataContext DataContext
        {
            get { return Context as DataContext; }
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByCartId(string cartId)
        {
            return await DataContext.CartItems.Where(x => x.CartId == Guid.Parse(cartId)).ToListAsync();
        }
    }
}
