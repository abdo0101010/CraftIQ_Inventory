namespace CraftIQ.REPR.Endpoints.Products.Update.UpdateParentId
{
    public class UpdateParentIdRequest
    {
        public Guid ProductId { get; set; }
        public Guid ParentId { get; set; }
    }
}
