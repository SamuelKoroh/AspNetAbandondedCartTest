using AspNetAbandondedCartTest.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Service
{
    public class HangfireRecurringJobService : IHangfireRecurringJobService
    {
        private readonly IEmailService _emailService;

        public HangfireRecurringJobService(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public async Task CheckForAbandonedCart()
        {
            await _emailService.SendEmailAsync("samuelkoroh@gmail.com", "HangFire", "Testing hangfire");
        }
    }
}
