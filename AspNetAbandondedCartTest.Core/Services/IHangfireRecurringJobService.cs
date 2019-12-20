using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Core.Services
{
    public interface IHangfireRecurringJobService
    {
        Task CheckForAbandonedCart();
    }
}
