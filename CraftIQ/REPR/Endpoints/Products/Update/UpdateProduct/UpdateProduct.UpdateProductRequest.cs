using CraftIQ.Inventory.Shared.Contracts.Products;

namespace CraftIQ.REPR.Endpoints.Products.Update.UpdateProduct
{
    public class UpdateProductRequest
    {
        public Guid ProductId { get; set; }
        public Guid InventoryId { get; set; }
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

       
    }
}
