using AspNetAbandondedCartTest.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetAbandondedCartTest.Data.EntityConfigurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItems");

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Quantity).IsRequired();

            builder.HasOne(x => x.Cart).WithMany(x => x.CartItems)
                .HasForeignKey(x => x.CartId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product).WithMany(x => x.CartItems)
                .HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
