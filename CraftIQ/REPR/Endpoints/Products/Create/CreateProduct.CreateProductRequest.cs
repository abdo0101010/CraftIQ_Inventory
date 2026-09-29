using CraftIQ.Inventory.Core.Entites;
using CraftIQ.Inventory.Shared.Contracts.Products;

namespace CraftIQ.REPR.Endpoints.Products.Create
{
    public class CreateProductRequest
    {
        
        public Guid CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal TaxCost { get; set; }
        public decimal ProfitPerUnit { get; set; }
        public decimal ProductionCost { get; set; }
        public CreateProductRequest(Guid categoryId,
                                     
                                     string name,
                                     string description,
                                     decimal unitPrice,
                                    decimal weight,
                                    decimal length,
                                    decimal width,
                                    decimal height,
                                     decimal taxCost,
                                     decimal profitPerUnit,
                                     decimal productionCost)
        {
            CategoryId = categoryId;
        
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            Weight = weight;
            Length = length;
            Width = width;
            Height = height;
            TaxCost = taxCost;
            ProfitPerUnit = profitPerUnit;
            ProductionCost = productionCost;
        }
    }
}
