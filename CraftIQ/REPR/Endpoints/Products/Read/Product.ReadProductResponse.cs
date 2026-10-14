using CraftIQ.Inventory.Core.Entites;
using CraftIQ.Inventory.Core.Entites.Categories;
using CraftIQ.Inventory.Shared.Contracts.Categories;
using CraftIQ.Inventory.Shared.Contracts.Products;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CraftIQ.REPR.Endpoints.Products.Read
{
    public class ReadProductResponse
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public Guid CategoryId { get; set; }
        public decimal TaxCost { get; set; }
        public decimal ProfitPerUnit { get; set; }
        public decimal ProductionCost { get; set; }
        public ReadProductResponse() { }
        public ReadProductResponse(ProductContract product)
        {
            ProductId =   product.ProductId;
            Name =        product.Name;
            Description=  product.Description;
            UnitPrice  =  product.UnitPrice;
            Weight =      product.Weight;
            Length =      product.Length;
            Width =       product.Width;
            Height =      product.Height;
            TaxCost =     product.TaxCost;
            ProfitPerUnit=product.ProfitPerUnit;
           ProductionCost=product.ProductionCost;
        }
    }
}
