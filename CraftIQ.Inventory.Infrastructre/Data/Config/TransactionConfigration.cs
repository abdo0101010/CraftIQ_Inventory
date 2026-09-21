using CraftIQ.Inventory.Core.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Infrastructre.Prestistans.Config
{
    internal class TransactionConfigration:IEntityTypeConfiguration<Transaction>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(t => t.TransactionId).IsRequired();
            builder.Property(t => t.ProductId).IsRequired();
            builder.Property(t => t.Quantity).IsRequired();
            builder.Property(t => t.TransactionDate).IsRequired();
            builder.Property(t => t.TransactionType).IsRequired().HasMaxLength(20);
        }
    }
}
