using AspNetAbandondedCartTest.Core;
using AspNetAbandondedCartTest.Core.Repositories;
using AspNetAbandondedCartTest.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private ICartItemRepository _cartItems;
        private ICartRepository _cart;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public ICartRepository Carts => _cart ??= new CartRepository(_context);

        public ICartItemRepository CartItems => _cartItems ??= new CartItemRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
