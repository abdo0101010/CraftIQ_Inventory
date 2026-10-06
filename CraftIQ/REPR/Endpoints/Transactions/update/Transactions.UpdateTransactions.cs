using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Transactions.update
{
    public class TransactionsRequest
    {
        [FromRoute(Name = "transactionId")]
        public Guid TransactionId { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public int Quantity { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
