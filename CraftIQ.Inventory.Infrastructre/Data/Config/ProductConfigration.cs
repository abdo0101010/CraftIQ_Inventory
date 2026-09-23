using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CraftIQ.Inventory.Core.Entites.Products;
namespace CraftIQ.Inventory.Infrastructre.Prestistans.Config
{
    internal class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.Property(p=> p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
            builder.Property(p => p.UnitPrice).IsRequired();
            builder.Property(p => p.Weight).IsRequired();
            builder.Property(p => p.Length).IsRequired();
            builder.Property(p => p.Width).IsRequired();
            builder.Property(p => p.Height).IsRequired();
            builder.Property(p => p.CategoryId).IsRequired();
        }
    }
}
