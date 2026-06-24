using System;
using System.Collections.Generic;
using System.Text;
using EcommarceTask.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommarceTask.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
          public void Configure(EntityTypeBuilder<Order> builder) 
          { 
            builder.HasKey(o => o.Id);
            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(o => o.ShippingAdress)
                .WithMany(sa => sa.Order)
                .HasForeignKey(o => o.ShippingAddressId)    
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
                new Order { Id = 1, CustomerId = 1, ShippingAddressId = 1 },
                new Order { Id = 2, CustomerId = 2, ShippingAddressId = 2 }
            );
        }
    }
}
