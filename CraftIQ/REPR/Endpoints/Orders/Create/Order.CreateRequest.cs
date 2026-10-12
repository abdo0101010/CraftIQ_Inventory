namespace CraftIQ.REPR.Endpoints.Orders.Create
{
    public class OrderRquest
    {
        public Guid SupplierId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTimeOffset ExpectedDeliveryDate { get; set; }
        public string OrderType { get; set; } = string.Empty;
        public DateTimeOffset ReceivedDate { get; set; }
        public OrderRquest( Guid supplierid, DateTimeOffset orderdate, decimal totalamount, string status, DateTimeOffset expecteddeliverydate, string ordertype, DateTimeOffset receiveddate)
        {
            SupplierId = supplierid;
            OrderDate = orderdate;
            TotalAmount = totalamount;
            Status = status;
            ExpectedDeliveryDate = expecteddeliverydate;
            OrderType = ordertype;
            ReceivedDate = receiveddate;
        }
    }
}
