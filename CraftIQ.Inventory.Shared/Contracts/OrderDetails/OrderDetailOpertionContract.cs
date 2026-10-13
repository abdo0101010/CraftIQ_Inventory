using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Shared.Contracts.OrderDetails
{
    public class OrderDetailOpertionContract
    {
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public decimal TotalPrice { get; set; }

        public OrderDetailOpertionContract(int quantity, Guid productId, Guid orderId, decimal totalPrice)
        {
            Quantity = quantity;
            ProductId = productId;
            OrderId = orderId;
            TotalPrice = totalPrice;
        }
    }
}
