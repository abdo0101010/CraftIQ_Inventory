namespace CraftIQ.REPR.Endpoints.Categories.Update
{
    public class UpdateCategoryRequest
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset CreatedOn { get; set; }
        public Guid CreatedBY { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}
