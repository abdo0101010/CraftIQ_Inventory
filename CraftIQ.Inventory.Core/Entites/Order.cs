using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites { 
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

    }
    
}
