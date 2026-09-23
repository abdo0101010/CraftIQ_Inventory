namespace CraftIQ.Inventory.Shared.Contracts.Products
{
    public class ProductOperationContract
    {
        public Guid ProductId { get; set; }
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
        public ProductOperationContract(Guid productid,string name, string description, decimal unitPrice, decimal weight, decimal length, decimal width, decimal height, Guid categoryId, decimal taxCost, decimal profitPerUnit, decimal productionCost)
        {
            ProductId = productid;
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            Weight = weight;
            Length = length;
            Width = width;
            Height = height;
            CategoryId = categoryId;
            TaxCost = taxCost;
            ProfitPerUnit = profitPerUnit;
            ProductionCost = productionCost;
           
        }
    }
}
