using Microsoft.EntityFrameworkCore;
using CraftIQ.Inventory.Core.Entites;

namespace CraftIQ.Inventory.Infrastructre.Prestistans.Config
{
    internal class InventoryConfigration : IEntityTypeConfiguration<CraftIQ.Inventory.Core.Entites.Inventory>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder< CraftIQ.Inventory.Core.Entites.Inventory> builder)
        {
            builder.Property(i => i.Quantity).IsRequired();
            builder.Property(i => i.ProductId).IsRequired();
            builder.Property(i => i.Name).IsRequired().HasMaxLength(50);
            builder.Property(i => i.Location).IsRequired().HasMaxLength(100);
        }
    }
}
