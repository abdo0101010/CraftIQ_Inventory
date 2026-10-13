using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.OrderDetails.Delete
{
    public class OrderDetailRequest
    {
        [FromRoute]
        public Guid OrderDetailId { get; set; }
    }

}
