namespace CraftIQ.REPR.Endpoints.Categories.Update
{
    public class UpdateCategoryResponse
    {
        private Guid categoryId;
        private string name;
        private string description;
        private DateTimeOffset createdOn;
        private Guid createdBY;
        private DateTimeOffset modifiedOn;
        private Guid modifiedBy;

        public UpdateCategoryResponse(Guid categoryId, string name, string description, DateTimeOffset createdOn, Guid createdBY, DateTimeOffset modifiedOn, Guid modifiedBy)
        {
            this.categoryId = categoryId;
            this.name = name;
            this.description = description;
            this.createdOn = createdOn;
            this.createdBY = createdBY;
            this.modifiedOn = modifiedOn;
            this.modifiedBy = modifiedBy;
        }
    }
}
