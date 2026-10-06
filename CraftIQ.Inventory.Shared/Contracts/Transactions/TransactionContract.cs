using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Shared.Contracts.Transactions
{
    public  class TransactionContract: TransactionOperationContract
    {
        public DateTimeOffset CreatedOn { get; set; }
        public Guid CreatedBY { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        public TransactionContract(Guid transactionId, DateTimeOffset transactionDate, int quantity, string transactionType, string notes, Guid employeeId)
            : base(transactionId, transactionDate, quantity, transactionType, notes, employeeId)
        { }
        public TransactionContract(Guid transactionId, DateTimeOffset transactionDate, int quantity, string transactionType, string notes, Guid employeeId,
            Guid createdBY, Guid modifiedBy, DateTimeOffset modifiedOn,DateTimeOffset createdOn)
            : base(transactionId, transactionDate, quantity, transactionType, notes, employeeId)
        {
            CreatedBY = createdBY;
            ModifiedBy = modifiedBy;
            ModifiedOn = modifiedOn;
            CreatedOn = createdOn;
        }

    }
}
