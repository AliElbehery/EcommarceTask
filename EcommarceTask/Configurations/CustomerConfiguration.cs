using System;
using System.Collections.Generic;
using System.Text;
using EcommarceTask.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommarceTask.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(255);
            builder.HasData(
                new Customer
                {
                    Id = 1,
                    Name = "John Doe",
                    Email = "john.doe@example.com"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Email = "Jana.Smith@example.com"
                }  
              
            );
        }
    }
}
