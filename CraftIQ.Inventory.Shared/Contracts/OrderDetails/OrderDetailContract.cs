using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Shared.Contracts.OrderDetails
{
    public class OrderDetailContract: OrderDetailOpertionContract
    {
        public Guid OrderDetailsId { get; set; }
        public OrderDetailContract(Guid orderDetailsId, int quantity, Guid productId, Guid orderId, decimal totalPrice)
            : base(quantity, productId, orderId, totalPrice)
        {
            OrderDetailsId = orderDetailsId;
        }
    }
}
