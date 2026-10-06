namespace CraftIQ.REPR.Endpoints.Transactions.create
{
    public class TransactionRequest
    {
       
        public DateTimeOffset TransactionDate { get; set; }
        public int Quantity { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
