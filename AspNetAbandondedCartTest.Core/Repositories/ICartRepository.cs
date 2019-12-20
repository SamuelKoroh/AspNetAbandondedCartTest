using AspNetAbandondedCartTest.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Core.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<IEnumerable<Cart>> GetWithCustomerOpenCart();
        Task<IEnumerable<Cart>> GetAbandonedCartsByStatus(int status);
        Task<IEnumerable<Customer>> GetWhoRevisitCartAfterNotification();
        Task<IEnumerable<Customer>> GetWhoDeleteCartAfterNotification();
    }
}
