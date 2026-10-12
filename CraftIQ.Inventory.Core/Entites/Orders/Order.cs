
using CraftIQ.Inventory.Core.Entites.OrderDetails;


namespace CraftIQ.Inventory.Core.Entites.Orders { 
//{1- Orderld
//2- Supplierld <>*
//3- OrderDate
//4- TotalAmount
//5- Status
//6- ExpectedDeliveryDate
//7. OrderType
//8- ReceivedDate
    public class Order : BaseEntity
    {
    public Guid OrderId { get; set; }
    public Guid SupplierId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTimeOffset ExpectedDeliveryDate { get; set; }
        public string OrderType { get; set; } = string.Empty;
    public DateTimeOffset ReceivedDate { get; set; }

        public Order(Guid orderid, Guid supplierid, DateTimeOffset orderdate, decimal totalamount, string status, DateTimeOffset expecteddeliverydate, string ordertype, DateTimeOffset receiveddate)
        {
            OrderId = Guid.NewGuid();
            SupplierId = supplierid;
            OrderDate = orderdate;
            TotalAmount = totalamount;
            Status = status;
            ExpectedDeliveryDate = expecteddeliverydate;
            OrderType = ordertype;
            ReceivedDate = receiveddate;
        }
        public Order()
        {
            
        }
        public List<OrderDetail> OrderDetails { get; set; } = new();

        public void UpdateOrder(Guid supplierid, DateTimeOffset orderdate, decimal totalamount, string status, DateTimeOffset expecteddeliverydate, string ordertype, DateTimeOffset receiveddate)
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
