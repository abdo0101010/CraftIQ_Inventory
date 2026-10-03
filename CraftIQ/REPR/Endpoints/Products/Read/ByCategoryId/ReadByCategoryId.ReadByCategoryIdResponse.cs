using CraftIQ.Inventory.Shared.Contracts.Products;

namespace CraftIQ.REPR.Endpoints.Products.Read.ByCategoryId
{
    public class ReadByCategoryIdResponse
    {
        public Guid ProductId { get; set; }
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
        public ReadByCategoryIdResponse() { }
        public ReadByCategoryIdResponse(ProductContract product)
        {
            ProductId = product.ProductId;
            Name = product.Name;
            Description = product.Description;
            UnitPrice = product.UnitPrice;
            Weight = product.Weight;
            Length = product.Length;
            Width = product.Width;
            Height = product.Height;
            TaxCost = product.TaxCost;
            ProfitPerUnit = product.ProfitPerUnit;
            ProductionCost = product.ProductionCost;
        }
    }
}
