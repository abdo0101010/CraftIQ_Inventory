using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Shared.Contracts.Transactions
{
    public class TransactionOperationContract
    {
        public Guid TransactionId { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public int Quantity { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public Guid EmployeeId { get; set; }
        public TransactionOperationContract(Guid transactionId, DateTimeOffset transactionDate, int quantity, string transactionType, string notes, Guid employeeId)
        {
            TransactionId = transactionId;
            TransactionDate = transactionDate;
            Quantity = quantity;
            TransactionType = transactionType;
            Notes = notes;
            EmployeeId = employeeId;
        }
    }
}
