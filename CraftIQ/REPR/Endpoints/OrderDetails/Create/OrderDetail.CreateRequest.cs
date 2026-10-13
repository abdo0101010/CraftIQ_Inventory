namespace CraftIQ.REPR.Endpoints.OrderDetails.Create
{
    public class OrderDetailRequest
    {
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public decimal TotalPrice { get; set; }

        public OrderDetailRequest(int quantity, Guid productId, Guid orderId, decimal totalPrice)
        {
            Quantity = quantity;
            ProductId = productId;
            OrderId = orderId;
            TotalPrice = totalPrice;
        }
    }
}
