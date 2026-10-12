using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Shared.Contracts.Orders
{
    public class OrderOpertionContract
    {
        public Guid OrderId { get; set; }
        public Guid SupplierId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTimeOffset ExpectedDeliveryDate { get; set; }
        public string OrderType { get; set; } = string.Empty;
        public DateTimeOffset ReceivedDate { get; set; }
        public OrderOpertionContract(Guid orderid, Guid supplierid, DateTimeOffset orderdate, decimal totalamount, string status, DateTimeOffset expecteddeliverydate, string ordertype, DateTimeOffset receiveddate)
        {
            OrderId = orderid;
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
