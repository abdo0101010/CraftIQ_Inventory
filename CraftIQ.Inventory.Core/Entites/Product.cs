using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites
{
//    1- Productld
//2- Name
//3- Description
//4- UnitPrice
//5- Weight
//6-Length
//7- Width
//8- Height
//9- Categoryld <>
//10 - TaxCost
//11- ProfitPerUnit
//12- ProductionCost
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
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } 
        public decimal TaxCost { get; set; }
        public decimal ProfitPerUnit { get; set; }
        public decimal ProductionCost { get; set; }
    }
}
