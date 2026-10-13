namespace CraftIQ.REPR.Endpoints.OrderDetails.Read
{
    public class OrderDetailResponse
    {
        public Guid OrderDetailsId { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public decimal TotalPrice { get; set; }

        public OrderDetailResponse(Guid orderdetailsid,int quantity, Guid productId, Guid orderId, decimal totalPrice)
        {
            OrderDetailsId = orderdetailsid;
            Quantity = quantity;
            ProductId = productId;
            OrderId = orderId;
            TotalPrice = totalPrice;
        }
    }
}
