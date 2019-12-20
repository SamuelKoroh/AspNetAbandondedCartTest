using AspNetAbandondedCartTest.Core.Models;
using AspNetAbandondedCartTest.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Data.Repositories
{
    public class CartRepository : Repository<Cart>,ICartRepository
    {
        public CartRepository(DataContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Cart>> GetWithCustomerOpenCart()
        {
            return await DataContext.Carts.Include(x => x.Customer)
                .Where(x => x.Status == CartState.Opened).ToListAsync();
        }

        public Task<IEnumerable<Cart>> GetAbandonedCartsByStatus(int status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetWhoDeleteCartAfterNotification()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetWhoRevisitCartAfterNotification()
        {
            throw new NotImplementedException();
        }

        private DataContext DataContext
        {
            get { return Context as DataContext; }
        }

        
    }
}
