using CraftIQ.Inventory.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Infrastructre.Prestistans.Config
{
    internal class OrderConfigration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
           builder.Property(o => o.OrderId).IsRequired();
            builder.Property(o => o.SupplierId).IsRequired();
            builder.Property(o => o.OrderDate).IsRequired();
            builder.Property(o => o.TotalAmount).IsRequired();
            builder.Property(o => o.Status).IsRequired().HasMaxLength(30);
            builder.Property(o => o.ExpectedDeliveryDate).IsRequired();
            builder.Property(o => o.OrderType).IsRequired().HasMaxLength(20);
            builder.Property(o => o.ReceivedDate).IsRequired();
        }
    }
}
