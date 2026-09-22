namespace CraftIQ.REPR.Endpoints.Categories.Read
{
    public class ReadCategoriesResponse
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset CreatedOn { get; set; }
        public Guid CreatedBY { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        public ReadCategoriesResponse(Guid Category, string name, string description, DateTimeOffset createdOn, Guid createdBy, DateTimeOffset modifiedOn, Guid modifiedBy)
        {
            CategoryId = Category;
            Name = name;
            Description = description;
            CreatedOn = createdOn;
            CreatedBY = createdBy;
            ModifiedOn = modifiedOn;
            ModifiedBy = modifiedBy;
        }
    }
}
