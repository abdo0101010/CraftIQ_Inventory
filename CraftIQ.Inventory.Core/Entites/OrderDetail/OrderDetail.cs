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
        public OrderDetail(Guid orderDetailsId, int quantity, decimal totalPrice)
        {
            OrderDetailsId = Guid.NewGuid();
            Quantity = quantity;
        
            TotalPrice = totalPrice;
        }
        public OrderDetail()
        {
            
        }
        public void SetProduct(Product product) => Product = product;
        public void SetOrder(Order order) => Order = order;


    }
}
