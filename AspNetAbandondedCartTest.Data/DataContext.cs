using AspNetAbandondedCartTest.Core.Models;
using AspNetAbandondedCartTest.Data.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetAbandondedCartTest.Data
{
    public class DataContext : IdentityDbContext<Customer>
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
