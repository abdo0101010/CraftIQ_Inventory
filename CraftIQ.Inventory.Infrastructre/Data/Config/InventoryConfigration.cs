using Microsoft.EntityFrameworkCore;

namespace CraftIQ.Inventory.Infrastructre.Prestistans.Config
{
    internal class InventoryConfigration : IEntityTypeConfiguration<Core.Entites.Inventories.Inventory>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder< Core.Entites.Inventories.Inventory> builder)
        {
            builder.Property(i => i.Quantity).IsRequired();
            builder.Property(i => i.ProductId).IsRequired();
            builder.Property(i => i.Name).IsRequired().HasMaxLength(50);
            builder.Property(i => i.Location).IsRequired().HasMaxLength(100);
        }
    }
}
