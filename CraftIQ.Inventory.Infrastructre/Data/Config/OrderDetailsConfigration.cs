using CraftIQ.Inventory.Core.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Infrastructre.Prestistans.Config
{
    internal class OrderDetailsConfigration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OrderDetails> builder)
        {
            builder.Property(od => od.OrderDetailsId).IsRequired();
            builder.Property(od => od.OrderId).IsRequired();
            builder.Property(od => od.Quantity).IsRequired();
            builder.Property(od => od.ProductId).IsRequired();
            builder.Property(od => od.TotalPrice).IsRequired();
        }
    }
}
