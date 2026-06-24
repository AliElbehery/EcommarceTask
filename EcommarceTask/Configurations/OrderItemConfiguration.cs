using System;
using System.Collections.Generic;
using System.Text;
using EcommarceTask.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommarceTask.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasKey(oi => oi.Id);
           
            builder.Property(oi => oi.Quantity)
                .IsRequired();
            builder.HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
                new OrderItem { Id = 1, ProductId = 1, Quantity = 2 },
                new OrderItem { Id = 2, ProductId = 2, Quantity = 1 },
                new OrderItem { Id = 3, ProductId = 3, Quantity = 3 }
            );
        }
    }
}
