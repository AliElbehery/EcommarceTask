using System;
using System.Collections.Generic;
using System.Text;
using EcommarceTask.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommarceTask.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
                new Product { Id = 1, Name = "Smartphone", Price = 699.99m, CategoryId = 1 },
                new Product { Id = 2, Name = "Laptop", Price = 999.99m, CategoryId = 1 },
                new Product { Id = 3, Name = "T-Shirt", Price = 19.99m, CategoryId = 2 },
                new Product { Id = 4, Name = "Jeans", Price = 49.99m, CategoryId = 2 },
                new Product { Id = 5, Name = "Novel", Price = 14.99m, CategoryId = 3 },
                new Product { Id = 6, Name = "Biography", Price = 24.99m, CategoryId = 3 }
            );
        }
    }
}
