using CraftIQ.Inventory.Core.Entites.Orders;
using CraftIQ.Inventory.Core.Entites.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites.OrderDetails { 
//{1- OrderDetailsld
//2- Orderld <>
//3- Quantity
//4- Productld <>
//5- TotalPrice
    public class OrderDetail : BaseEntity
    {
    public Guid OrderDetailsId { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; } = new Order();
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = new Product();
    public decimal TotalPrice { get; set; }
        public OrderDetail(Guid orderDetailsId, int orderId, int quantity, int productId, decimal totalPrice)
        {
            OrderDetailsId = Guid.NewGuid();
            OrderId = orderId;
            Quantity = quantity;
            ProductId = productId;
            TotalPrice = totalPrice;
        }

    }
}
