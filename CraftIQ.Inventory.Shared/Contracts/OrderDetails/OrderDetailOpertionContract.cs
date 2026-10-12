using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Shared.Contracts.OrderDetails
{
    public class OrderDetailOpertionContract
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }

        public OrderDetailOpertionContract(int quantity, int productId, int orderId, decimal totalPrice)
        {
            Quantity = quantity;
            ProductId = productId;
            OrderId = orderId;
            TotalPrice = totalPrice;
        }
    }
}
