using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.OrderDetails.Update
{
    public class OrderDetailRequest
    {
       
        public Guid OrderDetailsId { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public decimal TotalPrice { get; set; }

        public OrderDetailRequest(Guid orderdetailsid, int quantity, Guid productId, Guid orderId, decimal totalPrice)
        {
            OrderDetailsId = orderdetailsid;
            Quantity = quantity;
            ProductId = productId;
            OrderId = orderId;
            TotalPrice = totalPrice;
        }
        public OrderDetailRequest()
        {
            
        }
    }
}
