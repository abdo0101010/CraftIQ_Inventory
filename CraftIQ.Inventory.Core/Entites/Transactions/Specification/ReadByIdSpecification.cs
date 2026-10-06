using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites.Transactions.Specification
{
    public class ReadByIdSpecification:SingleResultSpecification<Transaction>
    {
        public ReadByIdSpecification(Guid TransactionId)
        {
            Query.Where(c => c.TransactionId == TransactionId);
        }
    }
}
