using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Transactions.read.byid
{
    public class TransactionsRequest
    {
        [FromRoute(Name = "TransactionId")]
        public Guid TransactionId { get; set; }
        
    }
}
