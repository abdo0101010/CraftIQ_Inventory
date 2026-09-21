using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites
{
//    1- Transactionsld
//2- Productld <>
//3- TransactionDate
//4- Quantity
//5- Transaction Type
//6 - Notes
//7- Employeeld<>*
    public class Transaction: BaseEntity
    {
        public Guid TransactionId { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = new Product();
        public DateTimeOffset TransactionDate { get; set; }
        public int Quantity { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public Guid EmployeeId { get; set; }
    }
}
