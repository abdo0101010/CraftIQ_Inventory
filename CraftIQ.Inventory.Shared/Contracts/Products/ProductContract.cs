using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Shared.Contracts.Products
{
    internal class ProductContract:ProductOperationContract
    {
        public DateTimeOffset CreatedOn { get; set; }
        public Guid CreatedBY { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }

        public ProductContract(Guid productid, string name, string description, decimal unitPrice, decimal weight, decimal length, decimal width, decimal height, Guid categoryId, decimal taxCost, decimal profitPerUnit, decimal productionCost)
           : base(productid, name, description, unitPrice, weight, length, width, height, categoryId, taxCost, profitPerUnit, productionCost)
        { }
        public ProductContract(Guid productid, string name, string description, decimal unitPrice, decimal weight, decimal length, decimal width, decimal height, Guid categoryId, decimal taxCost, decimal profitPerUnit, decimal productionCost, Guid createdBY, Guid modifiedBy,DateTimeOffset modifiedOn,Guid modifiedby, Guid createdby , DateTimeOffset modifiedon)
            : base(productid, name, description, unitPrice, weight, length, width, height, categoryId, taxCost, profitPerUnit, productionCost)
        {
            ModifiedOn = modifiedOn;
            ModifiedBy = modifiedby;
            CreatedBY = createdby;
            CreatedOn = modifiedon;

        }
    }
}
