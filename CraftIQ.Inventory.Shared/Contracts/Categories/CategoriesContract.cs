using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Shared.Contracts.Categories
{
    public class CategoriesContract
    {

        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset CreatedOn { get; set; }
        public Guid CreatedBY { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        public CategoriesContract(Guid categoryId,string name, string description, Guid createdBy,Guid modifiedby,DateTimeOffset createdOn,DateTimeOffset modifiedOn)
        { 
            CategoryId = categoryId;
            Name = name;
            Description = description;
            CreatedBY = createdBy;
            CreatedOn = createdOn;
            ModifiedBy = modifiedby;
            ModifiedOn = modifiedOn;

        }
    }
}
