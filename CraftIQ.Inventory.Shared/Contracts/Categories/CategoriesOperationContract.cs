using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Shared.Contracts.Categories
{
    public class CategoriesOperationContract
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public CategoriesOperationContract( string name, string description)
        {
            Name = name;
            Description = description;


        }
    }
}
