using System;
using System.Collections.Generic;
using System.Text;
using EcommarceTask.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommarceTask.Configurations
{
    public class ShippingAddressConfiguration : IEntityTypeConfiguration<ShippingAdress>
    {
        public void Configure(EntityTypeBuilder<ShippingAdress> builder)
        {
            builder.ToTable("ShippingAddresses");
            builder.HasKey(sa => sa.Id);
            builder.HasData(
                new ShippingAdress
                {
                    Id = 1,
                    Street = "123 Main St",
                    City = "New York",
                   
                },
                new ShippingAdress
                {
                    Id = 2,
                    Street = "456 Elm St",
                    City = "Los Angeles",
                    
                }
            );
            
        }
    }
}
