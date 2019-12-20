using AspNetAbandondedCartTest.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Core
{
    public interface IUnitOfWork : IDisposable
    {
        public ICartRepository Carts { get; }
        public ICartItemRepository CartItems { get; }
        Task<int> CommitAsync();
    }
}
