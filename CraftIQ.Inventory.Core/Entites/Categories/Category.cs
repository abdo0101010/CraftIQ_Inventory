using CraftIQ.Inventory.Core.Entites.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites.Categories
{
    public class Category : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;                           
        public string Description { get; set; }=string.Empty;
        public List<Product> Products { get; set; } = new List<Product>();
        public Category(string name, string description)
        {
            CategoryId = Guid.NewGuid();
            Name = name;
            Description = description;
            CreatedBY = Guid.Empty;
            CreatedOn = DateTimeOffset.UtcNow;
            ModifiedBy = Guid.Empty;
            ModifiedOn = DateTimeOffset.UtcNow;

        }
    }
}
