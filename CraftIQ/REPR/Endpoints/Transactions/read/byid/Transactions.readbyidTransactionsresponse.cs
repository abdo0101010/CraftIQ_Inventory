namespace CraftIQ.REPR.Endpoints.Transactions.read.byid
{
    public class TransactionsResponse
    {
        public Guid TransactionId { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public int Quantity { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public Guid EmployeeId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Guid CreatedBY { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        public TransactionsResponse(Guid transactionId, DateTimeOffset transactionDate, int quantity, string transactionType, string notes, Guid employeeId, DateTimeOffset createdOn, Guid createdBY, DateTimeOffset modifiedOn, Guid modifiedBy)
        {
            TransactionId = transactionId;
            TransactionDate = transactionDate;
            Quantity = quantity;
            TransactionType = transactionType;
            Notes = notes;
            EmployeeId = employeeId;
            CreatedOn = createdOn;
            CreatedBY = createdBY;
            ModifiedOn = modifiedOn;
            ModifiedBy = modifiedBy;
        }
    }
}
