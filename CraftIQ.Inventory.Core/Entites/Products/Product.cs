using CraftIQ.Inventory.Core.Entites.Categories;
using CraftIQ.Inventory.Core.Entites.Transactions;
using CraftIQ.Inventory.Shared.Contracts.Products;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites.Products
{

    public class Product:BaseEntity
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } 
        public decimal TaxCost { get; set; }
        public decimal ProfitPerUnit { get; set; }
        public decimal ProductionCost { get; set; }
        public int InventoryId { get; set; }
        public Inventories.Inventory Inventory { get; set; } = new();
        public int ?TransactionId { get; set; }
        public Transaction Transaction { get; set; } = new Transaction();
        public List<OrderDetails> OrderDetails { get; set; } = new();

        public Product(Guid id,
                       string name ,
                       string description,
                       decimal unitprice,
                       decimal weight, 
                       decimal length,
                       decimal width , 
                       decimal height, 
                       Guid categoryid,
                       decimal taxcost,
                       decimal profitperUnit,
                       decimal productioncost)
        {
            ProductId = id == Guid.Empty ? Guid.NewGuid() : id;
            Name = name;
            Description = description;
            UnitPrice = unitprice;
            Weight = weight;
            Length = length;
            Width = width;
            Height = height;
            TaxCost = taxcost;
            ProfitPerUnit = profitperUnit;
            ProductionCost = productioncost;
            CreatedBY = new();
            CreatedOn = DateTimeOffset.Now;
            ModifiedBy = new();
            ModifiedOn = DateTimeOffset.Now;

        }
        public Product()
        {
            
        }
        public void SetCategory(Category category) =>
           Category = category;
        public void SetInventory(Inventories.Inventory inventory) =>
          Inventory = inventory;
        public void UpdateProduct(ProductOperationContract product)
        {

            ModifiedOn = DateTimeOffset.Now;
            Name = string.IsNullOrEmpty(product.Name) ? this.Name : product.Name;
            Description = string.IsNullOrEmpty(product.Description) ? this.Description : product.Description;
            UnitPrice = product.UnitPrice == 0 ? this.UnitPrice : product.UnitPrice;
            Weight = product.Weight == 0 ? this.Weight : product.Weight;
            Length = product.Length == 0 ? this.Length : product.Length;
            Width = product.Width == 0 ? this.Width : product.Width;
            Height = product.Height == 0 ? this.Height : product.Height;
            TaxCost = product.TaxCost == 0 ? this.TaxCost : product.TaxCost;
            ProfitPerUnit = product.ProfitPerUnit == 0 ? this.ProfitPerUnit : product.ProfitPerUnit;
            ProductionCost = product.ProductionCost == 0 ? this.ProductionCost : product.ProductionCost;

        }
    }
}
