using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Orders.Read.ById
{
    public class OrderRequest
    {
        [FromRoute]
      public  Guid OrderId { get; set; }
    }
}
