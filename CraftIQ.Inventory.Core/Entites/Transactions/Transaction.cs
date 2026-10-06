using CraftIQ.Inventory.Core.Entites.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites.Transactions
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
        public int ProductId { get; set; }
        public List<Product> Product { get; set; } = new();
        public DateTimeOffset TransactionDate { get; set; }
        public int Quantity { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public Guid EmployeeId { get; set; }
        public Transaction(Guid id, DateTimeOffset transactionDate, int quantity, string transactionType, string notes, Guid employeeId)
        {
            TransactionId = id == Guid.Empty ? Guid.NewGuid() : id;
            TransactionDate = transactionDate;
            Quantity = quantity;
            TransactionType = transactionType;
            Notes = notes;
            EmployeeId = employeeId;
            CreatedBY = new();
            CreatedOn = DateTimeOffset.Now;
            ModifiedBy = new();
            ModifiedOn = DateTimeOffset.Now;
        }
        public Transaction()
        {
            
        }

        public void UpdateTransaction(DateTimeOffset transactionDate, int quantity, string transactionType, string notes, Guid employeeId, Guid empty)
        {
            TransactionDate = transactionDate;
            Quantity = quantity;
            TransactionType = transactionType;
            Notes = notes;
            EmployeeId = employeeId;
            ModifiedBy = empty;
            ModifiedOn = DateTimeOffset.Now;

        }
    }
}
