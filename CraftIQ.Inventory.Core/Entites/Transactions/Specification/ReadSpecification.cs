using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites.Transactions.Specification
{
    public  class ReadSpecification : Specification<Transaction>
    {
        public ReadSpecification()
        {
            Query.Where(p => p.Id != 0);
        }
    }
}
