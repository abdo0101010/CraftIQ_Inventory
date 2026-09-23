using CraftIQ.Inventory.Core.Entites.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites { 
//{1- OrderDetailsld
//2- Orderld <>
//3- Quantity
//4- Productld <>
//5- TotalPrice
    public class OrderDetails : BaseEntity
    {
    public Guid OrderDetailsId { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = new Order();
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = new Product();
    public decimal TotalPrice { get; set; }

}
}
