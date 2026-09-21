using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Guid CreatedBY { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }
    }

}
