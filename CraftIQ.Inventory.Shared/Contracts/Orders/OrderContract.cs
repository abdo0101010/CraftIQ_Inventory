using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Shared.Contracts.Orders
{
    public class OrderContract:OrderOpertionContract
    {

        public OrderContract(Guid orderid, Guid supplierid, DateTimeOffset orderdate, decimal totalamount, string status, DateTimeOffset expecteddeliverydate, string ordertype, DateTimeOffset receiveddate)
            : base(orderid, supplierid, orderdate, totalamount, status, expecteddeliverydate, ordertype, receiveddate)
        {
        }
    }
}
