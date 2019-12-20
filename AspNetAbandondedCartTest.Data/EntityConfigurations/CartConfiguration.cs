using AspNetAbandondedCartTest.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetAbandondedCartTest.Data.EntityConfigurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status)
                .HasColumnType("int").IsRequired();

            builder.Property(x => x.Date).HasColumnType("DateTime").IsRequired();

            builder.HasOne(x => x.Customer).WithMany(x => x.Cart).HasForeignKey(x => x.CustomerId);
        }
    }
}
